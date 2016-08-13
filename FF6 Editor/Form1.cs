using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Web;

namespace FF6_Editor
{
    public partial class Form1 : Form
    {
        RomFileIO rom = new RomFileIO();
        MonsterSpecs specs = new MonsterSpecs();
        public string FName;
        public int statSum = 0;
        public int Fileoffset { get; private set; }
        public int ActorCheckStats;
        public int ActorCheckNaturalMagic;
        public int LevelCheck;
        public int EsperLevelCheck;
        public int EsperCheckMagic;
        public int MonsterIndexCheck;
        public int MonsterDiffCheck;
        public int MonsterHPByteCheck;
        public int MonsterSecondaryIndexCheck;
        public int MonsterSecondaryDiffCheck;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Disable File Saving until a file actually exists, to reduce potential problems.
            if (!rom.IsOpen())
            {
                saveAsToolStripMenuItem.Enabled = false;
                saveROMToolStripMenuItem1.Enabled = false;
            }
        }

        private void LoadROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();                                      //Setting the dialog up
            ofd.Filter = "Super Famicom ROM|*.sfc";                                         //File type filter
            ofd.Title = "Load ROM";                                                         //Title for dialog
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Could not open " + ofd.FileName);
                return;
            }
            FName = Path.GetFullPath(ofd.FileName);
            rom.Open(ofd.FileName);
            if (!CheckRomIntegrity())
            {
                MessageBox.Show("ROM does not appear to be valid SFC or SNES ROM.");
                return;
            }
            if (rom.IsOpen())
            {
                saveAsToolStripMenuItem.Enabled = true;
                saveROMToolStripMenuItem1.Enabled = true;
            }

            UpdateActorsElements();
            cmbActors.SelectedIndex = 0;
            cmbEspers.SelectedIndex = 0;
            cmbMonsters.SelectedIndex = 0;
            cmbDifficulty.SelectedIndex = 0;
        }


        private void SaveROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                //Open SaveFileDialog for file saving.
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "SNES ROM file|*.sfc";
                sfd.Title = "Save ROM";
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Could not save " + sfd.FileName);
                }
                //Save the file to disk
                //Checks to make sure a file actually has been loaded.
                if (rom.IsOpen())
                {
                    rom.SaveAs(sfd.FileName);
                }
                else
                {
                    MessageBox.Show("No ROM is loaded.", "No ROM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveROMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rom.SaveAs(FName);
        }

        private void SaveActorsElements()
        {
            //Save Stats to MemoryStream
            //DOES NOT SAVE TO FILE
            rom.Write8(byte.Parse(txtStrLv0.Text),RomData.CHAR_DATA + LevelCheck + ActorCheckStats);
            rom.Write8(byte.Parse(txtStrLv1.Text));
            rom.Write8(byte.Parse(txtStrLv2.Text));
            rom.Write8(byte.Parse(txtStrLv3.Text));
            rom.Write8(byte.Parse(txtStrLv4.Text));
            rom.Write8(byte.Parse(txtStrLv5.Text));
            rom.Write8(byte.Parse(txtStrLv6.Text));
            rom.Write8(byte.Parse(txtStrLv7.Text));
            rom.Write8(byte.Parse(txtStrLv8.Text));
            rom.Write8(byte.Parse(txtStrLv9.Text));
            rom.Write8(byte.Parse(txtAgiLv0.Text),RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (100 * 15));
            rom.Write8(byte.Parse(txtAgiLv1.Text));
            rom.Write8(byte.Parse(txtAgiLv2.Text));
            rom.Write8(byte.Parse(txtAgiLv3.Text));
            rom.Write8(byte.Parse(txtAgiLv4.Text));
            rom.Write8(byte.Parse(txtAgiLv5.Text));
            rom.Write8(byte.Parse(txtAgiLv6.Text));
            rom.Write8(byte.Parse(txtAgiLv7.Text));
            rom.Write8(byte.Parse(txtAgiLv8.Text));
            rom.Write8(byte.Parse(txtAgiLv9.Text));
            rom.Write8(byte.Parse(txtStaLv0.Text),RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (200 * 15));
            rom.Write8(byte.Parse(txtStaLv1.Text));
            rom.Write8(byte.Parse(txtStaLv2.Text));
            rom.Write8(byte.Parse(txtStaLv3.Text));
            rom.Write8(byte.Parse(txtStaLv4.Text));
            rom.Write8(byte.Parse(txtStaLv5.Text));
            rom.Write8(byte.Parse(txtStaLv6.Text));
            rom.Write8(byte.Parse(txtStaLv7.Text));
            rom.Write8(byte.Parse(txtStaLv8.Text));
            rom.Write8(byte.Parse(txtStaLv9.Text));
            rom.Write8(byte.Parse(txtMagLv0.Text),RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (300 * 15));
            rom.Write8(byte.Parse(txtMagLv1.Text));
            rom.Write8(byte.Parse(txtMagLv2.Text));
            rom.Write8(byte.Parse(txtMagLv3.Text));
            rom.Write8(byte.Parse(txtMagLv4.Text));
            rom.Write8(byte.Parse(txtMagLv5.Text));
            rom.Write8(byte.Parse(txtMagLv6.Text));
            rom.Write8(byte.Parse(txtMagLv7.Text));
            rom.Write8(byte.Parse(txtMagLv8.Text));
            rom.Write8(byte.Parse(txtMagLv9.Text));
            rom.Write8(byte.Parse(txtHPLv0.Text),RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (400 * 15));
            rom.Write8(byte.Parse(txtHPLv1.Text));
            rom.Write8(byte.Parse(txtHPLv2.Text));
            rom.Write8(byte.Parse(txtHPLv3.Text));
            rom.Write8(byte.Parse(txtHPLv4.Text));
            rom.Write8(byte.Parse(txtHPLv5.Text));
            rom.Write8(byte.Parse(txtHPLv6.Text));
            rom.Write8(byte.Parse(txtHPLv7.Text));
            rom.Write8(byte.Parse(txtHPLv8.Text));
            rom.Write8(byte.Parse(txtHPLv9.Text));
            rom.Write8(byte.Parse(txtMPLv0.Text),RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (500 * 15));
            rom.Write8(byte.Parse(txtMPLv1.Text));
            rom.Write8(byte.Parse(txtMPLv2.Text));
            rom.Write8(byte.Parse(txtMPLv3.Text));
            rom.Write8(byte.Parse(txtMPLv4.Text));
            rom.Write8(byte.Parse(txtMPLv5.Text));
            rom.Write8(byte.Parse(txtMPLv6.Text));
            rom.Write8(byte.Parse(txtMPLv7.Text));
            rom.Write8(byte.Parse(txtMPLv8.Text));
            rom.Write8(byte.Parse(txtMPLv9.Text));

            //Save Natural Magic to Memory Stream
            if (cmbActors.SelectedIndex < 11)
            {
                rom.Write8(Convert.ToByte(cmbNatMag1.SelectedIndex), RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic);
                rom.Write8(Convert.ToByte(numNatMag1.Text));
                rom.Write8(Convert.ToByte(cmbNatMag2.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag2.Text));
                rom.Write8(Convert.ToByte(cmbNatMag3.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag3.Text));
                rom.Write8(Convert.ToByte(cmbNatMag4.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag4.Text));
                rom.Write8(Convert.ToByte(cmbNatMag5.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag5.Text));
                rom.Write8(Convert.ToByte(cmbNatMag6.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag6.Text));
                rom.Write8(Convert.ToByte(cmbNatMag7.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag7.Text));
                rom.Write8(Convert.ToByte(cmbNatMag8.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag8.Text));
                rom.Write8(Convert.ToByte(cmbNatMag9.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag9.Text));
                rom.Write8(Convert.ToByte(cmbNatMag10.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag10.Text));
                rom.Write8(Convert.ToByte(cmbNatMag11.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag11.Text));
                rom.Write8(Convert.ToByte(cmbNatMag12.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag12.Text));
                rom.Write8(Convert.ToByte(cmbNatMag13.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag13.Text));
                rom.Write8(Convert.ToByte(cmbNatMag14.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag14.Text));
                rom.Write8(Convert.ToByte(cmbNatMag15.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag15.Text));
                rom.Write8(Convert.ToByte(cmbNatMag16.SelectedIndex));
                rom.Write8(Convert.ToByte(numNatMag16.Text));
            }
            
            UpdateActorsElements();
        }

        private void SaveEsperElements()
        {
            //Write the esper magic struct to the MemoryStream.
            EsperCheckMagic = cmbEspers.SelectedIndex * 11;
            rom.Write8(Convert.ToByte(cmbEsperMagic1.SelectedIndex), RomData.ESPER_MAGIC_DATA + EsperCheckMagic);
            rom.Write8(Convert.ToByte(cmbEsperMagic2.SelectedIndex));
            rom.Write8(Convert.ToByte(cmbEsperMagic3.SelectedIndex));
            rom.Write8(Convert.ToByte(cmbEsperMagic4.SelectedIndex));
            rom.Write8(Convert.ToByte(cmbEsperMagic5.SelectedIndex));
            rom.Write8(Convert.ToByte(cmbEsperMagic6.SelectedIndex));
            rom.Write8(Convert.ToByte(cmbEsperMagic7.SelectedIndex));
            rom.Write8(Convert.ToByte(cmbEsperMagic8.SelectedIndex));
            rom.Write8(Convert.ToByte(cmbEsperMagic9.SelectedIndex));
            rom.Write8(Convert.ToByte(cmbEsperMagic10.SelectedIndex));

            //Write the esper bonus struct to the MemoryStream.
            EsperLevelCheck = cmbEspers.SelectedIndex * 80;
            rom.Write8(Convert.ToByte(txtEsperStr1.Text), RomData.ESPER_BONUS_DATA + EsperLevelCheck);
            rom.Write8(Convert.ToByte(txtEsperStr2.Text));
            rom.Write8(Convert.ToByte(txtEsperStr3.Text));
            rom.Write8(Convert.ToByte(txtEsperStr4.Text));
            rom.Write8(Convert.ToByte(txtEsperStr5.Text));
            rom.Write8(Convert.ToByte(txtEsperStr6.Text));
            rom.Write8(Convert.ToByte(txtEsperStr7.Text));
            rom.Write8(Convert.ToByte(txtEsperStr8.Text));
            rom.Write8(Convert.ToByte(txtEsperStr9.Text));
            rom.Write8(Convert.ToByte(txtEsperStr10.Text));
            rom.Write8(Convert.ToByte(txtEsperStr11.Text));
            rom.Write8(Convert.ToByte(txtEsperStr12.Text));
            rom.Write8(Convert.ToByte(txtEsperStr13.Text));
            rom.Write8(Convert.ToByte(txtEsperStr14.Text));
            rom.Write8(Convert.ToByte(txtEsperStr15.Text));
            rom.Write8(Convert.ToByte(txtEsperStr16.Text));
            rom.Write8(Convert.ToByte(txtEsperStr17.Text));
            rom.Write8(Convert.ToByte(txtEsperStr18.Text));
            rom.Write8(Convert.ToByte(txtEsperStr19.Text));
            rom.Write8(Convert.ToByte(txtEsperStr20.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi1.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi2.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi3.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi4.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi5.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi6.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi7.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi8.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi9.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi10.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi11.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi12.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi13.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi14.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi15.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi16.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi17.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi18.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi19.Text));
            rom.Write8(Convert.ToByte(txtEsperAgi20.Text));
            rom.Write8(Convert.ToByte(txtEsperVit1.Text));
            rom.Write8(Convert.ToByte(txtEsperVit2.Text));
            rom.Write8(Convert.ToByte(txtEsperVit3.Text));
            rom.Write8(Convert.ToByte(txtEsperVit4.Text));
            rom.Write8(Convert.ToByte(txtEsperVit5.Text));
            rom.Write8(Convert.ToByte(txtEsperVit6.Text));
            rom.Write8(Convert.ToByte(txtEsperVit7.Text));
            rom.Write8(Convert.ToByte(txtEsperVit8.Text));
            rom.Write8(Convert.ToByte(txtEsperVit9.Text));
            rom.Write8(Convert.ToByte(txtEsperVit10.Text));
            rom.Write8(Convert.ToByte(txtEsperVit11.Text));
            rom.Write8(Convert.ToByte(txtEsperVit12.Text));
            rom.Write8(Convert.ToByte(txtEsperVit13.Text));
            rom.Write8(Convert.ToByte(txtEsperVit14.Text));
            rom.Write8(Convert.ToByte(txtEsperVit15.Text));
            rom.Write8(Convert.ToByte(txtEsperVit16.Text));
            rom.Write8(Convert.ToByte(txtEsperVit17.Text));
            rom.Write8(Convert.ToByte(txtEsperVit18.Text));
            rom.Write8(Convert.ToByte(txtEsperVit19.Text));
            rom.Write8(Convert.ToByte(txtEsperVit20.Text));
            rom.Write8(Convert.ToByte(txtEsperMag1.Text));
            rom.Write8(Convert.ToByte(txtEsperMag2.Text));
            rom.Write8(Convert.ToByte(txtEsperMag3.Text));
            rom.Write8(Convert.ToByte(txtEsperMag4.Text));
            rom.Write8(Convert.ToByte(txtEsperMag5.Text));
            rom.Write8(Convert.ToByte(txtEsperMag6.Text));
            rom.Write8(Convert.ToByte(txtEsperMag7.Text));
            rom.Write8(Convert.ToByte(txtEsperMag8.Text));
            rom.Write8(Convert.ToByte(txtEsperMag9.Text));
            rom.Write8(Convert.ToByte(txtEsperMag10.Text));
            rom.Write8(Convert.ToByte(txtEsperMag11.Text));
            rom.Write8(Convert.ToByte(txtEsperMag12.Text));
            rom.Write8(Convert.ToByte(txtEsperMag13.Text));
            rom.Write8(Convert.ToByte(txtEsperMag14.Text));
            rom.Write8(Convert.ToByte(txtEsperMag15.Text));
            rom.Write8(Convert.ToByte(txtEsperMag16.Text));
            rom.Write8(Convert.ToByte(txtEsperMag17.Text));
            rom.Write8(Convert.ToByte(txtEsperMag18.Text));
            rom.Write8(Convert.ToByte(txtEsperMag19.Text));
            rom.Write8(Convert.ToByte(txtEsperMag20.Text));

        }

        private void SaveMonsterStats()
        {
            MonsterIndexCheck = cmbMonsters.SelectedIndex * 32;
            MonsterDiffCheck = cmbDifficulty.SelectedIndex * 0x4000;
            MonsterSecondaryIndexCheck = cmbMonsters.SelectedIndex * 3;
            MonsterSecondaryDiffCheck = cmbDifficulty.SelectedIndex * 0x0600;

            specs.Agility = Convert.ToByte(numMonsterAgility.Value);
            specs.Attack = Convert.ToByte(numMonsterAttack.Value);
            specs.Accuracy = Convert.ToByte(numMonsterAccuracy.Value);
            specs.Evasion = Convert.ToByte(numMonsterEvasion.Value);
            specs.MagEva = Convert.ToByte(numMonsterMagEva.Value);
            specs.Defense = Convert.ToByte(numMonsterDefense.Value);
            specs.MagDef = Convert.ToByte(numMonsterMagDef.Value);
            specs.Magic = Convert.ToByte(numMonsterMagic.Value);
            specs.HP = Convert.ToUInt32(numMonsterHP.Value);
            specs.MP = Convert.ToUInt16(numMonsterMP.Value);
            specs.XP = Convert.ToUInt16(numMonsterEXP.Value);
            specs.Gil = Convert.ToUInt16(numMonsterGil.Value);
            specs.Level = Convert.ToByte(numMonsterLevel.Value);
            specs.Strength = Convert.ToByte(numMonsterStrength.Value);
            specs.Vitality = Convert.ToByte(numMonsterVitality.Value);
            //if (checked) byte |= flag, else byte &= ~flag;
            if (chkMPDeath.Checked == true)
            {
                specs.FlagsA |= chkMPDeath;
            }
            else
            {
                specs.FlagsA &= ~chkMPDeath;
            }



            specs.WriteMonsterNormal(rom, RomData.MONSTER_STATS_NORMAL_DATA, MonsterIndexCheck, MonsterDiffCheck);
            specs.WriteMonsterSecondary(rom, RomData.MONSTER_STATS_NORMAL_SECONDARY_DATA, MonsterSecondaryIndexCheck, MonsterSecondaryDiffCheck);
        }

        private void UpdateActorsElements()
        {
            if (!rom.IsOpen())
                return;

            // Update level labels

            LevelCheck = (int)numLevel.Value;
            for (int i = 0; i <= 9; i++)
            {
                string controlName = "lblLevel" + i.ToString();
                Label textControl = (Label)this.Controls.Find(controlName, true).FirstOrDefault();
                int level = LevelCheck + i;
                textControl.Text = level.ToString();
            }

            // Update the stats here
            ActorCheckStats = cmbActors.SelectedIndex * 100;

            txtStrLv0.Text = rom.Read8(RomData.CHAR_DATA + LevelCheck + ActorCheckStats).ToString();
            txtStrLv1.Text = rom.Read8().ToString();
            txtStrLv2.Text = rom.Read8().ToString();
            txtStrLv3.Text = rom.Read8().ToString();
            txtStrLv4.Text = rom.Read8().ToString();
            txtStrLv5.Text = rom.Read8().ToString();
            txtStrLv6.Text = rom.Read8().ToString();
            txtStrLv7.Text = rom.Read8().ToString();
            txtStrLv8.Text = rom.Read8().ToString();
            txtStrLv9.Text = rom.Read8().ToString();
            txtAgiLv0.Text = rom.Read8(RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (100 * 15)).ToString();
            txtAgiLv1.Text = rom.Read8().ToString();
            txtAgiLv2.Text = rom.Read8().ToString();
            txtAgiLv3.Text = rom.Read8().ToString();
            txtAgiLv4.Text = rom.Read8().ToString();
            txtAgiLv5.Text = rom.Read8().ToString();
            txtAgiLv6.Text = rom.Read8().ToString();
            txtAgiLv7.Text = rom.Read8().ToString();
            txtAgiLv8.Text = rom.Read8().ToString();
            txtAgiLv9.Text = rom.Read8().ToString();
            txtStaLv0.Text = rom.Read8(RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (200 * 15)).ToString();
            txtStaLv1.Text = rom.Read8().ToString();
            txtStaLv2.Text = rom.Read8().ToString();
            txtStaLv3.Text = rom.Read8().ToString();
            txtStaLv4.Text = rom.Read8().ToString();
            txtStaLv5.Text = rom.Read8().ToString();
            txtStaLv6.Text = rom.Read8().ToString();
            txtStaLv7.Text = rom.Read8().ToString();
            txtStaLv8.Text = rom.Read8().ToString();
            txtStaLv9.Text = rom.Read8().ToString();
            txtMagLv0.Text = rom.Read8(RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (300 * 15)).ToString();
            txtMagLv1.Text = rom.Read8().ToString();
            txtMagLv2.Text = rom.Read8().ToString();
            txtMagLv3.Text = rom.Read8().ToString();
            txtMagLv4.Text = rom.Read8().ToString();
            txtMagLv5.Text = rom.Read8().ToString();
            txtMagLv6.Text = rom.Read8().ToString();
            txtMagLv7.Text = rom.Read8().ToString();
            txtMagLv8.Text = rom.Read8().ToString();
            txtMagLv9.Text = rom.Read8().ToString();
            txtHPLv0.Text = rom.Read8(RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (400 * 15)).ToString();
            txtHPLv1.Text = rom.Read8().ToString();
            txtHPLv2.Text = rom.Read8().ToString();
            txtHPLv3.Text = rom.Read8().ToString();
            txtHPLv4.Text = rom.Read8().ToString();
            txtHPLv5.Text = rom.Read8().ToString();
            txtHPLv6.Text = rom.Read8().ToString();
            txtHPLv7.Text = rom.Read8().ToString();
            txtHPLv8.Text = rom.Read8().ToString();
            txtHPLv9.Text = rom.Read8().ToString();
            txtMPLv0.Text = rom.Read8(RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (500 * 15)).ToString();
            txtMPLv1.Text = rom.Read8().ToString();
            txtMPLv2.Text = rom.Read8().ToString();
            txtMPLv3.Text = rom.Read8().ToString();
            txtMPLv4.Text = rom.Read8().ToString();
            txtMPLv5.Text = rom.Read8().ToString();
            txtMPLv6.Text = rom.Read8().ToString();
            txtMPLv7.Text = rom.Read8().ToString();
            txtMPLv8.Text = rom.Read8().ToString();
            txtMPLv9.Text = rom.Read8().ToString();

            //Show added stat values here, in increments of ten.
            txtStrLv0_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats, 11).ToString();
            txtStrLv1_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats, 21).ToString();
            txtStrLv2_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats, 31).ToString();
            txtStrLv3_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats, 41).ToString();
            txtStrLv4_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats, 51).ToString();
            txtStrLv5_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats, 61).ToString();
            txtStrLv6_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats, 71).ToString();
            txtStrLv7_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats, 81).ToString();
            txtStrLv8_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats, 91).ToString();
            txtStrLv9_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats, 100).ToString();
            txtAgiLv0_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (100 * 15), 11).ToString();
            txtAgiLv1_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (100 * 15), 21).ToString();
            txtAgiLv2_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (100 * 15), 31).ToString();
            txtAgiLv3_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (100 * 15), 41).ToString();
            txtAgiLv4_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (100 * 15), 51).ToString();
            txtAgiLv5_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (100 * 15), 61).ToString();
            txtAgiLv6_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (100 * 15), 71).ToString();
            txtAgiLv7_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (100 * 15), 81).ToString();
            txtAgiLv8_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (100 * 15), 91).ToString();
            txtAgiLv9_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (100 * 15), 100).ToString();
            txtStaLv0_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (200 * 15), 11).ToString();
            txtStaLv1_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (200 * 15), 21).ToString();
            txtStaLv2_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (200 * 15), 31).ToString();
            txtStaLv3_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (200 * 15), 41).ToString();
            txtStaLv4_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (200 * 15), 51).ToString();
            txtStaLv5_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (200 * 15), 61).ToString();
            txtStaLv6_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (200 * 15), 71).ToString();
            txtStaLv7_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (200 * 15), 81).ToString();
            txtStaLv8_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (200 * 15), 91).ToString();
            txtStaLv9_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (200 * 15), 100).ToString();
            txtMagLv0_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (300 * 15), 11).ToString();
            txtMagLv1_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (300 * 15), 21).ToString();
            txtMagLv2_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (300 * 15), 31).ToString();
            txtMagLv3_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (300 * 15), 41).ToString();
            txtMagLv4_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (300 * 15), 51).ToString();
            txtMagLv5_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (300 * 15), 61).ToString();
            txtMagLv6_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (300 * 15), 71).ToString();
            txtMagLv7_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (300 * 15), 81).ToString();
            txtMagLv8_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (300 * 15), 91).ToString();
            txtMagLv9_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (300 * 15), 100).ToString();
            txtHPLv0_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (400 * 15), 11).ToString();
            txtHPLv1_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (400 * 15), 21).ToString();
            txtHPLv2_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (400 * 15), 31).ToString();
            txtHPLv3_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (400 * 15), 41).ToString();
            txtHPLv4_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (400 * 15), 51).ToString();
            txtHPLv5_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (400 * 15), 61).ToString();
            txtHPLv6_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (400 * 15), 71).ToString();
            txtHPLv7_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (400 * 15), 81).ToString();
            txtHPLv8_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (400 * 15), 91).ToString();
            txtHPLv9_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (400 * 15), 100).ToString();
            txtMPLv0_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (500 * 15), 11).ToString();
            txtMPLv1_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (500 * 15), 21).ToString();
            txtMPLv2_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (500 * 15), 31).ToString();
            txtMPLv3_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (500 * 15), 41).ToString();
            txtMPLv4_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (500 * 15), 51).ToString();
            txtMPLv5_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (500 * 15), 61).ToString();
            txtMPLv6_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (500 * 15), 71).ToString();
            txtMPLv7_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (500 * 15), 81).ToString();
            txtMPLv8_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (500 * 15), 91).ToString();
            txtMPLv9_Add.Text = SumOfStatValues(RomData.CHAR_DATA + ActorCheckStats + (500 * 15), 100).ToString();


            //Display Natural Magic
            ActorCheckNaturalMagic = cmbActors.SelectedIndex * 32;
            cmbNatMag1.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic);
            cmbNatMag2.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 2);
            cmbNatMag3.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 4);
            cmbNatMag4.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 6);
            cmbNatMag5.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 8);
            cmbNatMag6.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 10);
            cmbNatMag7.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 12);
            cmbNatMag8.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 14);
            cmbNatMag9.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 16);
            cmbNatMag10.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 18);
            cmbNatMag11.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 20);
            cmbNatMag12.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 22);
            cmbNatMag13.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 24);
            cmbNatMag14.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 26);
            cmbNatMag15.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 28);
            cmbNatMag16.SelectedIndex = rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 30);

            //Display Natural Magic Levels
            numNatMag1.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 1));
            numNatMag2.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 3));
            numNatMag3.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 5));
            numNatMag4.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 7));
            numNatMag5.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 9));
            numNatMag6.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 11));
            numNatMag7.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 13));
            numNatMag8.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 15));
            numNatMag9.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 17));
            numNatMag10.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 19));
            numNatMag11.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 21));
            numNatMag12.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 23));
            numNatMag13.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 25));
            numNatMag14.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 27));
            numNatMag15.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 29));
            numNatMag16.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 31));
        }

        private void UpdateEsperElements()
        {
            // Read magic list for each esper.
            EsperCheckMagic = cmbEspers.SelectedIndex * 11;
            cmbEsperMagic1.SelectedIndex = rom.Read8(RomData.ESPER_MAGIC_DATA + EsperCheckMagic);
            cmbEsperMagic2.SelectedIndex = rom.Read8();
            cmbEsperMagic3.SelectedIndex = rom.Read8();
            cmbEsperMagic4.SelectedIndex = rom.Read8();
            cmbEsperMagic5.SelectedIndex = rom.Read8();
            cmbEsperMagic6.SelectedIndex = rom.Read8();
            cmbEsperMagic7.SelectedIndex = rom.Read8();
            cmbEsperMagic8.SelectedIndex = rom.Read8();
            cmbEsperMagic9.SelectedIndex = rom.Read8();
            cmbEsperMagic10.SelectedIndex = rom.Read8();

            // Read Esper Level Bonuses.

            EsperLevelCheck = cmbEspers.SelectedIndex * 80;
            txtEsperStr1.Text = rom.Read8(RomData.ESPER_BONUS_DATA + EsperLevelCheck).ToString();
            txtEsperStr2.Text = rom.Read8().ToString();
            txtEsperStr3.Text = rom.Read8().ToString();
            txtEsperStr4.Text = rom.Read8().ToString();
            txtEsperStr5.Text = rom.Read8().ToString();
            txtEsperStr6.Text = rom.Read8().ToString();
            txtEsperStr7.Text = rom.Read8().ToString();
            txtEsperStr8.Text = rom.Read8().ToString();
            txtEsperStr9.Text = rom.Read8().ToString();
            txtEsperStr10.Text = rom.Read8().ToString();
            txtEsperStr11.Text = rom.Read8().ToString();
            txtEsperStr12.Text = rom.Read8().ToString();
            txtEsperStr13.Text = rom.Read8().ToString();
            txtEsperStr14.Text = rom.Read8().ToString();
            txtEsperStr15.Text = rom.Read8().ToString();
            txtEsperStr16.Text = rom.Read8().ToString();
            txtEsperStr17.Text = rom.Read8().ToString();
            txtEsperStr18.Text = rom.Read8().ToString();
            txtEsperStr19.Text = rom.Read8().ToString();
            txtEsperStr20.Text = rom.Read8().ToString();
            txtEsperAgi1.Text = rom.Read8().ToString();
            txtEsperAgi2.Text = rom.Read8().ToString();
            txtEsperAgi3.Text = rom.Read8().ToString();
            txtEsperAgi4.Text = rom.Read8().ToString();
            txtEsperAgi5.Text = rom.Read8().ToString();
            txtEsperAgi6.Text = rom.Read8().ToString();
            txtEsperAgi7.Text = rom.Read8().ToString();
            txtEsperAgi8.Text = rom.Read8().ToString();
            txtEsperAgi9.Text = rom.Read8().ToString();
            txtEsperAgi10.Text = rom.Read8().ToString();
            txtEsperAgi11.Text = rom.Read8().ToString();
            txtEsperAgi12.Text = rom.Read8().ToString();
            txtEsperAgi13.Text = rom.Read8().ToString();
            txtEsperAgi14.Text = rom.Read8().ToString();
            txtEsperAgi15.Text = rom.Read8().ToString();
            txtEsperAgi16.Text = rom.Read8().ToString();
            txtEsperAgi17.Text = rom.Read8().ToString();
            txtEsperAgi18.Text = rom.Read8().ToString();
            txtEsperAgi19.Text = rom.Read8().ToString();
            txtEsperAgi20.Text = rom.Read8().ToString();
            txtEsperVit1.Text = rom.Read8().ToString();
            txtEsperVit2.Text = rom.Read8().ToString();
            txtEsperVit3.Text = rom.Read8().ToString();
            txtEsperVit4.Text = rom.Read8().ToString();
            txtEsperVit5.Text = rom.Read8().ToString();
            txtEsperVit6.Text = rom.Read8().ToString();
            txtEsperVit7.Text = rom.Read8().ToString();
            txtEsperVit8.Text = rom.Read8().ToString();
            txtEsperVit9.Text = rom.Read8().ToString();
            txtEsperVit10.Text = rom.Read8().ToString();
            txtEsperVit11.Text = rom.Read8().ToString();
            txtEsperVit12.Text = rom.Read8().ToString();
            txtEsperVit13.Text = rom.Read8().ToString();
            txtEsperVit14.Text = rom.Read8().ToString();
            txtEsperVit15.Text = rom.Read8().ToString();
            txtEsperVit16.Text = rom.Read8().ToString();
            txtEsperVit17.Text = rom.Read8().ToString();
            txtEsperVit18.Text = rom.Read8().ToString();
            txtEsperVit19.Text = rom.Read8().ToString();
            txtEsperVit20.Text = rom.Read8().ToString();
            txtEsperMag1.Text = rom.Read8().ToString();
            txtEsperMag2.Text = rom.Read8().ToString();
            txtEsperMag3.Text = rom.Read8().ToString();
            txtEsperMag4.Text = rom.Read8().ToString();
            txtEsperMag5.Text = rom.Read8().ToString();
            txtEsperMag6.Text = rom.Read8().ToString();
            txtEsperMag7.Text = rom.Read8().ToString();
            txtEsperMag8.Text = rom.Read8().ToString();
            txtEsperMag9.Text = rom.Read8().ToString();
            txtEsperMag10.Text = rom.Read8().ToString();
            txtEsperMag11.Text = rom.Read8().ToString();
            txtEsperMag12.Text = rom.Read8().ToString();
            txtEsperMag13.Text = rom.Read8().ToString();
            txtEsperMag14.Text = rom.Read8().ToString();
            txtEsperMag15.Text = rom.Read8().ToString();
            txtEsperMag16.Text = rom.Read8().ToString();
            txtEsperMag17.Text = rom.Read8().ToString();
            txtEsperMag18.Text = rom.Read8().ToString();
            txtEsperMag19.Text = rom.Read8().ToString();
            txtEsperMag20.Text = rom.Read8().ToString();

        }

        private void UpdateMonsterStats()
        {
            MonsterIndexCheck = cmbMonsters.SelectedIndex * 32;
            MonsterDiffCheck = cmbDifficulty.SelectedIndex * 0x4000;
            MonsterSecondaryIndexCheck = cmbMonsters.SelectedIndex * 3;
            MonsterSecondaryDiffCheck = cmbDifficulty.SelectedIndex * 0x0600;

            //Begin populating stat values
            specs.ReadMonsterNormal(rom, RomData.MONSTER_STATS_NORMAL_DATA, MonsterIndexCheck, MonsterDiffCheck);
            specs.ReadMonsterSecondary(rom, RomData.MONSTER_STATS_NORMAL_SECONDARY_DATA, MonsterSecondaryIndexCheck, MonsterSecondaryDiffCheck);
            specs.ReadMonsterHP(rom, RomData.MONSTER_HP_NORMAL, MonsterSecondaryIndexCheck, MonsterSecondaryDiffCheck);
            numMonsterAgility.Value = specs.Agility;
            numMonsterAttack.Value = specs.Attack;
            numMonsterAccuracy.Value = specs.Accuracy;
            numMonsterEvasion.Value = specs.Evasion;
            numMonsterMagEva.Value = specs.MagEva;
            numMonsterDefense.Value = specs.Defense;
            numMonsterMagDef.Value = specs.MagDef;
            numMonsterMagic.Value = specs.Magic;
            numMonsterHP.Value = specs.HP;
            numMonsterMP.Value = specs.MP;
            numMonsterEXP.Value = specs.XP;
            numMonsterGil.Value = specs.Gil;
            numMonsterLevel.Value = specs.Level;
            numMonsterStrength.Value = specs.Strength;
            numMonsterVitality.Value = specs.Vitality;
            //Begin populating the first two special bytes
            chkMPDeath.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.MPDeath);
            chkPierceReflect.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.ReflectPierce);
            chkNoName.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.NameHide);
            chkUnknown2.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.UnknownA);
            chkHumanoid.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.Humanoid);
            chkUnknown3.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.UnknownB);
            chkCritImp.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.ImpSucks);
            chkUndead.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.Undead);
            chkHarderToRun.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.FlightRisky);
            chkAttackFirst.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.Preemptive);
            chkBlockSuplex.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.NoSuplex);
            chkNoRun.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.FlightBanned);
            chkNoScan.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.NoScan);
            chkNoSketch.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.NoSketch);
            chkSpecialEvent.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.Event);
            chkNoControl.Checked = specs.FlagsA.HasFlag(MonsterFlagsA.NoControl);
            //Begin parsing status blocking bytes
            chkBlockDarkness.Checked = specs.BlockStatus.HasFlag(Status.Darkness);
            chkBlockZombie.Checked = specs.BlockStatus.HasFlag(Status.Zombie);
            chkBlockPoison.Checked = specs.BlockStatus.HasFlag(Status.Poison);
            chkBlockMagitek.Checked = specs.BlockStatus.HasFlag(Status.Magitek);
            chkBlockClear.Checked = specs.BlockStatus.HasFlag(Status.Clear);
            chkBlockImp.Checked = specs.BlockStatus.HasFlag(Status.Imp);
            chkBlockPetrify.Checked = specs.BlockStatus.HasFlag(Status.Petrify);
            chkBlockDeath.Checked = specs.BlockStatus.HasFlag(Status.Death);
            chkBlockDoomed.Checked = specs.BlockStatus.HasFlag(Status.Doomed);
            chkBlockCritical.Checked = specs.BlockStatus.HasFlag(Status.Critical);
            chkBlockBlink.Checked = specs.BlockStatus.HasFlag(Status.Blink);
            chkBlockSilence.Checked = specs.BlockStatus.HasFlag(Status.Silence);
            chkBlockBerserk.Checked = specs.BlockStatus.HasFlag(Status.Berserk);
            chkBlockConfuse.Checked = specs.BlockStatus.HasFlag(Status.Confusion);
            chkBlockSap.Checked = specs.BlockStatus.HasFlag(Status.Sap);
            chkBlockSleep.Checked = specs.BlockStatus.HasFlag(Status.Sleep);
            chkBlockDance.Checked = specs.BlockStatus.HasFlag(Status.Dance);
            chkBlockRegen.Checked = specs.BlockStatus.HasFlag(Status.Regen);
            chkBlockSlow.Checked = specs.BlockStatus.HasFlag(Status.Slow);
            chkBlockHaste.Checked = specs.BlockStatus.HasFlag(Status.Haste);
            chkBlockStop.Checked = specs.BlockStatus.HasFlag(Status.Stop);
            chkBlockShell.Checked = specs.BlockStatus.HasFlag(Status.Shell);
            chkBlockProtect.Checked = specs.BlockStatus.HasFlag(Status.Protect);
            chkBlockReflect.Checked = specs.BlockStatus.HasFlag(Status.Reflect);
            //Begin parsing elemental properties, sans Half
            chkFireAbs.Checked = specs.Absorb.HasFlag(Element.Fire);
            chkIceAbs.Checked = specs.Absorb.HasFlag(Element.Ice);
            chkThunderAbs.Checked = specs.Absorb.HasFlag(Element.Thunder);
            chkPoisonAbs.Checked = specs.Absorb.HasFlag(Element.Poison);
            chkWindAbs.Checked = specs.Absorb.HasFlag(Element.Wind);
            chkHolyAbs.Checked = specs.Absorb.HasFlag(Element.Holy);
            chkEarthAbs.Checked = specs.Absorb.HasFlag(Element.Earth);
            chkWaterAbs.Checked = specs.Absorb.HasFlag(Element.Water);
            chkFireNull.Checked = specs.Nullify.HasFlag(Element.Fire);
            chkIceNull.Checked = specs.Nullify.HasFlag(Element.Ice);
            chkThunderNull.Checked = specs.Nullify.HasFlag(Element.Thunder);
            chkPoisonNull.Checked = specs.Nullify.HasFlag(Element.Poison);
            chkWindNull.Checked = specs.Nullify.HasFlag(Element.Wind);
            chkHolyNull.Checked = specs.Nullify.HasFlag(Element.Holy);
            chkEarthNull.Checked = specs.Nullify.HasFlag(Element.Earth);
            chkWaterNull.Checked = specs.Nullify.HasFlag(Element.Water);
            chkFireWeak.Checked = specs.Weakness.HasFlag(Element.Fire);
            chkIceWeak.Checked = specs.Weakness.HasFlag(Element.Ice);
            chkThunderWeak.Checked = specs.Weakness.HasFlag(Element.Thunder);
            chkPoisonWeak.Checked = specs.Weakness.HasFlag(Element.Poison);
            chkWindWeak.Checked = specs.Weakness.HasFlag(Element.Wind);
            chkHolyWeak.Checked = specs.Weakness.HasFlag(Element.Holy);
            chkEarthWeak.Checked = specs.Weakness.HasFlag(Element.Earth);
            chkWaterWeak.Checked = specs.Weakness.HasFlag(Element.Water);
            //Attack animation
            cmbNormalAttack.SelectedIndex = specs.AttackAnimation;
            //Begin parsing StartStatus values
            chkStartDarkness.Checked = specs.StartStatus.HasFlag(Status.Darkness);
            chkStartZombie.Checked = specs.StartStatus.HasFlag(Status.Zombie);
            chkStartPoison.Checked = specs.StartStatus.HasFlag(Status.Poison);
            chkStartMagitek.Checked = specs.StartStatus.HasFlag(Status.Magitek);
            chkStartClear.Checked = specs.StartStatus.HasFlag(Status.Clear);
            chkStartImp.Checked = specs.StartStatus.HasFlag(Status.Imp);
            chkStartPetrify.Checked = specs.StartStatus.HasFlag(Status.Petrify);
            chkStartDeath.Checked = specs.StartStatus.HasFlag(Status.Death);
            chkStartDoomed.Checked = specs.StartStatus.HasFlag(Status.Doomed);
            chkStartCritical.Checked = specs.StartStatus.HasFlag(Status.Critical);
            chkStartBlink.Checked = specs.StartStatus.HasFlag(Status.Blink);
            chkStartSilence.Checked = specs.StartStatus.HasFlag(Status.Silence);
            chkStartBerserk.Checked = specs.StartStatus.HasFlag(Status.Berserk);
            chkStartConfuse.Checked = specs.StartStatus.HasFlag(Status.Confusion);
            chkStartSap.Checked = specs.StartStatus.HasFlag(Status.Sap);
            chkStartSleep.Checked = specs.StartStatus.HasFlag(Status.Sleep);
            chkStartFloat.Checked = specs.StartStatus.HasFlag(Status.Dance);
            chkStartRegen.Checked = specs.StartStatus.HasFlag(Status.Regen);
            chkStartSlow.Checked = specs.StartStatus.HasFlag(Status.Slow);
            chkStartHaste.Checked = specs.StartStatus.HasFlag(Status.Haste);
            chkStartStop.Checked = specs.StartStatus.HasFlag(Status.Stop);
            chkStartShell.Checked = specs.StartStatus.HasFlag(Status.Shell);
            chkStartProtect.Checked = specs.StartStatus.HasFlag(Status.Protect);
            chkStartReflect.Checked = specs.StartStatus.HasFlag(Status.Reflect);
            //Begin parsing final special flags byte
            chkCover.Checked = specs.FlagsB.HasFlag(MonsterFlagsB.Cover);
            chkRunic.Checked = specs.FlagsB.HasFlag(MonsterFlagsB.Runic);
            chkReraise.Checked = specs.FlagsB.HasFlag(MonsterFlagsB.Reraise);
            chkUnknown4.Checked = specs.FlagsB.HasFlag(MonsterFlagsB.UnknownA);
            chkUnknown5.Checked = specs.FlagsB.HasFlag(MonsterFlagsB.UnknownB);
            chkUnknown6.Checked = specs.FlagsB.HasFlag(MonsterFlagsB.UnknownC);
            chkUnknown7.Checked = specs.FlagsB.HasFlag(MonsterFlagsB.UnknownD);
            chkRemovableFloat.Checked = specs.FlagsB.HasFlag(MonsterFlagsB.Float);
            //TODO: Special Attack
            cmbSpecialAttack.SelectedIndex = (specs.SpecialAttack & 0x3F);
            chkNoPhys.Checked = specs.SpecialAttackFlags.HasFlag(SpecialAttackAttributesFlags.NoDamage);
            chkNoDodge.Checked = specs.SpecialAttackFlags.HasFlag(SpecialAttackAttributesFlags.NoDodge);
            //Elemental resistances
            chkFireHalf.Checked = specs.Half.HasFlag(Element.Fire);
            chkIceHalf.Checked = specs.Half.HasFlag(Element.Ice);
            chkThunderHalf.Checked = specs.Half.HasFlag(Element.Thunder);
            chkPoisonHalf.Checked = specs.Half.HasFlag(Element.Poison);
            chkWindHalf.Checked = specs.Half.HasFlag(Element.Wind);
            chkHolyHalf.Checked = specs.Half.HasFlag(Element.Holy);
            chkEarthHalf.Checked = specs.Half.HasFlag(Element.Earth);
            chkWaterHalf.Checked = specs.Half.HasFlag(Element.Water);
            /*numMonsterHP.Value = ReadMonsterHP(rom.Read8(RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck + 0x08),
                  rom.Read8(RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck + 0x09),
                  rom.Read8(RomData.MONSTER_HP_HIGH_BYTE_NORMAL + cmbMonsters.SelectedIndex + MonsterHPByteCheck)); //0x08, 0x09*/

        }

        private void WriteMonsterHP(decimal MonsterHP)
        {
          /*uint i = Convert.ToUInt32(MonsterHP);
            byte[] j = BitConverter.GetBytes(i);
            rom.Write8(j[0], RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck + 8);
            rom.Write8(j[1], RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck + 9);
            rom.Write8(j[2], RomData.MONSTER_HP_HIGH_BYTE_NORMAL + cmbMonsters.SelectedIndex + MonsterHPByteCheck);*/
        }

        private int SumOfStatValues(int FileOffset, int CalcValue)
        {
            statSum = 0;
            for (int i = 0; i < CalcValue; i++)
            {
                statSum += rom.Read8(FileOffset + i);
            }
            return statSum;
        }

        private int CheckNaturalMagicRange(int SpellValue)
        {
            if (SpellValue <= 53)
            {
                return SpellValue;
            }
            else
            {
                return 255;
            }
        }

        private int CheckNatMagicLevelRange(int LevelValue)
        {
            if (LevelValue > 0 && LevelValue <= 99)
            {
                return LevelValue;
            }
            else
            {
                return 255;
            }
        }

        private bool CheckRomIntegrity()
        {
            byte integrity_check_value = 0x0e;
            int integrity_check;
            integrity_check = rom.Read8(integrity_check_value);
            if (integrity_check != 234)
            {
                return false;
            }
            else return true;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Removes gameArray data and closes editor.
            rom.Close();
            Application.Exit();
        }

        private void NumLevel_ValueChanged_1(object sender, EventArgs e)
        {
            UpdateActorsElements();
        }

        private void CmbActors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActors.SelectedIndex > 11)
            {
                numNatMag1.Visible = false;
                cmbNatMag1.Visible = false;
                numNatMag2.Visible = false;
                cmbNatMag2.Visible = false;
                numNatMag3.Visible = false;
                cmbNatMag3.Visible = false;
                numNatMag4.Visible = false;
                cmbNatMag4.Visible = false;
                numNatMag5.Visible = false;
                cmbNatMag5.Visible = false;
                numNatMag6.Visible = false;
                cmbNatMag6.Visible = false;
                numNatMag7.Visible = false;
                cmbNatMag7.Visible = false;
                numNatMag8.Visible = false;
                cmbNatMag8.Visible = false;
                numNatMag9.Visible = false;
                cmbNatMag9.Visible = false;
                numNatMag10.Visible = false;
                cmbNatMag10.Visible = false;
                numNatMag11.Visible = false;
                cmbNatMag11.Visible = false;
                numNatMag12.Visible = false;
                cmbNatMag12.Visible = false;
                numNatMag13.Visible = false;
                cmbNatMag13.Visible = false;
                numNatMag14.Visible = false;
                cmbNatMag14.Visible = false;
                numNatMag15.Visible = false;
                cmbNatMag15.Visible = false;
                numNatMag16.Visible = false;
                cmbNatMag16.Visible = false;
                lblNaturalMagic.Visible = false;
            }
            else
            {
                numNatMag1.Visible = true;
                cmbNatMag1.Visible = true;
                numNatMag2.Visible = true;
                cmbNatMag2.Visible = true;
                numNatMag3.Visible = true;
                cmbNatMag3.Visible = true;
                numNatMag4.Visible = true;
                cmbNatMag4.Visible = true;
                numNatMag5.Visible = true;
                cmbNatMag5.Visible = true;
                numNatMag6.Visible = true;
                cmbNatMag6.Visible = true;
                numNatMag7.Visible = true;
                cmbNatMag7.Visible = true;
                numNatMag8.Visible = true;
                cmbNatMag8.Visible = true;
                numNatMag9.Visible = true;
                cmbNatMag9.Visible = true;
                numNatMag10.Visible = true;
                cmbNatMag10.Visible = true;
                numNatMag11.Visible = true;
                cmbNatMag11.Visible = true;
                numNatMag12.Visible = true;
                cmbNatMag12.Visible = true;
                numNatMag13.Visible = true;
                cmbNatMag13.Visible = true;
                numNatMag14.Visible = true;
                cmbNatMag14.Visible = true;
                numNatMag15.Visible = true;
                cmbNatMag15.Visible = true;
                numNatMag16.Visible = true;
                cmbNatMag16.Visible = true;
                lblNaturalMagic.Visible = true;
            }
            UpdateActorsElements();
        }

        private void btnActorsOkay_Click(object sender, EventArgs e)
        {
            //Saves values to the MemoryStream
            SaveActorsElements();
        }

        private void btnActorsCancel_Click(object sender, EventArgs e)
        {
            //Resets elements
            UpdateActorsElements();
        }

        private void numNatMag1_ValueChanged(object sender, EventArgs e)
        {
            if (numNatMag1.Value < 1 | numNatMag1.Value > 99)
            {
                numNatMag1.Value = 255;
            }
        }

        private void cmbNatMag1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNatMag1.SelectedIndex > 53)
            {
                cmbNatMag1.SelectedIndex = 255;
            }
        }

        private void cmbEspers_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEsperElements();
        }

        private void btnEspersOkay_Click(object sender, EventArgs e)
        {
            SaveEsperElements();
        }

        private void btnEspersCancel_Click(object sender, EventArgs e)
        {
            UpdateEsperElements();
        }

        private void cmbMonsters_SelectedIndexChanged(object sender, EventArgs e)
        {
            numMonsterIndex.Value = cmbMonsters.SelectedIndex;
            UpdateMonsterStats();
        }

        private void cmbDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMonsterStats();
        }

        private void numMonsterIndex_ValueChanged(object sender, EventArgs e)
        {
            if (numMonsterIndex.Value < 384)
            {
                int i;
                i = Convert.ToInt16(numMonsterIndex.Value);
                cmbMonsters.SelectedIndex = i;
            }
            else
            {
                return;
            }
            UpdateMonsterStats();
        }

        private void btnMonstersOkay_Click(object sender, EventArgs e)
        {
            SaveMonsterStats();
        }

        private void btnMonstersCancel_Click(object sender, EventArgs e)
        {
            UpdateMonsterStats();
        }

        /*private void btnMoveHP_Click(object sender, EventArgs e)
        {
            // for (int i = 0; i < 384; i++) { short hp = ROM.Read16(offset + 0x20 * i); ROM.Write16(offset2 + 0x20 * i); }
            for (int i = 0; i < 384; i++)
            {
                ushort hp = rom.Read16(RomData.MONSTER_STATS_NORMAL_DATA + 0x08 + (i*0x20));
                rom.Write16(hp, RomData.MONSTER_HP_NORMAL + i*3);
                rom.Write8(0);
            }
        }*/
    }
}
