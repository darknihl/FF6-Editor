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
        RomFileIO Rom = new RomFileIO();
        EnemySpecs Specs = new EnemySpecs();
        Spells Spells = new Spells();
        Espers Espers = new Espers();
        FF6TextTables TextTable = new FF6TextTables();
        SpellList SpellList = new SpellList();
        EnemyList EnemyList = new EnemyList();

        public string FName;
        public int statSum = 0;
        public int Fileoffset { get; private set; }
        public int ActorCheckStats;
        public int ActorCheckNaturalMagic;
        public int LevelCheck;
        public int EsperLevelCheck;
        public int EsperCheckMagic;
        public int EsperCharIndex;
        public int EsperBonusMult;
        public int MonsterIndexCheck;
        public int MonsterDiffCheck;
        public int MonsterHPByteCheck;
        public int MonsterSecondaryIndexCheck;
        public int MonsterSecondaryDiffCheck;
        public int MonsterStealDropIndexCheck;
        public int MonsterRageSketchIndex;
        public int SpellIndex;
        public int SpellDelayIndex;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Disable File Saving until a file actually exists, to reduce potential problems.
            if (!Rom.IsOpen())
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
            Rom.Open(ofd.FileName);
            if (Rom.IsOpen())
            {
                saveAsToolStripMenuItem.Enabled = true;
                saveROMToolStripMenuItem1.Enabled = true;
            }
            DisplaySpellNames();
            DisplayEnemyNames();
            cmbActors.SelectedIndex = 0;
            cmbEspers.SelectedIndex = 0;
            cmbMonsters.SelectedIndex = 0;
            cmbDifficulty.SelectedIndex = 0;
            //cmbSpells.SelectedIndex = 0;
            UpdateActorsElements();
            UpdateEsperElements();
            UpdateMonsterStats();
            UpdateSpells();
            
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
                if (Rom.IsOpen())
                {
                    Rom.SaveAs(sfd.FileName);
                }
                else
                {
                    MessageBox.Show("No ROM is loaded.", "No ROM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveROMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rom.SaveAs(FName);
        }

        private void UpdateActorsElements()
        {
            if (!Rom.IsOpen())
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

            txtStrLv0.Text = Rom.Read8(RomData.CHAR_DATA + LevelCheck + ActorCheckStats).ToString();
            txtStrLv1.Text = Rom.Read8().ToString();
            txtStrLv2.Text = Rom.Read8().ToString();
            txtStrLv3.Text = Rom.Read8().ToString();
            txtStrLv4.Text = Rom.Read8().ToString();
            txtStrLv5.Text = Rom.Read8().ToString();
            txtStrLv6.Text = Rom.Read8().ToString();
            txtStrLv7.Text = Rom.Read8().ToString();
            txtStrLv8.Text = Rom.Read8().ToString();
            txtStrLv9.Text = Rom.Read8().ToString();
            txtAgiLv0.Text = Rom.Read8(RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (100 * 15)).ToString();
            txtAgiLv1.Text = Rom.Read8().ToString();
            txtAgiLv2.Text = Rom.Read8().ToString();
            txtAgiLv3.Text = Rom.Read8().ToString();
            txtAgiLv4.Text = Rom.Read8().ToString();
            txtAgiLv5.Text = Rom.Read8().ToString();
            txtAgiLv6.Text = Rom.Read8().ToString();
            txtAgiLv7.Text = Rom.Read8().ToString();
            txtAgiLv8.Text = Rom.Read8().ToString();
            txtAgiLv9.Text = Rom.Read8().ToString();
            txtStaLv0.Text = Rom.Read8(RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (200 * 15)).ToString();
            txtStaLv1.Text = Rom.Read8().ToString();
            txtStaLv2.Text = Rom.Read8().ToString();
            txtStaLv3.Text = Rom.Read8().ToString();
            txtStaLv4.Text = Rom.Read8().ToString();
            txtStaLv5.Text = Rom.Read8().ToString();
            txtStaLv6.Text = Rom.Read8().ToString();
            txtStaLv7.Text = Rom.Read8().ToString();
            txtStaLv8.Text = Rom.Read8().ToString();
            txtStaLv9.Text = Rom.Read8().ToString();
            txtMagLv0.Text = Rom.Read8(RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (300 * 15)).ToString();
            txtMagLv1.Text = Rom.Read8().ToString();
            txtMagLv2.Text = Rom.Read8().ToString();
            txtMagLv3.Text = Rom.Read8().ToString();
            txtMagLv4.Text = Rom.Read8().ToString();
            txtMagLv5.Text = Rom.Read8().ToString();
            txtMagLv6.Text = Rom.Read8().ToString();
            txtMagLv7.Text = Rom.Read8().ToString();
            txtMagLv8.Text = Rom.Read8().ToString();
            txtMagLv9.Text = Rom.Read8().ToString();
            txtHPLv0.Text = Rom.Read8(RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (400 * 15)).ToString();
            txtHPLv1.Text = Rom.Read8().ToString();
            txtHPLv2.Text = Rom.Read8().ToString();
            txtHPLv3.Text = Rom.Read8().ToString();
            txtHPLv4.Text = Rom.Read8().ToString();
            txtHPLv5.Text = Rom.Read8().ToString();
            txtHPLv6.Text = Rom.Read8().ToString();
            txtHPLv7.Text = Rom.Read8().ToString();
            txtHPLv8.Text = Rom.Read8().ToString();
            txtHPLv9.Text = Rom.Read8().ToString();
            txtMPLv0.Text = Rom.Read8(RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (500 * 15)).ToString();
            txtMPLv1.Text = Rom.Read8().ToString();
            txtMPLv2.Text = Rom.Read8().ToString();
            txtMPLv3.Text = Rom.Read8().ToString();
            txtMPLv4.Text = Rom.Read8().ToString();
            txtMPLv5.Text = Rom.Read8().ToString();
            txtMPLv6.Text = Rom.Read8().ToString();
            txtMPLv7.Text = Rom.Read8().ToString();
            txtMPLv8.Text = Rom.Read8().ToString();
            txtMPLv9.Text = Rom.Read8().ToString();

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
            cmbNatMag1.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic);
            cmbNatMag2.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 2);
            cmbNatMag3.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 4);
            cmbNatMag4.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 6);
            cmbNatMag5.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 8);
            cmbNatMag6.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 10);
            cmbNatMag7.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 12);
            cmbNatMag8.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 14);
            cmbNatMag9.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 16);
            cmbNatMag10.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 18);
            cmbNatMag11.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 20);
            cmbNatMag12.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 22);
            cmbNatMag13.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 24);
            cmbNatMag14.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 26);
            cmbNatMag15.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 28);
            cmbNatMag16.SelectedIndex = Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 30);

            //Display Natural Magic Levels
            numNatMag1.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 1));
            numNatMag2.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 3));
            numNatMag3.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 5));
            numNatMag4.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 7));
            numNatMag5.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 9));
            numNatMag6.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 11));
            numNatMag7.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 13));
            numNatMag8.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 15));
            numNatMag9.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 17));
            numNatMag10.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 19));
            numNatMag11.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 21));
            numNatMag12.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 23));
            numNatMag13.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 25));
            numNatMag14.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 27));
            numNatMag15.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 29));
            numNatMag16.Value = CheckNatMagicLevelRange(Rom.Read8(RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic + 31));
        }

        private void SaveActorsElements()
        {
            //Save Stats to MemoryStream
            //DOES NOT SAVE TO FILE
            Rom.Write8(byte.Parse(txtStrLv0.Text),RomData.CHAR_DATA + LevelCheck + ActorCheckStats);
            Rom.Write8(byte.Parse(txtStrLv1.Text));
            Rom.Write8(byte.Parse(txtStrLv2.Text));
            Rom.Write8(byte.Parse(txtStrLv3.Text));
            Rom.Write8(byte.Parse(txtStrLv4.Text));
            Rom.Write8(byte.Parse(txtStrLv5.Text));
            Rom.Write8(byte.Parse(txtStrLv6.Text));
            Rom.Write8(byte.Parse(txtStrLv7.Text));
            Rom.Write8(byte.Parse(txtStrLv8.Text));
            Rom.Write8(byte.Parse(txtStrLv9.Text));
            Rom.Write8(byte.Parse(txtAgiLv0.Text),RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (100 * 15));
            Rom.Write8(byte.Parse(txtAgiLv1.Text));
            Rom.Write8(byte.Parse(txtAgiLv2.Text));
            Rom.Write8(byte.Parse(txtAgiLv3.Text));
            Rom.Write8(byte.Parse(txtAgiLv4.Text));
            Rom.Write8(byte.Parse(txtAgiLv5.Text));
            Rom.Write8(byte.Parse(txtAgiLv6.Text));
            Rom.Write8(byte.Parse(txtAgiLv7.Text));
            Rom.Write8(byte.Parse(txtAgiLv8.Text));
            Rom.Write8(byte.Parse(txtAgiLv9.Text));
            Rom.Write8(byte.Parse(txtStaLv0.Text),RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (200 * 15));
            Rom.Write8(byte.Parse(txtStaLv1.Text));
            Rom.Write8(byte.Parse(txtStaLv2.Text));
            Rom.Write8(byte.Parse(txtStaLv3.Text));
            Rom.Write8(byte.Parse(txtStaLv4.Text));
            Rom.Write8(byte.Parse(txtStaLv5.Text));
            Rom.Write8(byte.Parse(txtStaLv6.Text));
            Rom.Write8(byte.Parse(txtStaLv7.Text));
            Rom.Write8(byte.Parse(txtStaLv8.Text));
            Rom.Write8(byte.Parse(txtStaLv9.Text));
            Rom.Write8(byte.Parse(txtMagLv0.Text),RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (300 * 15));
            Rom.Write8(byte.Parse(txtMagLv1.Text));
            Rom.Write8(byte.Parse(txtMagLv2.Text));
            Rom.Write8(byte.Parse(txtMagLv3.Text));
            Rom.Write8(byte.Parse(txtMagLv4.Text));
            Rom.Write8(byte.Parse(txtMagLv5.Text));
            Rom.Write8(byte.Parse(txtMagLv6.Text));
            Rom.Write8(byte.Parse(txtMagLv7.Text));
            Rom.Write8(byte.Parse(txtMagLv8.Text));
            Rom.Write8(byte.Parse(txtMagLv9.Text));
            Rom.Write8(byte.Parse(txtHPLv0.Text),RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (400 * 15));
            Rom.Write8(byte.Parse(txtHPLv1.Text));
            Rom.Write8(byte.Parse(txtHPLv2.Text));
            Rom.Write8(byte.Parse(txtHPLv3.Text));
            Rom.Write8(byte.Parse(txtHPLv4.Text));
            Rom.Write8(byte.Parse(txtHPLv5.Text));
            Rom.Write8(byte.Parse(txtHPLv6.Text));
            Rom.Write8(byte.Parse(txtHPLv7.Text));
            Rom.Write8(byte.Parse(txtHPLv8.Text));
            Rom.Write8(byte.Parse(txtHPLv9.Text));
            Rom.Write8(byte.Parse(txtMPLv0.Text),RomData.CHAR_DATA + LevelCheck + ActorCheckStats + (500 * 15));
            Rom.Write8(byte.Parse(txtMPLv1.Text));
            Rom.Write8(byte.Parse(txtMPLv2.Text));
            Rom.Write8(byte.Parse(txtMPLv3.Text));
            Rom.Write8(byte.Parse(txtMPLv4.Text));
            Rom.Write8(byte.Parse(txtMPLv5.Text));
            Rom.Write8(byte.Parse(txtMPLv6.Text));
            Rom.Write8(byte.Parse(txtMPLv7.Text));
            Rom.Write8(byte.Parse(txtMPLv8.Text));
            Rom.Write8(byte.Parse(txtMPLv9.Text));

            //Save Natural Magic to Memory Stream
            if (cmbActors.SelectedIndex < 11)
            {
                Rom.Write8(Convert.ToByte(cmbNatMag1.SelectedIndex), RomData.NATURAL_MAGIC_DATA + ActorCheckNaturalMagic);
                Rom.Write8(Convert.ToByte(numNatMag1.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag2.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag2.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag3.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag3.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag4.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag4.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag5.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag5.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag6.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag6.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag7.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag7.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag8.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag8.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag9.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag9.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag10.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag10.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag11.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag11.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag12.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag12.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag13.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag13.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag14.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag14.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag15.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag15.Text));
                Rom.Write8(Convert.ToByte(cmbNatMag16.SelectedIndex));
                Rom.Write8(Convert.ToByte(numNatMag16.Text));
            }
            
            UpdateActorsElements();
        }

        private void UpdateEsperElements()
        {
            // Read magic list for each esper.
            EsperCheckMagic = cmbEspers.SelectedIndex * 20;
            EsperLevelCheck = cmbEspers.SelectedIndex * 80;
            EsperCharIndex = cmbEspers.SelectedIndex * 2;
            EsperBonusMult = cmbEspers.SelectedIndex * 25;

            Espers.ReadCharEquip(Rom, RomData.ESPER_CHAR_EQUIP, EsperCharIndex);
            Espers.ReadEsperStatRestrictions(Rom, RomData.ESPER_BONUS_LIMITERS, cmbEspers.SelectedIndex);

            cmbEsperMagic1.SelectedIndex = Rom.Read8(RomData.ESPER_MAGIC_DATA + EsperCheckMagic);
            nmbEsperMagic1.Value = Rom.Read8();
            cmbEsperMagic2.SelectedIndex = Rom.Read8();
            nmbEsperMagic2.Value = Rom.Read8();
            cmbEsperMagic3.SelectedIndex = Rom.Read8();
            nmbEsperMagic3.Value = Rom.Read8();
            cmbEsperMagic4.SelectedIndex = Rom.Read8();
            nmbEsperMagic4.Value = Rom.Read8();
            cmbEsperMagic5.SelectedIndex = Rom.Read8();
            nmbEsperMagic5.Value = Rom.Read8();
            cmbEsperMagic6.SelectedIndex = Rom.Read8();
            nmbEsperMagic6.Value = Rom.Read8();
            cmbEsperMagic7.SelectedIndex = Rom.Read8();
            nmbEsperMagic7.Value = Rom.Read8();
            cmbEsperMagic8.SelectedIndex = Rom.Read8();
            nmbEsperMagic8.Value = Rom.Read8();
            cmbEsperMagic9.SelectedIndex = Rom.Read8();
            nmbEsperMagic9.Value = Rom.Read8();
            cmbEsperMagic10.SelectedIndex = Rom.Read8();
            nmbEsperMagic10.Value = Rom.Read8();

            // Read Esper Level Bonuses.
            numSkillPoints1.Value = Rom.Read8(RomData.ESPER_BONUS_DATA + EsperBonusMult);
            numSkillPoints2.Value = Rom.Read8();
            numSkillPoints3.Value = Rom.Read8();
            numSkillPoints4.Value = Rom.Read8();
            numSkillPoints5.Value = Rom.Read8();
            numSkillPoints6.Value = Rom.Read8();
            numSkillPoints7.Value = Rom.Read8();
            numSkillPoints8.Value = Rom.Read8();
            numSkillPoints9.Value = Rom.Read8();
            numSkillPoints10.Value = Rom.Read8();
            numSkillPoints11.Value = Rom.Read8();
            numSkillPoints12.Value = Rom.Read8();
            numSkillPoints13.Value = Rom.Read8();
            numSkillPoints14.Value = Rom.Read8();
            numSkillPoints15.Value = Rom.Read8();
            numSkillPoints16.Value = Rom.Read8();
            numSkillPoints17.Value = Rom.Read8();
            numSkillPoints18.Value = Rom.Read8();
            numSkillPoints19.Value = Rom.Read8();
            numSkillPoints20.Value = Rom.Read8();
            numSkillPoints21.Value = Rom.Read8();
            numSkillPoints22.Value = Rom.Read8();
            numSkillPoints23.Value = Rom.Read8();
            numSkillPoints24.Value = Rom.Read8();
            numSkillPoints25.Value = Rom.Read8();

            if (Espers.CharEquip.HasFlag(CharEquip.Terra) == true) chkLstEsperChars.SetItemChecked(0, true); else chkLstEsperChars.SetItemChecked(0, false);
            if (Espers.CharEquip.HasFlag(CharEquip.Locke) == true) chkLstEsperChars.SetItemChecked(1, true); else chkLstEsperChars.SetItemChecked(1, false);
            if (Espers.CharEquip.HasFlag(CharEquip.Cyan) == true) chkLstEsperChars.SetItemChecked(2, true); else chkLstEsperChars.SetItemChecked(2, false);
            if (Espers.CharEquip.HasFlag(CharEquip.Shadow) == true) chkLstEsperChars.SetItemChecked(3, true); else chkLstEsperChars.SetItemChecked(3, false);
            if (Espers.CharEquip.HasFlag(CharEquip.Edgar) == true) chkLstEsperChars.SetItemChecked(4, true); else chkLstEsperChars.SetItemChecked(4, false);
            if (Espers.CharEquip.HasFlag(CharEquip.Sabin) == true) chkLstEsperChars.SetItemChecked(5, true); else chkLstEsperChars.SetItemChecked(5, false);
            if (Espers.CharEquip.HasFlag(CharEquip.Celes) == true) chkLstEsperChars.SetItemChecked(6, true); else chkLstEsperChars.SetItemChecked(6, false);
            if (Espers.CharEquip.HasFlag(CharEquip.Strago) == true) chkLstEsperChars.SetItemChecked(7, true); else chkLstEsperChars.SetItemChecked(7, false);
            if (Espers.CharEquip.HasFlag(CharEquip.Relm) == true) chkLstEsperChars.SetItemChecked(8, true); else chkLstEsperChars.SetItemChecked(8, false);
            if (Espers.CharEquip.HasFlag(CharEquip.Setzer) == true) chkLstEsperChars.SetItemChecked(9, true); else chkLstEsperChars.SetItemChecked(9, false);
            if (Espers.CharEquip.HasFlag(CharEquip.Mog) == true) chkLstEsperChars.SetItemChecked(10, true); else chkLstEsperChars.SetItemChecked(10, false);
            if (Espers.CharEquip.HasFlag(CharEquip.Gau) == true) chkLstEsperChars.SetItemChecked(11, true); else chkLstEsperChars.SetItemChecked(11, false);
            if (Espers.CharEquip.HasFlag(CharEquip.Gogo) == true) chkLstEsperChars.SetItemChecked(12, true); else chkLstEsperChars.SetItemChecked(12, false);
            if (Espers.CharEquip.HasFlag(CharEquip.Umaro) == true) chkLstEsperChars.SetItemChecked(13, true); else chkLstEsperChars.SetItemChecked(13, false);

            if (Espers.EsperStats.HasFlag(EsperStats.Strength) == true) chkLstEsperStats.SetItemChecked(0, true); else chkLstEsperStats.SetItemChecked(0, false);
            if (Espers.EsperStats.HasFlag(EsperStats.Agility) == true) chkLstEsperStats.SetItemChecked(1, true); else chkLstEsperStats.SetItemChecked(1, false);
            if (Espers.EsperStats.HasFlag(EsperStats.Vitality) == true) chkLstEsperStats.SetItemChecked(2, true); else chkLstEsperStats.SetItemChecked(2, false);
            if (Espers.EsperStats.HasFlag(EsperStats.Magic) == true) chkLstEsperStats.SetItemChecked(3, true); else chkLstEsperStats.SetItemChecked(3, false);
        }

        private void SaveEsperElements()
        {
            //Write the esper magic struct to the MemoryStream.
            EsperCheckMagic = cmbEspers.SelectedIndex * 20;
            EsperBonusMult = cmbEspers.SelectedIndex * 25;
            Rom.Write8(Convert.ToByte(cmbEsperMagic1.SelectedIndex), RomData.ESPER_MAGIC_DATA + EsperCheckMagic);
            Rom.Write8(Convert.ToByte(nmbEsperMagic1.Value));
            Rom.Write8(Convert.ToByte(cmbEsperMagic2.SelectedIndex));
            Rom.Write8(Convert.ToByte(nmbEsperMagic2.Value));
            Rom.Write8(Convert.ToByte(cmbEsperMagic3.SelectedIndex));
            Rom.Write8(Convert.ToByte(nmbEsperMagic3.Value));
            Rom.Write8(Convert.ToByte(cmbEsperMagic4.SelectedIndex));
            Rom.Write8(Convert.ToByte(nmbEsperMagic4.Value));
            Rom.Write8(Convert.ToByte(cmbEsperMagic5.SelectedIndex));
            Rom.Write8(Convert.ToByte(nmbEsperMagic5.Value));
            Rom.Write8(Convert.ToByte(cmbEsperMagic6.SelectedIndex));
            Rom.Write8(Convert.ToByte(nmbEsperMagic6.Value));
            Rom.Write8(Convert.ToByte(cmbEsperMagic7.SelectedIndex));
            Rom.Write8(Convert.ToByte(nmbEsperMagic7.Value));
            Rom.Write8(Convert.ToByte(cmbEsperMagic8.SelectedIndex));
            Rom.Write8(Convert.ToByte(nmbEsperMagic8.Value));
            Rom.Write8(Convert.ToByte(cmbEsperMagic9.SelectedIndex));
            Rom.Write8(Convert.ToByte(nmbEsperMagic9.Value));
            Rom.Write8(Convert.ToByte(cmbEsperMagic10.SelectedIndex));
            Rom.Write8(Convert.ToByte(nmbEsperMagic10.Value));

            //Write the esper bonus struct to the MemoryStream.
            Rom.Write8((byte)numSkillPoints1.Value, RomData.ESPER_BONUS_DATA + EsperBonusMult);
            Rom.Write8((byte)numSkillPoints2.Value);
            Rom.Write8((byte)numSkillPoints3.Value);
            Rom.Write8((byte)numSkillPoints4.Value);
            Rom.Write8((byte)numSkillPoints5.Value);
            Rom.Write8((byte)numSkillPoints6.Value);
            Rom.Write8((byte)numSkillPoints7.Value);
            Rom.Write8((byte)numSkillPoints8.Value);
            Rom.Write8((byte)numSkillPoints9.Value);
            Rom.Write8((byte)numSkillPoints10.Value);
            Rom.Write8((byte)numSkillPoints11.Value);
            Rom.Write8((byte)numSkillPoints12.Value);
            Rom.Write8((byte)numSkillPoints13.Value);
            Rom.Write8((byte)numSkillPoints14.Value);
            Rom.Write8((byte)numSkillPoints15.Value);
            Rom.Write8((byte)numSkillPoints16.Value);
            Rom.Write8((byte)numSkillPoints17.Value);
            Rom.Write8((byte)numSkillPoints18.Value);
            Rom.Write8((byte)numSkillPoints19.Value);
            Rom.Write8((byte)numSkillPoints20.Value);
            Rom.Write8((byte)numSkillPoints21.Value);
            Rom.Write8((byte)numSkillPoints22.Value);
            Rom.Write8((byte)numSkillPoints23.Value);
            Rom.Write8((byte)numSkillPoints24.Value);
            Rom.Write8((byte)numSkillPoints25.Value);


            EsperCharIndex = cmbEspers.SelectedIndex * 2;
            if (chkLstEsperChars.GetItemChecked(0)) Espers.CharEquip |= CharEquip.Terra; else Espers.CharEquip &= ~CharEquip.Terra;
            if (chkLstEsperChars.GetItemChecked(1)) Espers.CharEquip |= CharEquip.Locke; else Espers.CharEquip &= ~CharEquip.Locke;
            if (chkLstEsperChars.GetItemChecked(2)) Espers.CharEquip |= CharEquip.Cyan; else Espers.CharEquip &= ~CharEquip.Cyan;
            if (chkLstEsperChars.GetItemChecked(3)) Espers.CharEquip |= CharEquip.Shadow; else Espers.CharEquip &= ~CharEquip.Shadow;
            if (chkLstEsperChars.GetItemChecked(4)) Espers.CharEquip |= CharEquip.Edgar; else Espers.CharEquip &= ~CharEquip.Edgar;
            if (chkLstEsperChars.GetItemChecked(5)) Espers.CharEquip |= CharEquip.Sabin; else Espers.CharEquip &= ~CharEquip.Sabin;
            if (chkLstEsperChars.GetItemChecked(6)) Espers.CharEquip |= CharEquip.Celes; else Espers.CharEquip &= ~CharEquip.Celes;
            if (chkLstEsperChars.GetItemChecked(7)) Espers.CharEquip |= CharEquip.Strago; else Espers.CharEquip &= ~CharEquip.Strago;
            if (chkLstEsperChars.GetItemChecked(8)) Espers.CharEquip |= CharEquip.Relm; else Espers.CharEquip &= ~CharEquip.Relm;
            if (chkLstEsperChars.GetItemChecked(9)) Espers.CharEquip |= CharEquip.Setzer; else Espers.CharEquip &= ~CharEquip.Setzer;
            if (chkLstEsperChars.GetItemChecked(10)) Espers.CharEquip |= CharEquip.Mog; else Espers.CharEquip &= ~CharEquip.Mog;
            if (chkLstEsperChars.GetItemChecked(11)) Espers.CharEquip |= CharEquip.Gau; else Espers.CharEquip &= ~CharEquip.Gau;
            if (chkLstEsperChars.GetItemChecked(12)) Espers.CharEquip |= CharEquip.Gogo; else Espers.CharEquip &= ~CharEquip.Gogo;
            if (chkLstEsperChars.GetItemChecked(13)) Espers.CharEquip |= CharEquip.Umaro; else Espers.CharEquip &= ~CharEquip.Umaro;
            Espers.WriteCharEquip(Rom, RomData.ESPER_CHAR_EQUIP, EsperCharIndex);

            if (chkLstEsperStats.GetItemChecked(0)) Espers.EsperStats |= EsperStats.Strength; else Espers.EsperStats &= ~EsperStats.Strength;
            if (chkLstEsperStats.GetItemChecked(1)) Espers.EsperStats |= EsperStats.Agility; else Espers.EsperStats &= ~EsperStats.Agility;
            if (chkLstEsperStats.GetItemChecked(2)) Espers.EsperStats |= EsperStats.Vitality; else Espers.EsperStats &= ~EsperStats.Vitality;
            if (chkLstEsperStats.GetItemChecked(3)) Espers.EsperStats |= EsperStats.Magic; else Espers.EsperStats &= ~EsperStats.Magic;
            Espers.WriteEsperStatsRestrictions(Rom, RomData.ESPER_BONUS_LIMITERS, cmbEspers.SelectedIndex);
        }

        private void UpdateMonsterStats()
        {
            MonsterIndexCheck = cmbMonsters.SelectedIndex * 32;
            MonsterDiffCheck = cmbDifficulty.SelectedIndex * 0x4000;
            MonsterSecondaryIndexCheck = cmbMonsters.SelectedIndex * 3;
            MonsterSecondaryDiffCheck = cmbDifficulty.SelectedIndex * 0x0600;
            MonsterStealDropIndexCheck = cmbMonsters.SelectedIndex * 4;
            MonsterRageSketchIndex = cmbMonsters.SelectedIndex * 2;

            //Begin populating stat values
            Specs.ReadMonsterNormal(Rom, RomData.MONSTER_STATS_NORMAL_DATA, MonsterIndexCheck, MonsterDiffCheck);
            Specs.ReadMonsterSecondary(Rom, RomData.MONSTER_STATS_NORMAL_SECONDARY_DATA, MonsterSecondaryIndexCheck, MonsterSecondaryDiffCheck);
            Specs.ReadMonsterHP(Rom, RomData.MONSTER_HP_NORMAL, MonsterSecondaryIndexCheck, MonsterSecondaryDiffCheck);
            Specs.ReadMonsterDropsSteals(Rom, RomData.MONSTER_STEAL_DROP_TABLE, MonsterStealDropIndexCheck);
            Specs.ReadRage(Rom, RomData.MONSTER_RAGE, MonsterRageSketchIndex);
            Specs.ReadSketch(Rom, RomData.MONSTER_SKETCH, MonsterRageSketchIndex);
            Specs.ReadControl(Rom, RomData.MONSTER_CONTROL, MonsterStealDropIndexCheck);

            numMonsterAgility.Value = Specs.Agility;
            numMonsterAttack.Value = Specs.Attack;
            numMonsterAccuracy.Value = Specs.Accuracy;
            numMonsterEvasion.Value = Specs.Evasion;
            numMonsterMagEva.Value = Specs.MagEva;
            numMonsterDefense.Value = Specs.Defense;
            numMonsterMagDef.Value = Specs.MagDef;
            numMonsterMagic.Value = Specs.Magic;
            numMonsterHP.Value = Specs.HP;
            numMonsterLP.Value = Specs.LP;
            numMonsterMP.Value = Specs.MP;
            numMonsterEXP.Value = Specs.XP;
            numMonsterGil.Value = Specs.Gil;
            numMonsterLevel.Value = Specs.Level;
            numSkillExp.Value = Specs.SkillExp;
            numMonsterStrength.Value = Specs.Strength;
            numMonsterVitality.Value = Specs.Vitality;
            //Begin populating the first two special bytes
            chkMPDeath.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.MPDeath);
            chkIgnoreITD.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.IgnoreITD);
            chkNoName.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.NameHide);
            chkPierceReflect.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.PierceReflect);
            chkHumanoid.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.Humanoid);
            chkUnknown2.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.UnknownA);
            chkCritImp.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.ImpSucks);
            chkUndead.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.Undead);
            chkHarderToRun.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.FlightRisky);
            chkAttackFirst.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.Preemptive);
            chkBlockSuplex.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.NoSuplex);
            chkNoRun.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.FlightBanned);
            chkNoScan.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.NoScan);
            chkNoSketch.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.NoSketch);
            chkSpecialEvent.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.Event);
            chkNoControl.Checked = Specs.FlagsA.HasFlag(MonsterFlagsA.NoControl);
            //Begin parsing status blocking bytes
            chkBlockDarkness.Checked = Specs.BlockStatus.HasFlag(Status.Darkness);
            chkBlockZombie.Checked = Specs.BlockStatus.HasFlag(Status.Zombie);
            chkBlockPoison.Checked = Specs.BlockStatus.HasFlag(Status.Poison);
            chkBlockMagitek.Checked = Specs.BlockStatus.HasFlag(Status.Magitek);
            chkBlockClear.Checked = Specs.BlockStatus.HasFlag(Status.Clear);
            chkBlockImp.Checked = Specs.BlockStatus.HasFlag(Status.Imp);
            chkBlockPetrify.Checked = Specs.BlockStatus.HasFlag(Status.Petrify);
            chkBlockDeath.Checked = Specs.BlockStatus.HasFlag(Status.Death);
            chkBlockDoomed.Checked = Specs.BlockStatus.HasFlag(Status.Doomed);
            chkBlockCritical.Checked = Specs.BlockStatus.HasFlag(Status.Critical);
            chkBlockBlink.Checked = Specs.BlockStatus.HasFlag(Status.Blink);
            chkBlockSilence.Checked = Specs.BlockStatus.HasFlag(Status.Silence);
            chkBlockBerserk.Checked = Specs.BlockStatus.HasFlag(Status.Berserk);
            chkBlockConfuse.Checked = Specs.BlockStatus.HasFlag(Status.Confuse);
            chkBlockSap.Checked = Specs.BlockStatus.HasFlag(Status.Sap);
            chkBlockSleep.Checked = Specs.BlockStatus.HasFlag(Status.Sleep);
            chkBlockDance.Checked = Specs.BlockStatus.HasFlag(Status.Dance);
            chkBlockRegen.Checked = Specs.BlockStatus.HasFlag(Status.Regen);
            chkBlockSlow.Checked = Specs.BlockStatus.HasFlag(Status.Slow);
            chkBlockHaste.Checked = Specs.BlockStatus.HasFlag(Status.Haste);
            chkBlockStop.Checked = Specs.BlockStatus.HasFlag(Status.Stop);
            chkBlockShell.Checked = Specs.BlockStatus.HasFlag(Status.Shell);
            chkBlockProtect.Checked = Specs.BlockStatus.HasFlag(Status.Protect);
            chkBlockReflect.Checked = Specs.BlockStatus.HasFlag(Status.Reflect);
            //Begin parsing elemental properties, sans Half
            chkFireAbs.Checked = Specs.Absorb.HasFlag(Element.Fire);
            chkIceAbs.Checked = Specs.Absorb.HasFlag(Element.Ice);
            chkThunderAbs.Checked = Specs.Absorb.HasFlag(Element.Thunder);
            chkPoisonAbs.Checked = Specs.Absorb.HasFlag(Element.Poison);
            chkWindAbs.Checked = Specs.Absorb.HasFlag(Element.Wind);
            chkHolyAbs.Checked = Specs.Absorb.HasFlag(Element.Holy);
            chkEarthAbs.Checked = Specs.Absorb.HasFlag(Element.Earth);
            chkWaterAbs.Checked = Specs.Absorb.HasFlag(Element.Water);
            chkFireNull.Checked = Specs.Nullify.HasFlag(Element.Fire);
            chkIceNull.Checked = Specs.Nullify.HasFlag(Element.Ice);
            chkThunderNull.Checked = Specs.Nullify.HasFlag(Element.Thunder);
            chkPoisonNull.Checked = Specs.Nullify.HasFlag(Element.Poison);
            chkWindNull.Checked = Specs.Nullify.HasFlag(Element.Wind);
            chkHolyNull.Checked = Specs.Nullify.HasFlag(Element.Holy);
            chkEarthNull.Checked = Specs.Nullify.HasFlag(Element.Earth);
            chkWaterNull.Checked = Specs.Nullify.HasFlag(Element.Water);
            chkFireWeak.Checked = Specs.Weakness.HasFlag(Element.Fire);
            chkIceWeak.Checked = Specs.Weakness.HasFlag(Element.Ice);
            chkThunderWeak.Checked = Specs.Weakness.HasFlag(Element.Thunder);
            chkPoisonWeak.Checked = Specs.Weakness.HasFlag(Element.Poison);
            chkWindWeak.Checked = Specs.Weakness.HasFlag(Element.Wind);
            chkHolyWeak.Checked = Specs.Weakness.HasFlag(Element.Holy);
            chkEarthWeak.Checked = Specs.Weakness.HasFlag(Element.Earth);
            chkWaterWeak.Checked = Specs.Weakness.HasFlag(Element.Water);
            chkFireAtk.Checked = Specs.ElemAtk.HasFlag(Element.Fire);
            chkIceAtk.Checked = Specs.ElemAtk.HasFlag(Element.Ice);
            chkThunderAtk.Checked = Specs.ElemAtk.HasFlag(Element.Thunder);
            chkPoisonAtk.Checked = Specs.ElemAtk.HasFlag(Element.Poison);
            chkWindAtk.Checked = Specs.ElemAtk.HasFlag(Element.Wind);
            chkHolyAtk.Checked = Specs.ElemAtk.HasFlag(Element.Holy);
            chkEarthAtk.Checked = Specs.ElemAtk.HasFlag(Element.Earth);
            chkWaterAtk.Checked = Specs.ElemAtk.HasFlag(Element.Water);
            //Attack animation
            cmbNormalAttack.SelectedIndex = Specs.AttackAnimation;
            //Begin parsing StartStatus values
            chkStartDarkness.Checked = Specs.StartStatus.HasFlag(Status.Darkness);
            chkStartZombie.Checked = Specs.StartStatus.HasFlag(Status.Zombie);
            chkStartPoison.Checked = Specs.StartStatus.HasFlag(Status.Poison);
            chkStartMagitek.Checked = Specs.StartStatus.HasFlag(Status.Magitek);
            chkStartClear.Checked = Specs.StartStatus.HasFlag(Status.Clear);
            chkStartImp.Checked = Specs.StartStatus.HasFlag(Status.Imp);
            chkStartPetrify.Checked = Specs.StartStatus.HasFlag(Status.Petrify);
            chkStartDeath.Checked = Specs.StartStatus.HasFlag(Status.Death);
            chkStartDoomed.Checked = Specs.StartStatus.HasFlag(Status.Doomed);
            chkStartCritical.Checked = Specs.StartStatus.HasFlag(Status.Critical);
            chkStartBlink.Checked = Specs.StartStatus.HasFlag(Status.Blink);
            chkStartSilence.Checked = Specs.StartStatus.HasFlag(Status.Silence);
            chkStartBerserk.Checked = Specs.StartStatus.HasFlag(Status.Berserk);
            chkStartConfuse.Checked = Specs.StartStatus.HasFlag(Status.Confuse);
            chkStartSap.Checked = Specs.StartStatus.HasFlag(Status.Sap);
            chkStartSleep.Checked = Specs.StartStatus.HasFlag(Status.Sleep);
            chkStartFloat.Checked = Specs.StartStatus.HasFlag(Status.Dance);
            chkStartRegen.Checked = Specs.StartStatus.HasFlag(Status.Regen);
            chkStartSlow.Checked = Specs.StartStatus.HasFlag(Status.Slow);
            chkStartHaste.Checked = Specs.StartStatus.HasFlag(Status.Haste);
            chkStartStop.Checked = Specs.StartStatus.HasFlag(Status.Stop);
            chkStartShell.Checked = Specs.StartStatus.HasFlag(Status.Shell);
            chkStartProtect.Checked = Specs.StartStatus.HasFlag(Status.Protect);
            chkStartReflect.Checked = Specs.StartStatus.HasFlag(Status.Reflect);
            //Begin parsing final special flags byte
            chkCover.Checked = Specs.FlagsB.HasFlag(MonsterFlagsB.Cover);
            chkRunic.Checked = Specs.FlagsB.HasFlag(MonsterFlagsB.Runic);
            chkReraise.Checked = Specs.FlagsB.HasFlag(MonsterFlagsB.Reraise);
            chkUnknown4.Checked = Specs.FlagsB.HasFlag(MonsterFlagsB.UnknownA);
            chkUnknown5.Checked = Specs.FlagsB.HasFlag(MonsterFlagsB.UnknownB);
            chkUnknown6.Checked = Specs.FlagsB.HasFlag(MonsterFlagsB.UnknownC);
            chkUnknown7.Checked = Specs.FlagsB.HasFlag(MonsterFlagsB.UnknownD);
            chkRemovableFloat.Checked = Specs.FlagsB.HasFlag(MonsterFlagsB.Float);
            //TODO: Special Attack
            cmbSpecialAttack.SelectedIndex = (Specs.SpecialAttack & 0x3F);
            chkNoPhys.Checked = Specs.SpecialAttackFlags.HasFlag(SpecialAttackAttributesFlags.NoDamage);
            chkNoDodge.Checked = Specs.SpecialAttackFlags.HasFlag(SpecialAttackAttributesFlags.NoDodge);
            //Elemental resistances
            chkFireHalf.Checked = Specs.Half.HasFlag(Element.Fire);
            chkIceHalf.Checked = Specs.Half.HasFlag(Element.Ice);
            chkThunderHalf.Checked = Specs.Half.HasFlag(Element.Thunder);
            chkPoisonHalf.Checked = Specs.Half.HasFlag(Element.Poison);
            chkWindHalf.Checked = Specs.Half.HasFlag(Element.Wind);
            chkHolyHalf.Checked = Specs.Half.HasFlag(Element.Holy);
            chkEarthHalf.Checked = Specs.Half.HasFlag(Element.Earth);
            chkWaterHalf.Checked = Specs.Half.HasFlag(Element.Water);
            //Steals
            cmbStealsRare.SelectedIndex = Specs.RareSteal;
            cmbStealsCommon.SelectedIndex = Specs.CommonSteal;
            //Drops
            cmbDropsRare.SelectedIndex = Specs.RareDrop;
            cmbDropsCommon.SelectedIndex = Specs.CommonDrop;
            //Rages
            cmbRage1.SelectedIndex = Specs.Rage1;
            cmbRage2.SelectedIndex = Specs.Rage2;
            //Sketches
            cmbSketch1.SelectedIndex = Specs.Sketch1;
            cmbSketch2.SelectedIndex = Specs.Sketch2;
            //Control
            cmbControl1.SelectedIndex = Specs.Control1;
            cmbControl2.SelectedIndex = Specs.Control2;
            cmbControl3.SelectedIndex = Specs.Control3;
            cmbControl4.SelectedIndex = Specs.Control4;
        }

        private void SaveMonsterStats()
        {
            MonsterIndexCheck = cmbMonsters.SelectedIndex * 32;
            MonsterDiffCheck = cmbDifficulty.SelectedIndex * 0x4000;
            MonsterSecondaryIndexCheck = cmbMonsters.SelectedIndex * 3;
            MonsterSecondaryDiffCheck = cmbDifficulty.SelectedIndex * 0x0600;
            MonsterStealDropIndexCheck = cmbMonsters.SelectedIndex * 4;
            MonsterRageSketchIndex = cmbMonsters.SelectedIndex * 2;

            Specs.Agility = (byte)numMonsterAgility.Value;
            Specs.Attack = (byte)numMonsterAttack.Value;
            Specs.Accuracy = (byte)numMonsterAccuracy.Value;
            Specs.Evasion = (byte)numMonsterEvasion.Value;
            Specs.MagEva = (byte)numMonsterMagEva.Value;
            Specs.Defense = (byte)numMonsterDefense.Value;
            Specs.MagDef = (byte)numMonsterMagDef.Value;
            Specs.Magic = (byte)numMonsterMagic.Value;
            Specs.HP = (ushort)numMonsterHP.Value;
            Specs.LP = (byte)numMonsterLP.Value;
            Specs.MP = (ushort)numMonsterMP.Value;
            Specs.XP = (ushort)numMonsterEXP.Value;
            Specs.Gil = (ushort)numMonsterGil.Value;
            Specs.Level = (byte)numMonsterLevel.Value;
            Specs.SkillExp = (byte)numSkillExp.Value;
            Specs.Strength = (byte)numMonsterStrength.Value;
            Specs.Vitality = (byte)numMonsterVitality.Value;
            //Write first two special bytes
            if (chkMPDeath.Checked == true) Specs.FlagsA |= MonsterFlagsA.MPDeath; else Specs.FlagsA &= ~MonsterFlagsA.MPDeath;
            if (chkIgnoreITD.Checked == true) Specs.FlagsA |= MonsterFlagsA.IgnoreITD; else Specs.FlagsA &= ~MonsterFlagsA.IgnoreITD;
            if (chkNoName.Checked == true) Specs.FlagsA |= MonsterFlagsA.NameHide; else Specs.FlagsA &= ~MonsterFlagsA.NameHide;
            if (chkPierceReflect.Checked == true) Specs.FlagsA |= MonsterFlagsA.PierceReflect; else Specs.FlagsA &= ~MonsterFlagsA.PierceReflect;
            if (chkHumanoid.Checked == true) Specs.FlagsA |= MonsterFlagsA.Humanoid; else Specs.FlagsA &= ~MonsterFlagsA.Humanoid;
            if (chkUnknown2.Checked == true) Specs.FlagsA |= MonsterFlagsA.UnknownA; else Specs.FlagsA &= ~MonsterFlagsA.UnknownA;
            if (chkCritImp.Checked == true) Specs.FlagsA |= MonsterFlagsA.ImpSucks; else Specs.FlagsA &= ~MonsterFlagsA.ImpSucks;
            if (chkUndead.Checked == true) Specs.FlagsA |= MonsterFlagsA.Undead; else Specs.FlagsA &= ~MonsterFlagsA.Undead;
            if (chkHarderToRun.Checked == true) Specs.FlagsA |= MonsterFlagsA.FlightRisky; else Specs.FlagsA &= ~MonsterFlagsA.FlightRisky;
            if (chkAttackFirst.Checked == true) Specs.FlagsA |= MonsterFlagsA.Preemptive; else Specs.FlagsA &= ~MonsterFlagsA.Preemptive;
            if (chkBlockSuplex.Checked == true) Specs.FlagsA |= MonsterFlagsA.NoSuplex; else Specs.FlagsA &= ~MonsterFlagsA.NoSuplex;
            if (chkNoRun.Checked == true) Specs.FlagsA |= MonsterFlagsA.FlightBanned; else Specs.FlagsA &= ~MonsterFlagsA.FlightBanned;
            if (chkNoScan.Checked == true) Specs.FlagsA |= MonsterFlagsA.NoScan; else Specs.FlagsA &= ~MonsterFlagsA.NoScan;
            if (chkNoSketch.Checked == true) Specs.FlagsA |= MonsterFlagsA.NoSketch; else Specs.FlagsA &= ~MonsterFlagsA.NoSketch;
            if (chkSpecialEvent.Checked == true) Specs.FlagsA |= MonsterFlagsA.Event; else Specs.FlagsA &= ~MonsterFlagsA.Event;
            if (chkNoControl.Checked == true) Specs.FlagsA |= MonsterFlagsA.NoControl; else Specs.FlagsA &= ~MonsterFlagsA.NoControl;
            //Write blocked status bytes
            if (chkBlockDarkness.Checked == true) Specs.BlockStatus |= Status.Darkness; else Specs.BlockStatus &= ~Status.Darkness;
            if (chkBlockZombie.Checked == true) Specs.BlockStatus |= Status.Zombie; else Specs.BlockStatus &= ~Status.Zombie;
            if (chkBlockPoison.Checked == true) Specs.BlockStatus |= Status.Poison; else Specs.BlockStatus &= ~Status.Poison;
            if (chkBlockMagitek.Checked == true) Specs.BlockStatus |= Status.Magitek; else Specs.BlockStatus &= ~Status.Magitek;
            if (chkBlockClear.Checked == true) Specs.BlockStatus |= Status.Clear; else Specs.BlockStatus &= ~Status.Clear;
            if (chkBlockImp.Checked == true) Specs.BlockStatus |= Status.Imp; else Specs.BlockStatus &= ~Status.Imp;
            if (chkBlockPetrify.Checked == true) Specs.BlockStatus |= Status.Petrify; else Specs.BlockStatus &= ~Status.Petrify;
            if (chkBlockDeath.Checked == true) Specs.BlockStatus |= Status.Death; else Specs.BlockStatus &= ~Status.Death;
            if (chkBlockDoomed.Checked == true) Specs.BlockStatus |= Status.Doomed; else Specs.BlockStatus &= ~Status.Doomed;
            if (chkBlockCritical.Checked == true) Specs.BlockStatus |= Status.Critical; else Specs.BlockStatus &= ~Status.Critical;
            if (chkBlockBlink.Checked == true) Specs.BlockStatus |= Status.Blink; else Specs.BlockStatus &= ~Status.Blink;
            if (chkBlockSilence.Checked == true) Specs.BlockStatus |= Status.Silence; else Specs.BlockStatus &= ~Status.Silence;
            if (chkBlockBerserk.Checked == true) Specs.BlockStatus |= Status.Berserk; else Specs.BlockStatus &= ~Status.Berserk;
            if (chkBlockConfuse.Checked == true) Specs.BlockStatus |= Status.Confuse; else Specs.BlockStatus &= ~Status.Confuse;
            if (chkBlockSap.Checked == true) Specs.BlockStatus |= Status.Sap; else Specs.BlockStatus &= ~Status.Sap;
            if (chkBlockSleep.Checked == true) Specs.BlockStatus |= Status.Sleep; else Specs.BlockStatus &= ~Status.Sleep;
            if (chkBlockDance.Checked == true) Specs.BlockStatus |= Status.Dance; else Specs.BlockStatus &= ~Status.Dance;
            if (chkBlockRegen.Checked == true) Specs.BlockStatus |= Status.Regen; else Specs.BlockStatus &= ~Status.Regen;
            if (chkBlockSlow.Checked == true) Specs.BlockStatus |= Status.Slow; else Specs.BlockStatus &= ~Status.Slow;
            if (chkBlockHaste.Checked == true) Specs.BlockStatus |= Status.Haste; else Specs.BlockStatus &= ~Status.Haste;
            if (chkBlockStop.Checked == true) Specs.BlockStatus |= Status.Stop; else Specs.BlockStatus &= ~Status.Stop;
            if (chkBlockShell.Checked == true) Specs.BlockStatus |= Status.Shell; else Specs.BlockStatus &= ~Status.Shell;
            if (chkBlockProtect.Checked == true) Specs.BlockStatus |= Status.Protect; else Specs.BlockStatus &= ~Status.Protect;
            if (chkBlockReflect.Checked == true) Specs.BlockStatus |= Status.Reflect; else Specs.BlockStatus &= ~Status.Reflect;
            //Elemental properties -- Absorb, Nullify, Weak; Half is in a different struct
            if (chkFireAbs.Checked == true) Specs.Absorb |= Element.Fire; else Specs.Absorb &= ~Element.Fire;
            if (chkIceAbs.Checked == true) Specs.Absorb |= Element.Ice; else Specs.Absorb &= ~Element.Ice;
            if (chkThunderAbs.Checked == true) Specs.Absorb |= Element.Thunder; else Specs.Absorb &= ~Element.Thunder;
            if (chkPoisonAbs.Checked == true) Specs.Absorb |= Element.Poison; else Specs.Absorb &= ~Element.Poison;
            if (chkWindAbs.Checked == true) Specs.Absorb |= Element.Wind; else Specs.Absorb &= ~Element.Wind;
            if (chkHolyAbs.Checked == true) Specs.Absorb |= Element.Holy; else Specs.Absorb &= ~Element.Holy;
            if (chkEarthAbs.Checked == true) Specs.Absorb |= Element.Earth; else Specs.Absorb &= ~Element.Earth;
            if (chkWaterAbs.Checked == true) Specs.Absorb |= Element.Water; else Specs.Absorb &= ~Element.Water;
            //Nullify
            if (chkFireNull.Checked == true) Specs.Nullify |= Element.Fire; else Specs.Nullify &= ~Element.Fire;
            if (chkIceNull.Checked == true) Specs.Nullify |= Element.Ice; else Specs.Nullify &= ~Element.Ice;
            if (chkThunderNull.Checked == true) Specs.Nullify |= Element.Thunder; else Specs.Nullify &= ~Element.Thunder;
            if (chkPoisonNull.Checked == true) Specs.Nullify |= Element.Poison; else Specs.Nullify &= ~Element.Poison;
            if (chkWindNull.Checked == true) Specs.Nullify |= Element.Wind; else Specs.Nullify &= ~Element.Wind;
            if (chkHolyNull.Checked == true) Specs.Nullify |= Element.Holy; else Specs.Nullify &= ~Element.Holy;
            if (chkEarthNull.Checked == true) Specs.Nullify |= Element.Earth; else Specs.Nullify &= ~Element.Earth;
            if (chkWaterNull.Checked == true) Specs.Nullify |= Element.Water; else Specs.Nullify &= ~Element.Water;
            //Weakness
            if (chkFireWeak.Checked == true) Specs.Weakness |= Element.Fire; else Specs.Weakness &= ~Element.Fire;
            if (chkIceWeak.Checked == true) Specs.Weakness |= Element.Ice; else Specs.Weakness &= ~Element.Ice;
            if (chkThunderWeak.Checked == true) Specs.Weakness |= Element.Thunder; else Specs.Weakness &= ~Element.Thunder;
            if (chkPoisonWeak.Checked == true) Specs.Weakness |= Element.Poison; else Specs.Weakness &= ~Element.Poison;
            if (chkWindWeak.Checked == true) Specs.Weakness |= Element.Wind; else Specs.Weakness &= ~Element.Wind;
            if (chkHolyWeak.Checked == true) Specs.Weakness |= Element.Holy; else Specs.Weakness &= ~Element.Holy;
            if (chkEarthWeak.Checked == true) Specs.Weakness |= Element.Earth; else Specs.Weakness &= ~Element.Earth;
            if (chkWaterWeak.Checked == true) Specs.Weakness |= Element.Water; else Specs.Weakness &= ~Element.Water;
            //Attack
            if (chkFireAtk.Checked == true) Specs.ElemAtk |= Element.Fire; else Specs.ElemAtk &= ~Element.Fire;
            if (chkIceAtk.Checked == true) Specs.ElemAtk |= Element.Ice; else Specs.ElemAtk &= ~Element.Ice;
            if (chkThunderAtk.Checked == true) Specs.ElemAtk |= Element.Thunder; else Specs.ElemAtk &= ~Element.Thunder;
            if (chkPoisonAtk.Checked == true) Specs.ElemAtk |= Element.Poison; else Specs.ElemAtk &= ~Element.Poison;
            if (chkWindAtk.Checked == true) Specs.ElemAtk |= Element.Wind; else Specs.ElemAtk &= ~Element.Wind;
            if (chkHolyAtk.Checked == true) Specs.ElemAtk |= Element.Holy; else Specs.ElemAtk &= ~Element.Holy;
            if (chkEarthAtk.Checked == true) Specs.ElemAtk |= Element.Earth; else Specs.ElemAtk &= ~Element.Earth;
            if (chkWaterAtk.Checked == true) Specs.ElemAtk |= Element.Water; else Specs.ElemAtk &= ~Element.Water;
            //Attack Animation
            Specs.AttackAnimation = (byte)cmbNormalAttack.SelectedIndex;
            //Start battle status
            if (chkStartDarkness.Checked == true) Specs.StartStatus |= Status.Darkness; else Specs.StartStatus &= ~Status.Darkness;
            if (chkStartZombie.Checked == true) Specs.StartStatus |= Status.Zombie; else Specs.StartStatus &= ~Status.Zombie;
            if (chkStartPoison.Checked == true) Specs.StartStatus |= Status.Poison; else Specs.StartStatus &= ~Status.Poison;
            if (chkStartMagitek.Checked == true) Specs.StartStatus |= Status.Magitek; else Specs.StartStatus &= ~Status.Magitek;
            if (chkStartClear.Checked == true) Specs.StartStatus |= Status.Clear; else Specs.StartStatus &= ~Status.Clear;
            if (chkStartImp.Checked == true) Specs.StartStatus |= Status.Imp; else Specs.StartStatus &= ~Status.Imp;
            if (chkStartPetrify.Checked == true) Specs.StartStatus |= Status.Petrify; else Specs.StartStatus &= ~Status.Petrify;
            if (chkStartDeath.Checked == true) Specs.StartStatus |= Status.Death; else Specs.StartStatus &= ~Status.Death;
            if (chkStartDoomed.Checked == true) Specs.StartStatus |= Status.Doomed; else Specs.StartStatus &= ~Status.Doomed;
            if (chkStartCritical.Checked == true) Specs.StartStatus |= Status.Critical; else Specs.StartStatus &= ~Status.Critical;
            if (chkStartBlink.Checked == true) Specs.StartStatus |= Status.Blink; else Specs.StartStatus &= ~Status.Blink;
            if (chkStartSilence.Checked == true) Specs.StartStatus |= Status.Silence; else Specs.StartStatus &= ~Status.Silence;
            if (chkStartBerserk.Checked == true) Specs.StartStatus |= Status.Berserk; else Specs.StartStatus &= ~Status.Berserk;
            if (chkStartConfuse.Checked == true) Specs.StartStatus |= Status.Confuse; else Specs.StartStatus &= ~Status.Confuse;
            if (chkStartSap.Checked == true) Specs.StartStatus |= Status.Sap; else Specs.StartStatus &= ~Status.Sap;
            if (chkStartSleep.Checked == true) Specs.StartStatus |= Status.Sleep; else Specs.StartStatus &= ~Status.Sleep;
            if (chkStartFloat.Checked == true) Specs.StartStatus |= Status.Dance; else Specs.StartStatus &= ~Status.Dance;
            if (chkStartRegen.Checked == true) Specs.StartStatus |= Status.Regen; else Specs.StartStatus &= ~Status.Regen;
            if (chkStartSlow.Checked == true) Specs.StartStatus |= Status.Slow; else Specs.StartStatus &= ~Status.Slow;
            if (chkStartHaste.Checked == true) Specs.StartStatus |= Status.Haste; else Specs.StartStatus &= ~Status.Haste;
            if (chkStartStop.Checked == true) Specs.StartStatus |= Status.Stop; else Specs.StartStatus &= ~Status.Stop;
            if (chkStartShell.Checked == true) Specs.StartStatus |= Status.Shell; else Specs.StartStatus &= ~Status.Shell;
            if (chkStartProtect.Checked == true) Specs.StartStatus |= Status.Protect; else Specs.StartStatus &= ~Status.Protect;
            if (chkStartReflect.Checked == true) Specs.StartStatus |= Status.Reflect; else Specs.StartStatus &= ~Status.Reflect;
            //Final special flags byte
            if (chkCover.Checked == true) Specs.FlagsB |= MonsterFlagsB.Cover; else Specs.FlagsB &= ~MonsterFlagsB.Cover;
            if (chkRunic.Checked == true) Specs.FlagsB |= MonsterFlagsB.Runic; else Specs.FlagsB &= ~MonsterFlagsB.Runic;
            if (chkReraise.Checked == true) Specs.FlagsB |= MonsterFlagsB.Reraise; else Specs.FlagsB &= ~MonsterFlagsB.Reraise;
            if (chkUnknown4.Checked == true) Specs.FlagsB |= MonsterFlagsB.UnknownA; else Specs.FlagsB &= ~MonsterFlagsB.UnknownA;
            if (chkUnknown5.Checked == true) Specs.FlagsB |= MonsterFlagsB.UnknownB; else Specs.FlagsB &= ~MonsterFlagsB.UnknownB;
            if (chkUnknown6.Checked == true) Specs.FlagsB |= MonsterFlagsB.UnknownC; else Specs.FlagsB &= ~MonsterFlagsB.UnknownC;
            if (chkUnknown7.Checked == true) Specs.FlagsB |= MonsterFlagsB.UnknownD; else Specs.FlagsB &= ~MonsterFlagsB.UnknownD;
            if (chkRemovableFloat.Checked == true) Specs.FlagsB |= MonsterFlagsB.Cover; else Specs.FlagsB &= ~MonsterFlagsB.Float;
            //Special attack
            SpecialAttackAttributesFlags SpecialAttackFlags = 0;
            Specs.SpecialAttack = (byte)cmbSpecialAttack.SelectedIndex;            
            if (chkNoPhys.Checked == true) SpecialAttackFlags |= SpecialAttackAttributesFlags.NoDamage; else SpecialAttackFlags &= ~SpecialAttackAttributesFlags.NoDamage;
            if (chkNoDodge.Checked == true) SpecialAttackFlags |= SpecialAttackAttributesFlags.NoDodge; else SpecialAttackFlags &= ~SpecialAttackAttributesFlags.NoDodge;
            Specs.SpecialAttack |= (byte)SpecialAttackFlags;
            //Elemental REsistences
            if (chkFireHalf.Checked == true) Specs.Half |= Element.Fire; else Specs.Half &= ~Element.Fire;
            if (chkIceHalf.Checked == true) Specs.Half |= Element.Ice; else Specs.Half &= ~Element.Ice;
            if (chkThunderHalf.Checked == true) Specs.Half |= Element.Thunder; else Specs.Half &= ~Element.Thunder;
            if (chkPoisonHalf.Checked == true) Specs.Half |= Element.Poison; else Specs.Half &= ~Element.Poison;
            if (chkWindHalf.Checked == true) Specs.Half |= Element.Wind; else Specs.Half &= ~Element.Wind;
            if (chkHolyHalf.Checked == true) Specs.Half |= Element.Holy; else Specs.Half &= ~Element.Holy;
            if (chkEarthHalf.Checked == true) Specs.Half |= Element.Earth; else Specs.Half &= ~Element.Earth;
            if (chkWaterHalf.Checked == true) Specs.Half |= Element.Water; else Specs.Half &= ~Element.Water;
            Specs.RareSteal = (byte)cmbStealsRare.SelectedIndex;
            Specs.CommonSteal = (byte)cmbStealsCommon.SelectedIndex;
            Specs.RareDrop = (byte)cmbDropsRare.SelectedIndex;
            Specs.CommonDrop = (byte)cmbDropsCommon.SelectedIndex;
            Specs.Rage1 = (byte)cmbRage1.SelectedIndex;
            Specs.Rage2 = (byte)cmbRage2.SelectedIndex;
            Specs.Sketch1 = (byte)cmbSketch1.SelectedIndex;
            Specs.Sketch2 = (byte)cmbSketch2.SelectedIndex;
            Specs.Control1 = (byte)cmbControl1.SelectedIndex;
            Specs.Control2 = (byte)cmbControl2.SelectedIndex;
            Specs.Control3 = (byte)cmbControl3.SelectedIndex;
            Specs.Control4 = (byte)cmbControl4.SelectedIndex;

            //Actual write code
            Specs.WriteMonsterNormal(Rom, RomData.MONSTER_STATS_NORMAL_DATA, MonsterIndexCheck, MonsterDiffCheck);
            Specs.WriteMonsterSecondary(Rom, RomData.MONSTER_STATS_NORMAL_SECONDARY_DATA, MonsterSecondaryIndexCheck, MonsterSecondaryDiffCheck);
            Specs.WriteMonsterHP(Rom, RomData.MONSTER_HP_NORMAL, MonsterSecondaryIndexCheck, MonsterSecondaryDiffCheck);
            Specs.WriteMonsterStealsDrops(Rom, RomData.MONSTER_STEAL_DROP_TABLE, MonsterStealDropIndexCheck);
            Specs.WriteRage(Rom, RomData.MONSTER_RAGE, MonsterRageSketchIndex);
            Specs.WriteSketch(Rom, RomData.MONSTER_SKETCH, MonsterRageSketchIndex);
            Specs.WriteControl(Rom, RomData.MONSTER_CONTROL, MonsterStealDropIndexCheck);
            
        }

        private void UpdateSpells()
        {
            SpellIndex = cmbSpells.SelectedIndex * 14;
            Spells.ReadSpellData(Rom, RomData.SPELL_DATA, SpellIndex, SpellDelayIndex);
            SpellDelayIndex = cmbSpells.SelectedIndex * 1;

            //Targetting byte
            if (Spells.Targetting.HasFlag(SpellTargetting.MoveCursor) == true) chkLstSpellTargetting.SetItemChecked(0, true); else chkLstSpellTargetting.SetItemChecked(0, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.OneSide) == true) chkLstSpellTargetting.SetItemChecked(1, true); else chkLstSpellTargetting.SetItemChecked(1, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.AutoBothParties) == true) chkLstSpellTargetting.SetItemChecked(2, true); else chkLstSpellTargetting.SetItemChecked(2, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.AutoOneParty) == true) chkLstSpellTargetting.SetItemChecked(3, true); else chkLstSpellTargetting.SetItemChecked(3, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.AutoConfirm) == true) chkLstSpellTargetting.SetItemChecked(4, true); else chkLstSpellTargetting.SetItemChecked(4, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.ToggleMulti) == true) chkLstSpellTargetting.SetItemChecked(5, true); else chkLstSpellTargetting.SetItemChecked(5, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.StartEnemy) == true) chkLstSpellTargetting.SetItemChecked(6, true); else chkLstSpellTargetting.SetItemChecked(6, false);
            if (Spells.Targetting.HasFlag(SpellTargetting.RandomSelect) == true) chkLstSpellTargetting.SetItemChecked(7, true); else chkLstSpellTargetting.SetItemChecked(7, false);
            //Elemental properties
            if (Spells.ElementProps.HasFlag(SpellElement.Fire) == true) chkLstSpellElement.SetItemChecked(0, true); else chkLstSpellElement.SetItemChecked(0, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Ice) == true) chkLstSpellElement.SetItemChecked(1, true); else chkLstSpellElement.SetItemChecked(1, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Thunder) == true) chkLstSpellElement.SetItemChecked(2, true); else chkLstSpellElement.SetItemChecked(2, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Poison) == true) chkLstSpellElement.SetItemChecked(3, true); else chkLstSpellElement.SetItemChecked(3, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Wind) == true) chkLstSpellElement.SetItemChecked(4, true); else chkLstSpellElement.SetItemChecked(4, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Holy) == true) chkLstSpellElement.SetItemChecked(5, true); else chkLstSpellElement.SetItemChecked(5, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Earth) == true) chkLstSpellElement.SetItemChecked(6, true); else chkLstSpellElement.SetItemChecked(6, false);
            if (Spells.ElementProps.HasFlag(SpellElement.Water) == true) chkLstSpellElement.SetItemChecked(7, true); else chkLstSpellElement.SetItemChecked(7, false);
            //Special 1
            if (Spells.Special1.HasFlag(SpellSpecial1.PhysDamage) == true) chkLstSpellSpecial1.SetItemChecked(0, true); else chkLstSpellSpecial1.SetItemChecked(0, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.MissDeathProt) == true) chkLstSpellSpecial1.SetItemChecked(1, true); else chkLstSpellSpecial1.SetItemChecked(1, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.TargetDead) == true) chkLstSpellSpecial1.SetItemChecked(2, true); else chkLstSpellSpecial1.SetItemChecked(2, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.InvertDamage) == true) chkLstSpellSpecial1.SetItemChecked(3, true); else chkLstSpellSpecial1.SetItemChecked(3, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.RandomTarget) == true) chkLstSpellSpecial1.SetItemChecked(4, true); else chkLstSpellSpecial1.SetItemChecked(4, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.IgnoreDefense) == true) chkLstSpellSpecial1.SetItemChecked(5, true); else chkLstSpellSpecial1.SetItemChecked(5, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.NoSplit) == true) chkLstSpellSpecial1.SetItemChecked(6, true); else chkLstSpellSpecial1.SetItemChecked(6, false);
            if (Spells.Special1.HasFlag(SpellSpecial1.AbortAllies) == true) chkLstSpellSpecial1.SetItemChecked(7, true); else chkLstSpellSpecial1.SetItemChecked(7, false);
            //Misc
            if (Spells.Misc.HasFlag(SpellMisc.FieldUse) == true) chkLstSpellMisc.SetItemChecked(0, true); else chkLstSpellMisc.SetItemChecked(0, false);
            if (Spells.Misc.HasFlag(SpellMisc.NoReflect) == true) chkLstSpellMisc.SetItemChecked(1, true); else chkLstSpellMisc.SetItemChecked(1, false);
            if (Spells.Misc.HasFlag(SpellMisc.LearnIfTarget) == true) chkLstSpellMisc.SetItemChecked(2, true); else chkLstSpellMisc.SetItemChecked(2, false);
            if (Spells.Misc.HasFlag(SpellMisc.EnableRunic) == true) chkLstSpellMisc.SetItemChecked(3, true); else chkLstSpellMisc.SetItemChecked(3, false);
            if (Spells.Misc.HasFlag(SpellMisc.Unknown) == true) chkLstSpellMisc.SetItemChecked(4, true); else chkLstSpellMisc.SetItemChecked(4, false);
            if (Spells.Misc.HasFlag(SpellMisc.RetargetIfDead) == true) chkLstSpellMisc.SetItemChecked(5, true); else chkLstSpellMisc.SetItemChecked(5, false);
            if (Spells.Misc.HasFlag(SpellMisc.CasterDies) == true) chkLstSpellMisc.SetItemChecked(6, true); else chkLstSpellMisc.SetItemChecked(6, false);
            if (Spells.Misc.HasFlag(SpellMisc.AffectMP) == true) chkLstSpellMisc.SetItemChecked(7, true); else chkLstSpellMisc.SetItemChecked(7, false);
            //Special 2
            if (Spells.Special2.HasFlag(SpellSpecial2.Restore) == true) chkLstSpellSpecial2.SetItemChecked(0, true); else chkLstSpellSpecial2.SetItemChecked(0, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.Absorb) == true) chkLstSpellSpecial2.SetItemChecked(1, true); else chkLstSpellSpecial2.SetItemChecked(1, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.RemoveStatus) == true) chkLstSpellSpecial2.SetItemChecked(2, true); else chkLstSpellSpecial2.SetItemChecked(2, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.ToggleStatus) == true) chkLstSpellSpecial2.SetItemChecked(3, true); else chkLstSpellSpecial2.SetItemChecked(3, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.StaminaDefense) == true) chkLstSpellSpecial2.SetItemChecked(4, true); else chkLstSpellSpecial2.SetItemChecked(4, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.NoEvade) == true) chkLstSpellSpecial2.SetItemChecked(5, true); else chkLstSpellSpecial2.SetItemChecked(5, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.SuccessMult) == true) chkLstSpellSpecial2.SetItemChecked(6, true); else chkLstSpellSpecial2.SetItemChecked(6, false);
            if (Spells.Special2.HasFlag(SpellSpecial2.Fractional) == true) chkLstSpellSpecial2.SetItemChecked(7, true); else chkLstSpellSpecial2.SetItemChecked(7, false);
            //MP Cost
            numMPCost.Value = Spells.MPCost;
            //Spell Power
            numSpellPower.Value = Spells.Power;
            //Special 3
            if (Spells.Special3.HasFlag(SpellSpecial3.MissProtStatus) == true) chkLstSpellSpecial3.SetItemChecked(0, true); else chkLstSpellSpecial3.SetItemChecked(0, false);
            if (Spells.Special3.HasFlag(SpellSpecial3.TextIfHits) == true) chkLstSpellSpecial3.SetItemChecked(1, true); else chkLstSpellSpecial3.SetItemChecked(1, false);
            if (Spells.Special3.HasFlag(SpellSpecial3.ReplaceWithVitality) == true) chkLstSpellSpecial3.SetItemChecked(2, true); else chkLstSpellSpecial3.SetItemChecked(2, false);
            if (Spells.Special3.HasFlag(SpellSpecial3.UnknownA) == true) chkLstSpellSpecial3.SetItemChecked(3, true); else chkLstSpellSpecial3.SetItemChecked(3, false);
            if (Spells.Special3.HasFlag(SpellSpecial3.UnknownB) == true) chkLstSpellSpecial3.SetItemChecked(4, true); else chkLstSpellSpecial3.SetItemChecked(4, false);
            if (Spells.Special3.HasFlag(SpellSpecial3.UnknownC) == true) chkLstSpellSpecial3.SetItemChecked(5, true); else chkLstSpellSpecial3.SetItemChecked(5, false);
            if (Spells.Special3.HasFlag(SpellSpecial3.UnknownD) == true) chkLstSpellSpecial3.SetItemChecked(6, true); else chkLstSpellSpecial3.SetItemChecked(6, false);
            if (Spells.Special3.HasFlag(SpellSpecial3.HalfITD) == true) chkLstSpellSpecial3.SetItemChecked(7, true); else chkLstSpellSpecial3.SetItemChecked(7, false);
            //Success Rate
            numSuccessRate.Value = Spells.Success;
            //Special Effect
            
            //Status toggles
            //1
            if (Spells.Status.HasFlag(SpellStatus.Darkness) == true) chkLstSpellStatus1.SetItemChecked(0, true); else chkLstSpellStatus1.SetItemChecked(0, false);
            if (Spells.Status.HasFlag(SpellStatus.Zombie) == true) chkLstSpellStatus1.SetItemChecked(1, true); else chkLstSpellStatus1.SetItemChecked(1, false);
            if (Spells.Status.HasFlag(SpellStatus.Poison) == true) chkLstSpellStatus1.SetItemChecked(2, true); else chkLstSpellStatus1.SetItemChecked(2, false);
            if (Spells.Status.HasFlag(SpellStatus.Magitek) == true) chkLstSpellStatus1.SetItemChecked(3, true); else chkLstSpellStatus1.SetItemChecked(3, false);
            if (Spells.Status.HasFlag(SpellStatus.Clear) == true) chkLstSpellStatus1.SetItemChecked(4, true); else chkLstSpellStatus1.SetItemChecked(4, false);
            if (Spells.Status.HasFlag(SpellStatus.Imp) == true) chkLstSpellStatus1.SetItemChecked(5, true); else chkLstSpellStatus1.SetItemChecked(5, false);
            if (Spells.Status.HasFlag(SpellStatus.Petrify) == true) chkLstSpellStatus1.SetItemChecked(6, true); else chkLstSpellStatus1.SetItemChecked(6, false);
            if (Spells.Status.HasFlag(SpellStatus.Death) == true) chkLstSpellStatus1.SetItemChecked(7, true); else chkLstSpellStatus1.SetItemChecked(7, false);
            //2
            if (Spells.Status.HasFlag(SpellStatus.Doomed) == true) chkLstSpellStatus2.SetItemChecked(0, true); else chkLstSpellStatus2.SetItemChecked(0, false);
            if (Spells.Status.HasFlag(SpellStatus.Critical) == true) chkLstSpellStatus2.SetItemChecked(1, true); else chkLstSpellStatus2.SetItemChecked(1, false);
            if (Spells.Status.HasFlag(SpellStatus.Blink) == true) chkLstSpellStatus2.SetItemChecked(2, true); else chkLstSpellStatus2.SetItemChecked(2, false);
            if (Spells.Status.HasFlag(SpellStatus.Silence) == true) chkLstSpellStatus2.SetItemChecked(3, true); else chkLstSpellStatus2.SetItemChecked(3, false);
            if (Spells.Status.HasFlag(SpellStatus.Berserk) == true) chkLstSpellStatus2.SetItemChecked(4, true); else chkLstSpellStatus2.SetItemChecked(4, false);
            if (Spells.Status.HasFlag(SpellStatus.Confuse) == true) chkLstSpellStatus2.SetItemChecked(5, true); else chkLstSpellStatus2.SetItemChecked(5, false);
            if (Spells.Status.HasFlag(SpellStatus.Sap) == true) chkLstSpellStatus2.SetItemChecked(6, true); else chkLstSpellStatus2.SetItemChecked(6, false);
            if (Spells.Status.HasFlag(SpellStatus.Sleep) == true) chkLstSpellStatus2.SetItemChecked(7, true); else chkLstSpellStatus2.SetItemChecked(7, false);
            //3
            if (Spells.Status.HasFlag(SpellStatus.Dance) == true) chkLstSpellStatus3.SetItemChecked(0, true); else chkLstSpellStatus3.SetItemChecked(0, false);
            if (Spells.Status.HasFlag(SpellStatus.Regen) == true) chkLstSpellStatus3.SetItemChecked(1, true); else chkLstSpellStatus3.SetItemChecked(1, false);
            if (Spells.Status.HasFlag(SpellStatus.Slow) == true) chkLstSpellStatus3.SetItemChecked(2, true); else chkLstSpellStatus3.SetItemChecked(2, false);
            if (Spells.Status.HasFlag(SpellStatus.Haste) == true) chkLstSpellStatus3.SetItemChecked(3, true); else chkLstSpellStatus3.SetItemChecked(3, false);
            if (Spells.Status.HasFlag(SpellStatus.Stop) == true) chkLstSpellStatus3.SetItemChecked(4, true); else chkLstSpellStatus3.SetItemChecked(4, false);
            if (Spells.Status.HasFlag(SpellStatus.Shell) == true) chkLstSpellStatus3.SetItemChecked(5, true); else chkLstSpellStatus3.SetItemChecked(5, false);
            if (Spells.Status.HasFlag(SpellStatus.Protect) == true) chkLstSpellStatus3.SetItemChecked(6, true); else chkLstSpellStatus3.SetItemChecked(6, false);
            if (Spells.Status.HasFlag(SpellStatus.Reflect) == true) chkLstSpellStatus3.SetItemChecked(7, true); else chkLstSpellStatus3.SetItemChecked(7, false);
            //4
            if (Spells.Status.HasFlag(SpellStatus.Rage) == true) chkLstSpellStatus4.SetItemChecked(0, true); else chkLstSpellStatus4.SetItemChecked(0, false);
            if (Spells.Status.HasFlag(SpellStatus.Freeze) == true) chkLstSpellStatus4.SetItemChecked(1, true); else chkLstSpellStatus4.SetItemChecked(1, false);
            if (Spells.Status.HasFlag(SpellStatus.Reraise) == true) chkLstSpellStatus4.SetItemChecked(2, true); else chkLstSpellStatus4.SetItemChecked(2, false);
            if (Spells.Status.HasFlag(SpellStatus.Trance) == true) chkLstSpellStatus4.SetItemChecked(3, true); else chkLstSpellStatus4.SetItemChecked(3, false);
            if (Spells.Status.HasFlag(SpellStatus.Chanting) == true) chkLstSpellStatus4.SetItemChecked(4, true); else chkLstSpellStatus4.SetItemChecked(4, false);
            if (Spells.Status.HasFlag(SpellStatus.Disappear) == true) chkLstSpellStatus4.SetItemChecked(5, true); else chkLstSpellStatus4.SetItemChecked(5, false);
            if (Spells.Status.HasFlag(SpellStatus.DogBlock) == true) chkLstSpellStatus4.SetItemChecked(6, true); else chkLstSpellStatus4.SetItemChecked(6, false);
            if (Spells.Status.HasFlag(SpellStatus.Float) == true) chkLstSpellStatus4.SetItemChecked(7, true); else chkLstSpellStatus4.SetItemChecked(7, false);

            numSpellDelay.Value = Spells.SpellDelay;
            
        }

        private void SaveSpells()
        {
            SpellIndex = cmbSpells.SelectedIndex * 14;
            //Targetting
            if (chkLstSpellTargetting.GetItemChecked(0)) Spells.Targetting |= SpellTargetting.MoveCursor; else Spells.Targetting &= ~SpellTargetting.MoveCursor;
            if (chkLstSpellTargetting.GetItemChecked(1)) Spells.Targetting |= SpellTargetting.OneSide; else Spells.Targetting &= ~SpellTargetting.OneSide;
            if (chkLstSpellTargetting.GetItemChecked(2)) Spells.Targetting |= SpellTargetting.AutoBothParties; else Spells.Targetting &= ~SpellTargetting.AutoBothParties;
            if (chkLstSpellTargetting.GetItemChecked(3)) Spells.Targetting |= SpellTargetting.AutoOneParty; else Spells.Targetting &= ~SpellTargetting.AutoOneParty;
            if (chkLstSpellTargetting.GetItemChecked(4)) Spells.Targetting |= SpellTargetting.AutoConfirm; else Spells.Targetting &= ~SpellTargetting.AutoConfirm;
            if (chkLstSpellTargetting.GetItemChecked(5)) Spells.Targetting |= SpellTargetting.ToggleMulti; else Spells.Targetting &= ~SpellTargetting.ToggleMulti;
            if (chkLstSpellTargetting.GetItemChecked(6)) Spells.Targetting |= SpellTargetting.StartEnemy; else Spells.Targetting &= ~SpellTargetting.StartEnemy;
            if (chkLstSpellTargetting.GetItemChecked(7)) Spells.Targetting |= SpellTargetting.RandomSelect; else Spells.Targetting &= ~SpellTargetting.RandomSelect;
            //Elemental properties
            if (chkLstSpellElement.GetItemChecked(0)) Spells.ElementProps |= SpellElement.Fire; else Spells.ElementProps &= ~SpellElement.Fire;
            if (chkLstSpellElement.GetItemChecked(1)) Spells.ElementProps |= SpellElement.Ice; else Spells.ElementProps &= ~SpellElement.Ice;
            if (chkLstSpellElement.GetItemChecked(2)) Spells.ElementProps |= SpellElement.Thunder; else Spells.ElementProps &= ~SpellElement.Thunder;
            if (chkLstSpellElement.GetItemChecked(3)) Spells.ElementProps |= SpellElement.Poison; else Spells.ElementProps &= ~SpellElement.Poison;
            if (chkLstSpellElement.GetItemChecked(4)) Spells.ElementProps |= SpellElement.Wind; else Spells.ElementProps &= ~SpellElement.Wind;
            if (chkLstSpellElement.GetItemChecked(5)) Spells.ElementProps |= SpellElement.Holy; else Spells.ElementProps &= ~SpellElement.Holy;
            if (chkLstSpellElement.GetItemChecked(6)) Spells.ElementProps |= SpellElement.Earth; else Spells.ElementProps &= ~SpellElement.Earth;
            if (chkLstSpellElement.GetItemChecked(7)) Spells.ElementProps |= SpellElement.Water; else Spells.ElementProps &= ~SpellElement.Water;
            //Special 1
            if (chkLstSpellSpecial1.GetItemChecked(0)) Spells.Special1 |= SpellSpecial1.PhysDamage; else Spells.Special1 &= ~SpellSpecial1.PhysDamage;
            if (chkLstSpellSpecial1.GetItemChecked(1)) Spells.Special1 |= SpellSpecial1.MissDeathProt; else Spells.Special1 &= ~SpellSpecial1.MissDeathProt;
            if (chkLstSpellSpecial1.GetItemChecked(2)) Spells.Special1 |= SpellSpecial1.TargetDead; else Spells.Special1 &= ~SpellSpecial1.TargetDead;
            if (chkLstSpellSpecial1.GetItemChecked(3)) Spells.Special1 |= SpellSpecial1.InvertDamage; else Spells.Special1 &= ~SpellSpecial1.InvertDamage;
            if (chkLstSpellSpecial1.GetItemChecked(4)) Spells.Special1 |= SpellSpecial1.RandomTarget; else Spells.Special1 &= ~SpellSpecial1.RandomTarget;
            if (chkLstSpellSpecial1.GetItemChecked(5)) Spells.Special1 |= SpellSpecial1.IgnoreDefense; else Spells.Special1 &= ~SpellSpecial1.IgnoreDefense;
            if (chkLstSpellSpecial1.GetItemChecked(6)) Spells.Special1 |= SpellSpecial1.NoSplit; else Spells.Special1 &= ~SpellSpecial1.NoSplit;
            if (chkLstSpellSpecial1.GetItemChecked(7)) Spells.Special1 |= SpellSpecial1.AbortAllies; else Spells.Special1 &= ~SpellSpecial1.AbortAllies;
            //Misc
            if (chkLstSpellMisc.GetItemChecked(0)) Spells.Misc |= SpellMisc.FieldUse; else Spells.Misc &= ~SpellMisc.FieldUse;
            if (chkLstSpellMisc.GetItemChecked(1)) Spells.Misc |= SpellMisc.NoReflect; else Spells.Misc &= ~SpellMisc.NoReflect;
            if (chkLstSpellMisc.GetItemChecked(2)) Spells.Misc |= SpellMisc.LearnIfTarget; else Spells.Misc &= ~SpellMisc.LearnIfTarget;
            if (chkLstSpellMisc.GetItemChecked(3)) Spells.Misc |= SpellMisc.EnableRunic; else Spells.Misc &= ~SpellMisc.EnableRunic;
            if (chkLstSpellMisc.GetItemChecked(4)) Spells.Misc |= SpellMisc.Unknown; else Spells.Misc &= ~SpellMisc.Unknown;
            if (chkLstSpellMisc.GetItemChecked(5)) Spells.Misc |= SpellMisc.RetargetIfDead; else Spells.Misc &= ~SpellMisc.RetargetIfDead;
            if (chkLstSpellMisc.GetItemChecked(6)) Spells.Misc |= SpellMisc.CasterDies; else Spells.Misc &= ~SpellMisc.CasterDies;
            if (chkLstSpellMisc.GetItemChecked(7)) Spells.Misc |= SpellMisc.AffectMP; else Spells.Misc &= ~SpellMisc.AffectMP;
            //Special 2
            if (chkLstSpellSpecial2.GetItemChecked(0)) Spells.Special2 |= SpellSpecial2.Restore; else Spells.Special2 &= ~SpellSpecial2.Restore;
            if (chkLstSpellSpecial2.GetItemChecked(1)) Spells.Special2 |= SpellSpecial2.Absorb; else Spells.Special2 &= ~SpellSpecial2.Absorb;
            if (chkLstSpellSpecial2.GetItemChecked(2)) Spells.Special2 |= SpellSpecial2.RemoveStatus; else Spells.Special2 &= ~SpellSpecial2.RemoveStatus;
            if (chkLstSpellSpecial2.GetItemChecked(3)) Spells.Special2 |= SpellSpecial2.ToggleStatus; else Spells.Special2 &= ~SpellSpecial2.ToggleStatus;
            if (chkLstSpellSpecial2.GetItemChecked(4)) Spells.Special2 |= SpellSpecial2.StaminaDefense; else Spells.Special2 &= ~SpellSpecial2.StaminaDefense;
            if (chkLstSpellSpecial2.GetItemChecked(5)) Spells.Special2 |= SpellSpecial2.NoEvade; else Spells.Special2 &= ~SpellSpecial2.NoEvade;
            if (chkLstSpellSpecial2.GetItemChecked(6)) Spells.Special2 |= SpellSpecial2.SuccessMult; else Spells.Special2 &= ~SpellSpecial2.SuccessMult;
            if (chkLstSpellSpecial2.GetItemChecked(7)) Spells.Special2 |= SpellSpecial2.Fractional; else Spells.Special2 &= ~SpellSpecial2.Fractional;
            //MP Cost
            Spells.MPCost = (byte)numMPCost.Value;
            //Spell Power
            Spells.Power = (byte)numSpellPower.Value;
            //Special 3
            if (chkLstSpellSpecial3.GetItemChecked(0)) Spells.Special3 |= SpellSpecial3.MissProtStatus; else Spells.Special3 &= ~SpellSpecial3.MissProtStatus;
            if (chkLstSpellSpecial3.GetItemChecked(1)) Spells.Special3 |= SpellSpecial3.TextIfHits; else Spells.Special3 &= ~SpellSpecial3.TextIfHits;
            if (chkLstSpellSpecial3.GetItemChecked(2)) Spells.Special3 |= SpellSpecial3.ReplaceWithVitality; else Spells.Special3 &= ~SpellSpecial3.ReplaceWithVitality;
            if (chkLstSpellSpecial3.GetItemChecked(3)) Spells.Special3 |= SpellSpecial3.UnknownA; else Spells.Special3 &= ~SpellSpecial3.UnknownA;
            if (chkLstSpellSpecial3.GetItemChecked(4)) Spells.Special3 |= SpellSpecial3.UnknownB; else Spells.Special3 &= ~SpellSpecial3.UnknownB;
            if (chkLstSpellSpecial3.GetItemChecked(5)) Spells.Special3 |= SpellSpecial3.UnknownC; else Spells.Special3 &= ~SpellSpecial3.UnknownC;
            if (chkLstSpellSpecial3.GetItemChecked(6)) Spells.Special3 |= SpellSpecial3.UnknownD; else Spells.Special3 &= ~SpellSpecial3.UnknownD;
            if (chkLstSpellSpecial3.GetItemChecked(7)) Spells.Special3 |= SpellSpecial3.HalfITD; else Spells.Special3 &= ~SpellSpecial3.HalfITD;
            //Success Rate
            Spells.Success = (byte)numSuccessRate.Value;
            //TODO: Special Effects
            //Status toggles
            //1
            if (chkLstSpellStatus1.GetItemChecked(0)) Spells.Status |= SpellStatus.Darkness; else Spells.Status &= ~SpellStatus.Darkness;
            if (chkLstSpellStatus1.GetItemChecked(1)) Spells.Status |= SpellStatus.Zombie; else Spells.Status &= ~SpellStatus.Zombie;
            if (chkLstSpellStatus1.GetItemChecked(2)) Spells.Status |= SpellStatus.Poison; else Spells.Status &= ~SpellStatus.Poison;
            if (chkLstSpellStatus1.GetItemChecked(3)) Spells.Status |= SpellStatus.Magitek; else Spells.Status &= ~SpellStatus.Magitek;
            if (chkLstSpellStatus1.GetItemChecked(4)) Spells.Status |= SpellStatus.Clear; else Spells.Status &= ~SpellStatus.Clear;
            if (chkLstSpellStatus1.GetItemChecked(5)) Spells.Status |= SpellStatus.Imp; else Spells.Status &= ~SpellStatus.Imp;
            if (chkLstSpellStatus1.GetItemChecked(6)) Spells.Status |= SpellStatus.Petrify; else Spells.Status &= ~SpellStatus.Petrify;
            if (chkLstSpellStatus1.GetItemChecked(7)) Spells.Status |= SpellStatus.Death; else Spells.Status &= ~SpellStatus.Death;
            //2
            if (chkLstSpellStatus2.GetItemChecked(0)) Spells.Status |= SpellStatus.Doomed; else Spells.Status &= ~SpellStatus.Doomed;
            if (chkLstSpellStatus2.GetItemChecked(1)) Spells.Status |= SpellStatus.Critical; else Spells.Status &= ~SpellStatus.Critical;
            if (chkLstSpellStatus2.GetItemChecked(2)) Spells.Status |= SpellStatus.Blink; else Spells.Status &= ~SpellStatus.Blink;
            if (chkLstSpellStatus2.GetItemChecked(3)) Spells.Status |= SpellStatus.Silence; else Spells.Status &= ~SpellStatus.Silence;
            if (chkLstSpellStatus2.GetItemChecked(4)) Spells.Status |= SpellStatus.Berserk; else Spells.Status &= ~SpellStatus.Berserk;
            if (chkLstSpellStatus2.GetItemChecked(5)) Spells.Status |= SpellStatus.Confuse; else Spells.Status &= ~SpellStatus.Confuse;
            if (chkLstSpellStatus2.GetItemChecked(6)) Spells.Status |= SpellStatus.Sap; else Spells.Status &= ~SpellStatus.Sap;
            if (chkLstSpellStatus2.GetItemChecked(7)) Spells.Status |= SpellStatus.Sleep; else Spells.Status &= ~SpellStatus.Sleep;
            //3
            if (chkLstSpellStatus3.GetItemChecked(0)) Spells.Status |= SpellStatus.Dance; else Spells.Status &= ~SpellStatus.Dance;
            if (chkLstSpellStatus3.GetItemChecked(1)) Spells.Status |= SpellStatus.Regen; else Spells.Status &= ~SpellStatus.Regen;
            if (chkLstSpellStatus3.GetItemChecked(2)) Spells.Status |= SpellStatus.Slow; else Spells.Status &= ~SpellStatus.Slow;
            if (chkLstSpellStatus3.GetItemChecked(3)) Spells.Status |= SpellStatus.Haste; else Spells.Status &= ~SpellStatus.Haste;
            if (chkLstSpellStatus3.GetItemChecked(4)) Spells.Status |= SpellStatus.Stop; else Spells.Status &= ~SpellStatus.Stop;
            if (chkLstSpellStatus3.GetItemChecked(5)) Spells.Status |= SpellStatus.Shell; else Spells.Status &= ~SpellStatus.Shell;
            if (chkLstSpellStatus3.GetItemChecked(6)) Spells.Status |= SpellStatus.Protect; else Spells.Status &= ~SpellStatus.Protect;
            if (chkLstSpellStatus3.GetItemChecked(7)) Spells.Status |= SpellStatus.Reflect; else Spells.Status &= ~SpellStatus.Reflect;
            //4
            if (chkLstSpellStatus4.GetItemChecked(0)) Spells.Status |= SpellStatus.Rage; else Spells.Status &= ~SpellStatus.Rage;
            if (chkLstSpellStatus4.GetItemChecked(1)) Spells.Status |= SpellStatus.Freeze; else Spells.Status &= ~SpellStatus.Freeze;
            if (chkLstSpellStatus4.GetItemChecked(2)) Spells.Status |= SpellStatus.Reraise; else Spells.Status &= ~SpellStatus.Reraise;
            if (chkLstSpellStatus4.GetItemChecked(3)) Spells.Status |= SpellStatus.Trance; else Spells.Status &= ~SpellStatus.Trance;
            if (chkLstSpellStatus4.GetItemChecked(4)) Spells.Status |= SpellStatus.Chanting; else Spells.Status &= ~SpellStatus.Chanting;
            if (chkLstSpellStatus4.GetItemChecked(5)) Spells.Status |= SpellStatus.Disappear; else Spells.Status &= ~SpellStatus.Disappear;
            if (chkLstSpellStatus4.GetItemChecked(6)) Spells.Status |= SpellStatus.DogBlock; else Spells.Status &= ~SpellStatus.DogBlock;
            if (chkLstSpellStatus4.GetItemChecked(7)) Spells.Status |= SpellStatus.Float; else Spells.Status &= ~SpellStatus.Float;
            Spells.WriteSpellData(Rom, RomData.SPELL_DATA, SpellIndex);
        }

        private int SumOfStatValues(int FileOffset, int CalcValue)
        {
            statSum = 0;
            for (int i = 0; i < CalcValue; i++)
            {
                statSum += Rom.Read8(FileOffset + i);
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
            integrity_check = Rom.Read8(integrity_check_value);
            if (integrity_check != 234)
            {
                return false;
            }
            else return true;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Removes gameArray data and closes editor.
            Rom.Close();
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
            if (cmbMonsters.SelectedIndex > 255)
            {
                lblRage.Visible = false; cmbRage1.Visible = false; cmbRage2.Visible = false;
            }
            else
            {
                lblRage.Visible = true; cmbRage1.Visible = true; cmbRage2.Visible = true;
            }
            UpdateMonsterStats();
        }

        private void cmbDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMonsterStats();
        }

        private void numMonsterIndex_ValueChanged(object sender, EventArgs e)
        {
            if (numMonsterIndex.Value <= 383)
            {
                int i;
                i = (int)numMonsterIndex.Value;
                cmbMonsters.SelectedIndex = i;
            }
            else numMonsterIndex.Value = 383;
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

        private void cmbSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            numSpellIndex.Value = cmbSpells.SelectedIndex;
            UpdateSpells();
        }

        private void numSpellIndex_ValueChanged(object sender, EventArgs e)
        {
            if (numSpellIndex.Value <= 255)
            {
                int i;
                i = (int)numSpellIndex.Value;
                cmbSpells.SelectedIndex = i;
            }
            else numSpellIndex.Value = 255;
            UpdateSpells();

        }

        private void btnSpellsOkay_Click(object sender, EventArgs e)
        {
            SaveSpells();
        }

        private void btnSpellsCancel_Click(object sender, EventArgs e)
        {
            UpdateSpells();
        }

        private void btnEspersAll_Click(object sender, EventArgs e)
        {
            chkLstEsperChars.SetItemChecked(0, true);
            chkLstEsperChars.SetItemChecked(1, true);
            chkLstEsperChars.SetItemChecked(2, true);
            chkLstEsperChars.SetItemChecked(3, true);
            chkLstEsperChars.SetItemChecked(4, true);
            chkLstEsperChars.SetItemChecked(5, true);
            chkLstEsperChars.SetItemChecked(6, true);
            chkLstEsperChars.SetItemChecked(7, true);
            chkLstEsperChars.SetItemChecked(8, true);
            chkLstEsperChars.SetItemChecked(9, true);
            chkLstEsperChars.SetItemChecked(10, true);
            chkLstEsperChars.SetItemChecked(11, true);
            chkLstEsperChars.SetItemChecked(12, true);
            chkLstEsperChars.SetItemChecked(13, true);
        }

        private void btnEspersNone_Click(object sender, EventArgs e)
        {
            chkLstEsperChars.SetItemChecked(0, false);
            chkLstEsperChars.SetItemChecked(1, false);
            chkLstEsperChars.SetItemChecked(2, false);
            chkLstEsperChars.SetItemChecked(3, false);
            chkLstEsperChars.SetItemChecked(4, false);
            chkLstEsperChars.SetItemChecked(5, false);
            chkLstEsperChars.SetItemChecked(6, false);
            chkLstEsperChars.SetItemChecked(7, false);
            chkLstEsperChars.SetItemChecked(8, false);
            chkLstEsperChars.SetItemChecked(9, false);
            chkLstEsperChars.SetItemChecked(10, false);
            chkLstEsperChars.SetItemChecked(11, false);
            chkLstEsperChars.SetItemChecked(12, false);
            chkLstEsperChars.SetItemChecked(13, false);
        }

        private void DisplaySpellNames()
        {
            string[] SpellColl = SpellList.ReadSpellNames(Rom).ToArray();
            cmbSpells.Items.AddRange(SpellColl);
            cmbSpells.SelectedIndex = 0;
            cmbControl1.Items.AddRange(SpellColl);
            cmbControl2.Items.AddRange(SpellColl);
            cmbControl3.Items.AddRange(SpellColl);
            cmbControl4.Items.AddRange(SpellColl);
            cmbSketch1.Items.AddRange(SpellColl);
            cmbSketch2.Items.AddRange(SpellColl);
            cmbRage1.Items.AddRange(SpellColl);
            cmbRage2.Items.AddRange(SpellColl);
            cmbNatMag1.Items.AddRange(SpellColl);
            cmbNatMag2.Items.AddRange(SpellColl);
            cmbNatMag3.Items.AddRange(SpellColl);
            cmbNatMag4.Items.AddRange(SpellColl);
            cmbNatMag5.Items.AddRange(SpellColl);
            cmbNatMag6.Items.AddRange(SpellColl);
            cmbNatMag7.Items.AddRange(SpellColl);
            cmbNatMag8.Items.AddRange(SpellColl);
            cmbNatMag9.Items.AddRange(SpellColl);
            cmbNatMag10.Items.AddRange(SpellColl);
            cmbNatMag11.Items.AddRange(SpellColl);
            cmbNatMag12.Items.AddRange(SpellColl);
            cmbNatMag13.Items.AddRange(SpellColl);
            cmbNatMag14.Items.AddRange(SpellColl);
            cmbNatMag15.Items.AddRange(SpellColl);
            cmbNatMag16.Items.AddRange(SpellColl);
            cmbEsperMagic1.Items.AddRange(SpellColl);
            cmbEsperMagic2.Items.AddRange(SpellColl);
            cmbEsperMagic3.Items.AddRange(SpellColl);
            cmbEsperMagic4.Items.AddRange(SpellColl);
            cmbEsperMagic5.Items.AddRange(SpellColl);
            cmbEsperMagic6.Items.AddRange(SpellColl);
            cmbEsperMagic7.Items.AddRange(SpellColl);
            cmbEsperMagic8.Items.AddRange(SpellColl);
            cmbEsperMagic9.Items.AddRange(SpellColl);
            cmbEsperMagic10.Items.AddRange(SpellColl);
            //SpellList.ReadSpellNames(Rom).ForEach(el => cmbSpells.Items.AddRange(SpellList.ReadSpellNames(Rom).ToArray()));
        }

        private void DisplayEnemyNames()
        {
            string[] EnemyColl = EnemyList.ReadEnemyNames(Rom).ToArray();
            cmbMonsters.Items.AddRange(EnemyColl);
            cmbMonsters.SelectedIndex = 0;
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
