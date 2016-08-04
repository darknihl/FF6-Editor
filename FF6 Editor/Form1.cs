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
        int ActorCheck;
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
            rom.Write8(byte.Parse(txtStrLv0.Text),RomData.CHARDATA + LevelCheck + ActorCheck);
            rom.Write8(byte.Parse(txtStrLv1.Text));
            rom.Write8(byte.Parse(txtStrLv2.Text));
            rom.Write8(byte.Parse(txtStrLv3.Text));
            rom.Write8(byte.Parse(txtStrLv4.Text));
            rom.Write8(byte.Parse(txtStrLv5.Text));
            rom.Write8(byte.Parse(txtStrLv6.Text));
            rom.Write8(byte.Parse(txtStrLv7.Text));
            rom.Write8(byte.Parse(txtStrLv8.Text));
            rom.Write8(byte.Parse(txtStrLv9.Text));
            rom.Write8(byte.Parse(txtAgiLv0.Text),RomData.CHARDATA + LevelCheck + ActorCheck + (100 * 15));
            rom.Write8(byte.Parse(txtAgiLv1.Text));
            rom.Write8(byte.Parse(txtAgiLv2.Text));
            rom.Write8(byte.Parse(txtAgiLv3.Text));
            rom.Write8(byte.Parse(txtAgiLv4.Text));
            rom.Write8(byte.Parse(txtAgiLv5.Text));
            rom.Write8(byte.Parse(txtAgiLv6.Text));
            rom.Write8(byte.Parse(txtAgiLv7.Text));
            rom.Write8(byte.Parse(txtAgiLv8.Text));
            rom.Write8(byte.Parse(txtAgiLv9.Text));
            rom.Write8(byte.Parse(txtStaLv0.Text),RomData.CHARDATA + LevelCheck + ActorCheck + (200 * 15));
            rom.Write8(byte.Parse(txtStaLv1.Text));
            rom.Write8(byte.Parse(txtStaLv2.Text));
            rom.Write8(byte.Parse(txtStaLv3.Text));
            rom.Write8(byte.Parse(txtStaLv4.Text));
            rom.Write8(byte.Parse(txtStaLv5.Text));
            rom.Write8(byte.Parse(txtStaLv6.Text));
            rom.Write8(byte.Parse(txtStaLv7.Text));
            rom.Write8(byte.Parse(txtStaLv8.Text));
            rom.Write8(byte.Parse(txtStaLv9.Text));
            rom.Write8(byte.Parse(txtMagLv0.Text),RomData.CHARDATA + LevelCheck + ActorCheck + (300 * 15));
            rom.Write8(byte.Parse(txtMagLv1.Text));
            rom.Write8(byte.Parse(txtMagLv2.Text));
            rom.Write8(byte.Parse(txtMagLv3.Text));
            rom.Write8(byte.Parse(txtMagLv4.Text));
            rom.Write8(byte.Parse(txtMagLv5.Text));
            rom.Write8(byte.Parse(txtMagLv6.Text));
            rom.Write8(byte.Parse(txtMagLv7.Text));
            rom.Write8(byte.Parse(txtMagLv8.Text));
            rom.Write8(byte.Parse(txtMagLv9.Text));
            rom.Write8(byte.Parse(txtHPLv0.Text),RomData.CHARDATA + LevelCheck + ActorCheck + (400 * 15));
            rom.Write8(byte.Parse(txtHPLv1.Text));
            rom.Write8(byte.Parse(txtHPLv2.Text));
            rom.Write8(byte.Parse(txtHPLv3.Text));
            rom.Write8(byte.Parse(txtHPLv4.Text));
            rom.Write8(byte.Parse(txtHPLv5.Text));
            rom.Write8(byte.Parse(txtHPLv6.Text));
            rom.Write8(byte.Parse(txtHPLv7.Text));
            rom.Write8(byte.Parse(txtHPLv8.Text));
            rom.Write8(byte.Parse(txtHPLv9.Text));
            rom.Write8(byte.Parse(txtMPLv0.Text),RomData.CHARDATA + LevelCheck + ActorCheck + (500 * 15));
            rom.Write8(byte.Parse(txtMPLv1.Text));
            rom.Write8(byte.Parse(txtMPLv2.Text));
            rom.Write8(byte.Parse(txtMPLv3.Text));
            rom.Write8(byte.Parse(txtMPLv4.Text));
            rom.Write8(byte.Parse(txtMPLv5.Text));
            rom.Write8(byte.Parse(txtMPLv6.Text));
            rom.Write8(byte.Parse(txtMPLv7.Text));
            rom.Write8(byte.Parse(txtMPLv8.Text));
            rom.Write8(byte.Parse(txtMPLv9.Text));

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
            ActorCheck = cmbActors.SelectedIndex * 100;

            txtStrLv0.Text = rom.Read8(RomData.CHARDATA + LevelCheck + ActorCheck).ToString();
            txtStrLv1.Text = rom.Read8().ToString();
            txtStrLv2.Text = rom.Read8().ToString();
            txtStrLv3.Text = rom.Read8().ToString();
            txtStrLv4.Text = rom.Read8().ToString();
            txtStrLv5.Text = rom.Read8().ToString();
            txtStrLv6.Text = rom.Read8().ToString();
            txtStrLv7.Text = rom.Read8().ToString();
            txtStrLv8.Text = rom.Read8().ToString();
            txtStrLv9.Text = rom.Read8().ToString();
            txtAgiLv0.Text = rom.Read8(RomData.CHARDATA + LevelCheck + ActorCheck + (100 * 15)).ToString();
            txtAgiLv1.Text = rom.Read8().ToString();
            txtAgiLv2.Text = rom.Read8().ToString();
            txtAgiLv3.Text = rom.Read8().ToString();
            txtAgiLv4.Text = rom.Read8().ToString();
            txtAgiLv5.Text = rom.Read8().ToString();
            txtAgiLv6.Text = rom.Read8().ToString();
            txtAgiLv7.Text = rom.Read8().ToString();
            txtAgiLv8.Text = rom.Read8().ToString();
            txtAgiLv9.Text = rom.Read8().ToString();
            txtStaLv0.Text = rom.Read8(RomData.CHARDATA + LevelCheck + ActorCheck + (200 * 15)).ToString();
            txtStaLv1.Text = rom.Read8().ToString();
            txtStaLv2.Text = rom.Read8().ToString();
            txtStaLv3.Text = rom.Read8().ToString();
            txtStaLv4.Text = rom.Read8().ToString();
            txtStaLv5.Text = rom.Read8().ToString();
            txtStaLv6.Text = rom.Read8().ToString();
            txtStaLv7.Text = rom.Read8().ToString();
            txtStaLv8.Text = rom.Read8().ToString();
            txtStaLv9.Text = rom.Read8().ToString();
            txtMagLv0.Text = rom.Read8(RomData.CHARDATA + LevelCheck + ActorCheck + (300 * 15)).ToString();
            txtMagLv1.Text = rom.Read8().ToString();
            txtMagLv2.Text = rom.Read8().ToString();
            txtMagLv3.Text = rom.Read8().ToString();
            txtMagLv4.Text = rom.Read8().ToString();
            txtMagLv5.Text = rom.Read8().ToString();
            txtMagLv6.Text = rom.Read8().ToString();
            txtMagLv7.Text = rom.Read8().ToString();
            txtMagLv8.Text = rom.Read8().ToString();
            txtMagLv9.Text = rom.Read8().ToString();
            txtHPLv0.Text = rom.Read8(RomData.CHARDATA + LevelCheck + ActorCheck + (400 * 15)).ToString();
            txtHPLv1.Text = rom.Read8().ToString();
            txtHPLv2.Text = rom.Read8().ToString();
            txtHPLv3.Text = rom.Read8().ToString();
            txtHPLv4.Text = rom.Read8().ToString();
            txtHPLv5.Text = rom.Read8().ToString();
            txtHPLv6.Text = rom.Read8().ToString();
            txtHPLv7.Text = rom.Read8().ToString();
            txtHPLv8.Text = rom.Read8().ToString();
            txtHPLv9.Text = rom.Read8().ToString();
            txtMPLv0.Text = rom.Read8(RomData.CHARDATA + LevelCheck + ActorCheck + (500 * 15)).ToString();
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
            txtStrLv0_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck, 11).ToString();
            txtStrLv1_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck, 21).ToString();
            txtStrLv2_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck, 31).ToString();
            txtStrLv3_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck, 41).ToString();
            txtStrLv4_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck, 51).ToString();
            txtStrLv5_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck, 61).ToString();
            txtStrLv6_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck, 71).ToString();
            txtStrLv7_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck, 81).ToString();
            txtStrLv8_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck, 91).ToString();
            txtStrLv9_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck, 100).ToString();
            txtAgiLv0_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (100 * 15), 11).ToString();
            txtAgiLv1_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (100 * 15), 21).ToString();
            txtAgiLv2_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (100 * 15), 31).ToString();
            txtAgiLv3_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (100 * 15), 41).ToString();
            txtAgiLv4_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (100 * 15), 51).ToString();
            txtAgiLv5_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (100 * 15), 61).ToString();
            txtAgiLv6_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (100 * 15), 71).ToString();
            txtAgiLv7_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (100 * 15), 81).ToString();
            txtAgiLv8_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (100 * 15), 91).ToString();
            txtAgiLv9_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (100 * 15), 100).ToString();
            txtStaLv0_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (200 * 15), 11).ToString();
            txtStaLv1_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (200 * 15), 21).ToString();
            txtStaLv2_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (200 * 15), 31).ToString();
            txtStaLv3_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (200 * 15), 41).ToString();
            txtStaLv4_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (200 * 15), 51).ToString();
            txtStaLv5_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (200 * 15), 61).ToString();
            txtStaLv6_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (200 * 15), 71).ToString();
            txtStaLv7_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (200 * 15), 81).ToString();
            txtStaLv8_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (200 * 15), 91).ToString();
            txtStaLv9_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (200 * 15), 100).ToString();
            txtMagLv0_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (300 * 15), 11).ToString();
            txtMagLv1_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (300 * 15), 21).ToString();
            txtMagLv2_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (300 * 15), 31).ToString();
            txtMagLv3_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (300 * 15), 41).ToString();
            txtMagLv4_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (300 * 15), 51).ToString();
            txtMagLv5_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (300 * 15), 61).ToString();
            txtMagLv6_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (300 * 15), 71).ToString();
            txtMagLv7_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (300 * 15), 81).ToString();
            txtMagLv8_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (300 * 15), 91).ToString();
            txtMagLv9_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (300 * 15), 100).ToString();
            txtHPLv0_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (400 * 15), 11).ToString();
            txtHPLv1_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (400 * 15), 21).ToString();
            txtHPLv2_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (400 * 15), 31).ToString();
            txtHPLv3_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (400 * 15), 41).ToString();
            txtHPLv4_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (400 * 15), 51).ToString();
            txtHPLv5_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (400 * 15), 61).ToString();
            txtHPLv6_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (400 * 15), 71).ToString();
            txtHPLv7_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (400 * 15), 81).ToString();
            txtHPLv8_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (400 * 15), 91).ToString();
            txtHPLv9_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (400 * 15), 100).ToString();
            txtMPLv0_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (500 * 15), 11).ToString();
            txtMPLv1_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (500 * 15), 21).ToString();
            txtMPLv2_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (500 * 15), 31).ToString();
            txtMPLv3_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (500 * 15), 41).ToString();
            txtMPLv4_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (500 * 15), 51).ToString();
            txtMPLv5_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (500 * 15), 61).ToString();
            txtMPLv6_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (500 * 15), 71).ToString();
            txtMPLv7_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (500 * 15), 81).ToString();
            txtMPLv8_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (500 * 15), 91).ToString();
            txtMPLv9_Add.Text = SumOfStatValues(RomData.CHARDATA + ActorCheck + (500 * 15), 100).ToString();

            //Display Natural Magic
            cmbNatMag1.Text = rom.Read8(RomData.NATURALMAGICDATA).ToString();
        }

        private int SumOfStatValues(int FileOffset, int calcValue)
        {
            statSum = 0;
            for (int i = 0; i < calcValue; i++)
            {
                statSum += rom.Read8(FileOffset + i);
            }
            return statSum;
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
            UpdateActorsElements();
        }

        private void cmbNatMag1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateActorsElements();
        }
    }
}
