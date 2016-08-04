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
            if (rom.IsOpen())
            {
                saveAsToolStripMenuItem.Enabled = true;
                saveROMToolStripMenuItem1.Enabled = true;
            }

            UpdateActorsElements();
            cmbActors.SelectedIndex = 0;
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
            rom.Write8(byte.Parse(txtStrLv0.Text),RomData.CHARDATA + LevelCheck + ActorCheckStats);
            rom.Write8(byte.Parse(txtStrLv1.Text));
            rom.Write8(byte.Parse(txtStrLv2.Text));
            rom.Write8(byte.Parse(txtStrLv3.Text));
            rom.Write8(byte.Parse(txtStrLv4.Text));
            rom.Write8(byte.Parse(txtStrLv5.Text));
            rom.Write8(byte.Parse(txtStrLv6.Text));
            rom.Write8(byte.Parse(txtStrLv7.Text));
            rom.Write8(byte.Parse(txtStrLv8.Text));
            rom.Write8(byte.Parse(txtStrLv9.Text));
            rom.Write8(byte.Parse(txtAgiLv0.Text),RomData.CHARDATA + LevelCheck + ActorCheckStats + (100 * 15));
            rom.Write8(byte.Parse(txtAgiLv1.Text));
            rom.Write8(byte.Parse(txtAgiLv2.Text));
            rom.Write8(byte.Parse(txtAgiLv3.Text));
            rom.Write8(byte.Parse(txtAgiLv4.Text));
            rom.Write8(byte.Parse(txtAgiLv5.Text));
            rom.Write8(byte.Parse(txtAgiLv6.Text));
            rom.Write8(byte.Parse(txtAgiLv7.Text));
            rom.Write8(byte.Parse(txtAgiLv8.Text));
            rom.Write8(byte.Parse(txtAgiLv9.Text));
            rom.Write8(byte.Parse(txtStaLv0.Text),RomData.CHARDATA + LevelCheck + ActorCheckStats + (200 * 15));
            rom.Write8(byte.Parse(txtStaLv1.Text));
            rom.Write8(byte.Parse(txtStaLv2.Text));
            rom.Write8(byte.Parse(txtStaLv3.Text));
            rom.Write8(byte.Parse(txtStaLv4.Text));
            rom.Write8(byte.Parse(txtStaLv5.Text));
            rom.Write8(byte.Parse(txtStaLv6.Text));
            rom.Write8(byte.Parse(txtStaLv7.Text));
            rom.Write8(byte.Parse(txtStaLv8.Text));
            rom.Write8(byte.Parse(txtStaLv9.Text));
            rom.Write8(byte.Parse(txtMagLv0.Text),RomData.CHARDATA + LevelCheck + ActorCheckStats + (300 * 15));
            rom.Write8(byte.Parse(txtMagLv1.Text));
            rom.Write8(byte.Parse(txtMagLv2.Text));
            rom.Write8(byte.Parse(txtMagLv3.Text));
            rom.Write8(byte.Parse(txtMagLv4.Text));
            rom.Write8(byte.Parse(txtMagLv5.Text));
            rom.Write8(byte.Parse(txtMagLv6.Text));
            rom.Write8(byte.Parse(txtMagLv7.Text));
            rom.Write8(byte.Parse(txtMagLv8.Text));
            rom.Write8(byte.Parse(txtMagLv9.Text));
            rom.Write8(byte.Parse(txtHPLv0.Text),RomData.CHARDATA + LevelCheck + ActorCheckStats + (400 * 15));
            rom.Write8(byte.Parse(txtHPLv1.Text));
            rom.Write8(byte.Parse(txtHPLv2.Text));
            rom.Write8(byte.Parse(txtHPLv3.Text));
            rom.Write8(byte.Parse(txtHPLv4.Text));
            rom.Write8(byte.Parse(txtHPLv5.Text));
            rom.Write8(byte.Parse(txtHPLv6.Text));
            rom.Write8(byte.Parse(txtHPLv7.Text));
            rom.Write8(byte.Parse(txtHPLv8.Text));
            rom.Write8(byte.Parse(txtHPLv9.Text));
            rom.Write8(byte.Parse(txtMPLv0.Text),RomData.CHARDATA + LevelCheck + ActorCheckStats + (500 * 15));
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
                rom.Write8(Convert.ToByte(cmbNatMag1.SelectedIndex), RomData.NATURALMAGICDATA + ActorCheckNaturalMagic);
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

            txtStrLv0.Text = rom.Read8(RomData.CHARDATA + LevelCheck + ActorCheckStats).ToString();
            txtStrLv1.Text = rom.Read8().ToString();
            txtStrLv2.Text = rom.Read8().ToString();
            txtStrLv3.Text = rom.Read8().ToString();
            txtStrLv4.Text = rom.Read8().ToString();
            txtStrLv5.Text = rom.Read8().ToString();
            txtStrLv6.Text = rom.Read8().ToString();
            txtStrLv7.Text = rom.Read8().ToString();
            txtStrLv8.Text = rom.Read8().ToString();
            txtStrLv9.Text = rom.Read8().ToString();
            txtAgiLv0.Text = rom.Read8(RomData.CHARDATA + LevelCheck + ActorCheckStats + (100 * 15)).ToString();
            txtAgiLv1.Text = rom.Read8().ToString();
            txtAgiLv2.Text = rom.Read8().ToString();
            txtAgiLv3.Text = rom.Read8().ToString();
            txtAgiLv4.Text = rom.Read8().ToString();
            txtAgiLv5.Text = rom.Read8().ToString();
            txtAgiLv6.Text = rom.Read8().ToString();
            txtAgiLv7.Text = rom.Read8().ToString();
            txtAgiLv8.Text = rom.Read8().ToString();
            txtAgiLv9.Text = rom.Read8().ToString();
            txtStaLv0.Text = rom.Read8(RomData.CHARDATA + LevelCheck + ActorCheckStats + (200 * 15)).ToString();
            txtStaLv1.Text = rom.Read8().ToString();
            txtStaLv2.Text = rom.Read8().ToString();
            txtStaLv3.Text = rom.Read8().ToString();
            txtStaLv4.Text = rom.Read8().ToString();
            txtStaLv5.Text = rom.Read8().ToString();
            txtStaLv6.Text = rom.Read8().ToString();
            txtStaLv7.Text = rom.Read8().ToString();
            txtStaLv8.Text = rom.Read8().ToString();
            txtStaLv9.Text = rom.Read8().ToString();
            txtMagLv0.Text = rom.Read8(RomData.CHARDATA + LevelCheck + ActorCheckStats + (300 * 15)).ToString();
            txtMagLv1.Text = rom.Read8().ToString();
            txtMagLv2.Text = rom.Read8().ToString();
            txtMagLv3.Text = rom.Read8().ToString();
            txtMagLv4.Text = rom.Read8().ToString();
            txtMagLv5.Text = rom.Read8().ToString();
            txtMagLv6.Text = rom.Read8().ToString();
            txtMagLv7.Text = rom.Read8().ToString();
            txtMagLv8.Text = rom.Read8().ToString();
            txtMagLv9.Text = rom.Read8().ToString();
            txtHPLv0.Text = rom.Read8(RomData.CHARDATA + LevelCheck + ActorCheckStats + (400 * 15)).ToString();
            txtHPLv1.Text = rom.Read8().ToString();
            txtHPLv2.Text = rom.Read8().ToString();
            txtHPLv3.Text = rom.Read8().ToString();
            txtHPLv4.Text = rom.Read8().ToString();
            txtHPLv5.Text = rom.Read8().ToString();
            txtHPLv6.Text = rom.Read8().ToString();
            txtHPLv7.Text = rom.Read8().ToString();
            txtHPLv8.Text = rom.Read8().ToString();
            txtHPLv9.Text = rom.Read8().ToString();
            txtMPLv0.Text = rom.Read8(RomData.CHARDATA + LevelCheck + ActorCheckStats + (500 * 15)).ToString();
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
            txtStrLv0_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats, 11).ToString();
            txtStrLv1_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats, 21).ToString();
            txtStrLv2_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats, 31).ToString();
            txtStrLv3_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats, 41).ToString();
            txtStrLv4_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats, 51).ToString();
            txtStrLv5_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats, 61).ToString();
            txtStrLv6_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats, 71).ToString();
            txtStrLv7_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats, 81).ToString();
            txtStrLv8_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats, 91).ToString();
            txtStrLv9_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats, 100).ToString();
            txtAgiLv0_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (100 * 15), 11).ToString();
            txtAgiLv1_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (100 * 15), 21).ToString();
            txtAgiLv2_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (100 * 15), 31).ToString();
            txtAgiLv3_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (100 * 15), 41).ToString();
            txtAgiLv4_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (100 * 15), 51).ToString();
            txtAgiLv5_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (100 * 15), 61).ToString();
            txtAgiLv6_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (100 * 15), 71).ToString();
            txtAgiLv7_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (100 * 15), 81).ToString();
            txtAgiLv8_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (100 * 15), 91).ToString();
            txtAgiLv9_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (100 * 15), 100).ToString();
            txtStaLv0_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (200 * 15), 11).ToString();
            txtStaLv1_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (200 * 15), 21).ToString();
            txtStaLv2_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (200 * 15), 31).ToString();
            txtStaLv3_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (200 * 15), 41).ToString();
            txtStaLv4_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (200 * 15), 51).ToString();
            txtStaLv5_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (200 * 15), 61).ToString();
            txtStaLv6_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (200 * 15), 71).ToString();
            txtStaLv7_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (200 * 15), 81).ToString();
            txtStaLv8_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (200 * 15), 91).ToString();
            txtStaLv9_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (200 * 15), 100).ToString();
            txtMagLv0_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (300 * 15), 11).ToString();
            txtMagLv1_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (300 * 15), 21).ToString();
            txtMagLv2_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (300 * 15), 31).ToString();
            txtMagLv3_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (300 * 15), 41).ToString();
            txtMagLv4_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (300 * 15), 51).ToString();
            txtMagLv5_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (300 * 15), 61).ToString();
            txtMagLv6_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (300 * 15), 71).ToString();
            txtMagLv7_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (300 * 15), 81).ToString();
            txtMagLv8_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (300 * 15), 91).ToString();
            txtMagLv9_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (300 * 15), 100).ToString();
            txtHPLv0_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (400 * 15), 11).ToString();
            txtHPLv1_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (400 * 15), 21).ToString();
            txtHPLv2_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (400 * 15), 31).ToString();
            txtHPLv3_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (400 * 15), 41).ToString();
            txtHPLv4_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (400 * 15), 51).ToString();
            txtHPLv5_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (400 * 15), 61).ToString();
            txtHPLv6_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (400 * 15), 71).ToString();
            txtHPLv7_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (400 * 15), 81).ToString();
            txtHPLv8_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (400 * 15), 91).ToString();
            txtHPLv9_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (400 * 15), 100).ToString();
            txtMPLv0_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (500 * 15), 11).ToString();
            txtMPLv1_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (500 * 15), 21).ToString();
            txtMPLv2_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (500 * 15), 31).ToString();
            txtMPLv3_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (500 * 15), 41).ToString();
            txtMPLv4_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (500 * 15), 51).ToString();
            txtMPLv5_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (500 * 15), 61).ToString();
            txtMPLv6_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (500 * 15), 71).ToString();
            txtMPLv7_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (500 * 15), 81).ToString();
            txtMPLv8_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (500 * 15), 91).ToString();
            txtMPLv9_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheckStats + (500 * 15), 100).ToString();


            //Display Natural Magic
            {
                ActorCheckNaturalMagic = cmbActors.SelectedIndex * 32;
                cmbNatMag1.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic);
                cmbNatMag2.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 2);
                cmbNatMag3.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 4);
                cmbNatMag4.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 6);
                cmbNatMag5.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 8);
                cmbNatMag6.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 10);
                cmbNatMag7.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 12);
                cmbNatMag8.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 14);
                cmbNatMag9.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 16);
                cmbNatMag10.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 18);
                cmbNatMag11.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 20);
                cmbNatMag12.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 22);
                cmbNatMag13.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 24);
                cmbNatMag14.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 26);
                cmbNatMag15.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 28);
                cmbNatMag16.SelectedIndex = rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 30);

                //Display Natural Magic Levels
                numNatMag1.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 1));
                numNatMag2.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 3));
                numNatMag3.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 5));
                numNatMag4.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 7));
                numNatMag5.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 9));
                numNatMag6.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 11));
                numNatMag7.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 13));
                numNatMag8.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 15));
                numNatMag9.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 17));
                numNatMag10.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 19));
                numNatMag11.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 21));
                numNatMag12.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 23));
                numNatMag13.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 25));
                numNatMag14.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 27));
                numNatMag15.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 29));
                numNatMag16.Value = CheckNatMagicLevelRange(rom.Read8(RomData.NATURALMAGICDATA + ActorCheckNaturalMagic + 31));
            }
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
        /*private bool txtKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                return true;
            }
        }

        private bool txtStrLv0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                return true;
            }
        }*/

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
            //UpdateActorsElements();
        }

        private void cmbNatMag1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //UpdateActorsElements();
        }
    }
}
