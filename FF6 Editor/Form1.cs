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
        public string FName;
        private int statSum = 0;
        public int Fileoffset { get; private set; }
        int ActorCheckStats;
        int ActorCheckNaturalMagic;
        int LevelCheck;
        int EsperLevelCheck;
        int EsperCheckMagic;
        int MonsterIndexCheck;
        int MonsterDiffCheck;
        int MonsterHPByteCheck;
        /*byte ElementalNull;
        byte ElementalAbsorb;
        byte ElementalHalf;
        byte ElementalWeak;
        byte Special_1;
        byte Special_2;
        byte Special_3;
        byte Status_Start_1;
        byte Status_Start_2;
        byte Status_Start_3;
        byte Status_Block_1;
        byte Status_Block_2;
        byte Status_Block_3;
        byte SpecialAttack;*/


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
            rom.Write8(Convert.ToByte(cmbEsperMagic1.SelectedIndex),RomData.ESPER_MAGIC_DATA + EsperCheckMagic);
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
          /*Special_1 = rom.Read8(RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck + 0x12); //0x12
            Special_2 = rom.Read8(); //0x13
            Status_Block_1 = rom.Read8(); //0x14
            Status_Block_2 = rom.Read8(); //0x15
            Status_Block_3 = rom.Read8(); //0x16
            ElementalAbsorb = rom.Read8(); //0x17
            ElementalNull = rom.Read8(); //0x18
            ElementalWeak = rom.Read8(); //0x19
            rom.Read8(); //0x1A
            Status_Start_1 = rom.Read8(); //0x1B
            Status_Start_2 = rom.Read8(); //0x1C
            Status_Start_3 = rom.Read8(); //0x1D
            Special_3 = rom.Read8(); //0x1E
            SpecialAttack = rom.Read8(); //0x1F  

            MonsterIndexCheck = cmbMonsters.SelectedIndex * 32;
            MonsterHPByteCheck = cmbDifficulty.SelectedIndex * 0x200;
            MonsterDiffCheck = cmbDifficulty.SelectedIndex * 0x4000;
            rom.Write8(Convert.ToByte(numMonsterAgility.Value),RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck);
            rom.Write8(Convert.ToByte(numMonsterAttack.Value));
            rom.Write8(Convert.ToByte(numMonsterAccuracy.Value));
            rom.Write8(Convert.ToByte(numMonsterEvasion.Value));
            rom.Write8(Convert.ToByte(numMonsterMagEva.Value));
            rom.Write8(Convert.ToByte(numMonsterDefense.Value));
            rom.Write8(Convert.ToByte(numMonsterMagDef.Value));
            rom.Write8(Convert.ToByte(numMonsterMagic.Value));
            WriteMonsterHP(numMonsterHP.Value);
            rom.Write16(Convert.ToByte(numMonsterMP.Value), RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck + 10);
            rom.Write16(Convert.ToByte(numMonsterEXP.Value));
            rom.Write16(Convert.ToByte(numMonsterGil.Value));
            rom.Write8(Convert.ToByte(numMonsterLevel.Value));
            WriteMonsterBitflags();*/

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
           /* MonsterIndexCheck = cmbMonsters.SelectedIndex * 32;
            MonsterHPByteCheck = cmbDifficulty.SelectedIndex * 0x200;
            MonsterDiffCheck = cmbDifficulty.SelectedIndex * 0x4000;
            //Monster bit flags
            Special_1 = rom.Read8(RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck + 0x12); //0x12
            Special_2 = rom.Read8(); //0x13
            Status_Block_1 = rom.Read8(); //0x14
            Status_Block_2 = rom.Read8(); //0x15
            Status_Block_3 = rom.Read8(); //0x16
            ElementalAbsorb = rom.Read8(); //0x17
            ElementalNull = rom.Read8(); //0x18
            ElementalWeak = rom.Read8(); //0x19
            //TODO: Normal Attack Animation; ComboBox, uses list of Items for animation index
            rom.Read8(); //0x1A
            Status_Start_1 = rom.Read8(); //0x1B
            Status_Start_2 = rom.Read8(); //0x1C
            Status_Start_3 = rom.Read8(); //0x1D
            Special_3 = rom.Read8(); //0x1E
            SpecialAttack = rom.Read8(); //0x1F  

            numMonsterAgility.Value = rom.Read8(RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck); //0x00
            numMonsterAttack.Value = rom.Read8(); //0x01
            numMonsterAccuracy.Value = rom.Read8(); //0x02
            numMonsterEvasion.Value = rom.Read8(); //0x03
            numMonsterMagEva.Value = rom.Read8(); //0x04
            numMonsterDefense.Value = rom.Read8(); //0x05
            numMonsterMagDef.Value = rom.Read8(); //0x06
            numMonsterMagic.Value = rom.Read8(); //0x07
            numMonsterHP.Value = ReadMonsterHP(rom.Read8(RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck + 0x08),
                rom.Read8(RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck + 0x09),
                rom.Read8(RomData.MONSTER_HP_HIGH_BYTE_NORMAL + cmbMonsters.SelectedIndex + MonsterHPByteCheck)); //0x08, 0x09
            numMonsterMP.Value = rom.Read16(RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck + 0x0A); //0x0A, 0x0B
            numMonsterEXP.Value = rom.Read16(); //0x0C, 0x0D
            numMonsterGil.Value = rom.Read16(); //0x0E, 0x0F
            numMonsterLevel.Value = rom.Read8(); //0x10
            //Metamorphisis value
            rom.Read8(); //0x11
            ReadMonsterBitflags();
            cmbNormalAttack.SelectedIndex = rom.Read8(RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck + 0x1A);*/
        }

        private void ReadMonsterBitflags()
        {
            /*  //Monster bit flags
                Special_1 = rom.Read8(RomData.MONSTER_STATS_NORMAL_DATA + MonsterIndexCheck + MonsterDiffCheck + 0x12); //0x12; MP death, Pierce Reflect, et al
                Special_2 = rom.Read8(); //0x13; Harder to run from, attacks first, et al
                Status_Block_1 = rom.Read8(); //0x14; Block darkness, block Zombie, et al
                Status_Block_2 = rom.Read8(); //0x15; Block doomed, block critical, et al
                Status_Block_3 = rom.Read8(); //0x16; Block dance, block regen, et al
                ElementalAbsorb = rom.Read8(); //0x17; Absorb Fire, Ice, Thunder, Poison, Wind, Holy, Earth, Water
                ElementalNull = rom.Read8(); //0x18; Nullify Fire, Ice, Thunder, Poison, Wind, Holy, Earth, Water
                ElementalWeak = rom.Read8(); //0x19; Weak to Fire, Ice, Thunder, Poison, Wind, Holy, Earth, Water
                //Normal Attack Animation; ComboBox, uses list of Items for animation index
                rom.Read8(); //0x1A
                Status_Start_1 = rom.Read8(); //0x1B; Start with darkness, zombie, et al
                Status_Start_2 = rom.Read8(); //0x1C; Start with doomed, critical, et al
                Status_Start_3 = rom.Read8(); //0x1D; Start with float, regen, et al
                Special_3 = rom.Read8(); //0x1E; True Knight, Runic, et al
                SpecialAttack = rom.Read8(); //0x1F; Bits 0-5 comprise index for special attack effect, bit 7 = No damage, bit 8 = Can't evade  

            chkMPDeath.Checked = Convert.ToBoolean(Special_1 & 0x01);
            chkPierceReflect.Checked = Convert.ToBoolean(Special_1 & 0x02);
            chkNoName.Checked = Convert.ToBoolean(Special_1 & 0x04);
            chkUnknown2.Checked = Convert.ToBoolean(Special_1 & 0x08);
            chkHumanoid.Checked = Convert.ToBoolean(Special_1 & 0x10);
            chkUnknown3.Checked = Convert.ToBoolean(Special_1 & 0x20);
            chkCritImp.Checked = Convert.ToBoolean(Special_1 & 0x40);
            chkUndead.Checked = Convert.ToBoolean(Special_1 & 0x80);
            */


        }

        private void WriteMonsterBitflags()
        {
          /*Special_1 = 0x00;
            Special_1 = Convert.ToByte(chkMPDeath.Checked) | Special_1;*/
        }

        /*private int ReadMonsterHP(byte LowByte, byte MidByte, byte HighByte)
        {
          /*int i = HighByte * 256;
            int j = (i + MidByte) * 256;
            int u = j + LowByte;
            return u;
        }*/

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
