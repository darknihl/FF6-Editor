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
using RomFileIO;
using RomData;

namespace FF6_Editor
{
    public partial class Form1 : Form
    {
        byte[] gameArray;
        int levelCheck = 0;
        int actorCheck = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Disable File Saving until a file actually exists, to reduce potential problems.
            if (gameArray == null)
            {
                saveROMToolStripMenuItem.Enabled = false;
                saveROMToolStripMenuItem.Available = false;
            }
        }

        private void loadROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog ofd = new OpenFileDialog();                                      //Setting the dialog up

                ofd.Filter = "SNES ROM file|FF6MTEST_editor_test.sfc";                          //File type filter
                ofd.Title = "Load ROM";                                                         //Title for dialog
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                RomFileIO.LoadRom(ofd.FileName);

            }
            
            if (gameArray != null)
            {
                cmbActors.SelectedIndex = 0;

                if (numLevel.Value == 0)
                {
                    levelCheck = 0;
                    lblLevel0.Text = "0";
                    lblLevel1.Text = "1";
                    lblLevel2.Text = "2";
                    lblLevel3.Text = "3";
                    lblLevel4.Text = "4";
                    lblLevel5.Text = "5";
                    lblLevel6.Text = "6";
                    lblLevel7.Text = "7";
                    lblLevel8.Text = "8";
                    lblLevel9.Text = "9";
                }

                else if (numLevel.Value == 10)
                {
                    levelCheck = 10;
                    lblLevel0.Text = "10";
                    lblLevel1.Text = "11";
                    lblLevel2.Text = "12";
                    lblLevel3.Text = "13";
                    lblLevel4.Text = "14";
                    lblLevel5.Text = "15";
                    lblLevel6.Text = "16";
                    lblLevel7.Text = "17";
                    lblLevel8.Text = "18";
                    lblLevel9.Text = "19";
                }

                else if (numLevel.Value == 20)
                {
                    levelCheck = 20;
                    lblLevel0.Text = "20";
                    lblLevel1.Text = "21";
                    lblLevel2.Text = "22";
                    lblLevel3.Text = "23";
                    lblLevel4.Text = "24";
                    lblLevel5.Text = "25";
                    lblLevel6.Text = "26";
                    lblLevel7.Text = "27";
                    lblLevel8.Text = "28";
                    lblLevel9.Text = "29";
                }

                else if (numLevel.Value == 30)
                {
                    levelCheck = 30;
                    lblLevel0.Text = "30";
                    lblLevel1.Text = "31";
                    lblLevel2.Text = "32";
                    lblLevel3.Text = "33";
                    lblLevel4.Text = "34";
                    lblLevel5.Text = "35";
                    lblLevel6.Text = "36";
                    lblLevel7.Text = "37";
                    lblLevel8.Text = "38";
                    lblLevel9.Text = "39";
                }

                else if (numLevel.Value == 40)
                {
                    levelCheck = 40;
                    lblLevel0.Text = "40";
                    lblLevel1.Text = "41";
                    lblLevel2.Text = "42";
                    lblLevel3.Text = "43";
                    lblLevel4.Text = "44";
                    lblLevel5.Text = "45";
                    lblLevel6.Text = "46";
                    lblLevel7.Text = "47";
                    lblLevel8.Text = "48";
                    lblLevel9.Text = "49";
                }

                else if (numLevel.Value == 50)
                {
                    levelCheck = 50;
                    lblLevel0.Text = "50";
                    lblLevel1.Text = "51";
                    lblLevel2.Text = "52";
                    lblLevel3.Text = "53";
                    lblLevel4.Text = "54";
                    lblLevel5.Text = "55";
                    lblLevel6.Text = "56";
                    lblLevel7.Text = "57";
                    lblLevel8.Text = "58";
                    lblLevel9.Text = "59";
                }

                else if (numLevel.Value == 60)
                {
                    levelCheck = 60;
                    lblLevel0.Text = "60";
                    lblLevel1.Text = "61";
                    lblLevel2.Text = "62";
                    lblLevel3.Text = "63";
                    lblLevel4.Text = "64";
                    lblLevel5.Text = "65";
                    lblLevel6.Text = "66";
                    lblLevel7.Text = "67";
                    lblLevel8.Text = "68";
                    lblLevel9.Text = "69";
                }

                else if (numLevel.Value == 70)
                {
                    levelCheck = 70;
                    lblLevel0.Text = "70";
                    lblLevel1.Text = "71";
                    lblLevel2.Text = "72";
                    lblLevel3.Text = "73";
                    lblLevel4.Text = "74";
                    lblLevel5.Text = "75";
                    lblLevel6.Text = "76";
                    lblLevel7.Text = "77";
                    lblLevel8.Text = "78";
                    lblLevel9.Text = "79";
                }

                else if (numLevel.Value == 80)
                {
                    levelCheck = 80;
                    lblLevel0.Text = "80";
                    lblLevel1.Text = "81";
                    lblLevel2.Text = "82";
                    lblLevel3.Text = "83";
                    lblLevel4.Text = "84";
                    lblLevel5.Text = "85";
                    lblLevel6.Text = "86";
                    lblLevel7.Text = "87";
                    lblLevel8.Text = "88";
                    lblLevel9.Text = "89";
                }

                else if (numLevel.Value == 90)
                {
                    levelCheck = 90;
                    lblLevel0.Text = "90";
                    lblLevel1.Text = "91";
                    lblLevel2.Text = "92";
                    lblLevel3.Text = "93";
                    lblLevel4.Text = "94";
                    lblLevel5.Text = "95";
                    lblLevel6.Text = "96";
                    lblLevel7.Text = "97";
                    lblLevel8.Text = "98";
                    lblLevel9.Text = "99";
                }
                txtStrLv0.Text = gameArray[0x3301f4 + levelCheck + actorCheck].ToString();
                txtStrLv1.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 1].ToString();
                txtStrLv2.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 2].ToString();
                txtStrLv3.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 3].ToString();
                txtStrLv4.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 4].ToString();
                txtStrLv5.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 5].ToString();
                txtStrLv6.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 6].ToString();
                txtStrLv7.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 7].ToString();
                txtStrLv8.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 8].ToString();
                txtStrLv9.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 9].ToString();
                txtAgiLv0.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15)].ToString();
                txtAgiLv1.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 1].ToString();
                txtAgiLv2.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 2].ToString();
                txtAgiLv3.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 3].ToString();
                txtAgiLv4.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 4].ToString();
                txtAgiLv5.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 5].ToString();
                txtAgiLv6.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 6].ToString();
                txtAgiLv7.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 7].ToString();
                txtAgiLv8.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 8].ToString();
                txtAgiLv9.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 9].ToString();
                txtStaLv0.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15)].ToString();
                txtStaLv1.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 1].ToString();
                txtStaLv2.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 2].ToString();
                txtStaLv3.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 3].ToString();
                txtStaLv4.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 4].ToString();
                txtStaLv5.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 5].ToString();
                txtStaLv6.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 6].ToString();
                txtStaLv7.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 7].ToString();
                txtStaLv8.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 8].ToString();
                txtStaLv9.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 9].ToString();
                txtMagLv0.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15)].ToString();
                txtMagLv1.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 1].ToString();
                txtMagLv2.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 2].ToString();
                txtMagLv3.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 3].ToString();
                txtMagLv4.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 4].ToString();
                txtMagLv5.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 5].ToString();
                txtMagLv6.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 6].ToString();
                txtMagLv7.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 7].ToString();
                txtMagLv8.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 8].ToString();
                txtMagLv9.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 9].ToString();
            }
        }


        private void saveROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameArray != null)
            {
                //Open SaveFileDialog for file saving.
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "SNES ROM file|*.smc;*.swc;*.sfc";
                sfd.Title = "Save ROM";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Save the file to disk
                        //Checks to make sure a file actually has been loaded.
                        if (gameArray != null)
                        {
                            File.WriteAllBytes(sfd.FileName, gameArray);
                        }
                        else
                        {
                            MessageBox.Show("No ROM is loaded.", "No ROM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception innerException)
                    {
                        ApplicationException ae = new ApplicationException("Exception", innerException);
                    }

                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Removes gameArray data and closes editor.
            gameArray = null;
            Application.Exit();
        }

        private void tabActorsTerra_Click(object sender, EventArgs e)
        {

        }

        private void lblPlus_Click(object sender, EventArgs e)
        {

        }

        private void numLevel_ValueChanged_1(object sender, EventArgs e)
        {
            if (gameArray != null)
            {

                if (numLevel.Value == 0)
                {
                    levelCheck = 0;
                    lblLevel0.Text = "0";
                    lblLevel1.Text = "1";
                    lblLevel2.Text = "2";
                    lblLevel3.Text = "3";
                    lblLevel4.Text = "4";
                    lblLevel5.Text = "5";
                    lblLevel6.Text = "6";
                    lblLevel7.Text = "7";
                    lblLevel8.Text = "8";
                    lblLevel9.Text = "9";
                }

                else if (numLevel.Value == 10)
                {
                    levelCheck = 10;
                    lblLevel0.Text = "10";
                    lblLevel1.Text = "11";
                    lblLevel2.Text = "12";
                    lblLevel3.Text = "13";
                    lblLevel4.Text = "14";
                    lblLevel5.Text = "15";
                    lblLevel6.Text = "16";
                    lblLevel7.Text = "17";
                    lblLevel8.Text = "18";
                    lblLevel9.Text = "19";
                }

                else if (numLevel.Value == 20)
                {
                    levelCheck = 20;
                    lblLevel0.Text = "20";
                    lblLevel1.Text = "21";
                    lblLevel2.Text = "22";
                    lblLevel3.Text = "23";
                    lblLevel4.Text = "24";
                    lblLevel5.Text = "25";
                    lblLevel6.Text = "26";
                    lblLevel7.Text = "27";
                    lblLevel8.Text = "28";
                    lblLevel9.Text = "29";
                }

                else if (numLevel.Value == 30)
                {
                    levelCheck = 30;
                    lblLevel0.Text = "30";
                    lblLevel1.Text = "31";
                    lblLevel2.Text = "32";
                    lblLevel3.Text = "33";
                    lblLevel4.Text = "34";
                    lblLevel5.Text = "35";
                    lblLevel6.Text = "36";
                    lblLevel7.Text = "37";
                    lblLevel8.Text = "38";
                    lblLevel9.Text = "39";
                }

                else if (numLevel.Value == 40)
                {
                    levelCheck = 40;
                    lblLevel0.Text = "40";
                    lblLevel1.Text = "41";
                    lblLevel2.Text = "42";
                    lblLevel3.Text = "43";
                    lblLevel4.Text = "44";
                    lblLevel5.Text = "45";
                    lblLevel6.Text = "46";
                    lblLevel7.Text = "47";
                    lblLevel8.Text = "48";
                    lblLevel9.Text = "49";
                }

                else if (numLevel.Value == 50)
                {
                    levelCheck = 50;
                    lblLevel0.Text = "50";
                    lblLevel1.Text = "51";
                    lblLevel2.Text = "52";
                    lblLevel3.Text = "53";
                    lblLevel4.Text = "54";
                    lblLevel5.Text = "55";
                    lblLevel6.Text = "56";
                    lblLevel7.Text = "57";
                    lblLevel8.Text = "58";
                    lblLevel9.Text = "59";
                }

                else if (numLevel.Value == 60)
                {
                    levelCheck = 60;
                    lblLevel0.Text = "60";
                    lblLevel1.Text = "61";
                    lblLevel2.Text = "62";
                    lblLevel3.Text = "63";
                    lblLevel4.Text = "64";
                    lblLevel5.Text = "65";
                    lblLevel6.Text = "66";
                    lblLevel7.Text = "67";
                    lblLevel8.Text = "68";
                    lblLevel9.Text = "69";
                }

                else if (numLevel.Value == 70)
                {
                    levelCheck = 70;
                    lblLevel0.Text = "70";
                    lblLevel1.Text = "71";
                    lblLevel2.Text = "72";
                    lblLevel3.Text = "73";
                    lblLevel4.Text = "74";
                    lblLevel5.Text = "75";
                    lblLevel6.Text = "76";
                    lblLevel7.Text = "77";
                    lblLevel8.Text = "78";
                    lblLevel9.Text = "79";
                }

                else if (numLevel.Value == 80)
                {
                    levelCheck = 80;
                    lblLevel0.Text = "80";
                    lblLevel1.Text = "81";
                    lblLevel2.Text = "82";
                    lblLevel3.Text = "83";
                    lblLevel4.Text = "84";
                    lblLevel5.Text = "85";
                    lblLevel6.Text = "86";
                    lblLevel7.Text = "87";
                    lblLevel8.Text = "88";
                    lblLevel9.Text = "89";
                }

                else if (numLevel.Value == 90)
                {
                    levelCheck = 90;
                    lblLevel0.Text = "90";
                    lblLevel1.Text = "91";
                    lblLevel2.Text = "92";
                    lblLevel3.Text = "93";
                    lblLevel4.Text = "94";
                    lblLevel5.Text = "95";
                    lblLevel6.Text = "96";
                    lblLevel7.Text = "97";
                    lblLevel8.Text = "98";
                    lblLevel9.Text = "99";
                }

                txtStrLv0.Text = gameArray[0x3301f4 + levelCheck + actorCheck].ToString();
                txtStrLv1.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 1].ToString();
                txtStrLv2.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 2].ToString();
                txtStrLv3.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 3].ToString();
                txtStrLv4.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 4].ToString();
                txtStrLv5.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 5].ToString();
                txtStrLv6.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 6].ToString();
                txtStrLv7.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 7].ToString();
                txtStrLv8.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 8].ToString();
                txtStrLv9.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 9].ToString();
                txtAgiLv0.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15)].ToString();
                txtAgiLv1.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 1].ToString();
                txtAgiLv2.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 2].ToString();
                txtAgiLv3.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 3].ToString();
                txtAgiLv4.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 4].ToString();
                txtAgiLv5.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 5].ToString();
                txtAgiLv6.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 6].ToString();
                txtAgiLv7.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 7].ToString();
                txtAgiLv8.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 8].ToString();
                txtAgiLv9.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 9].ToString();
                txtStaLv0.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15)].ToString();
                txtStaLv1.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 1].ToString();
                txtStaLv2.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 2].ToString();
                txtStaLv3.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 3].ToString();
                txtStaLv4.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 4].ToString();
                txtStaLv5.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 5].ToString();
                txtStaLv6.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 6].ToString();
                txtStaLv7.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 7].ToString();
                txtStaLv8.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 8].ToString();
                txtStaLv9.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 9].ToString();
                txtMagLv0.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15)].ToString();
                txtMagLv1.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 1].ToString();
                txtMagLv2.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 2].ToString();
                txtMagLv3.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 3].ToString();
                txtMagLv4.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 4].ToString();
                txtMagLv5.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 5].ToString();
                txtMagLv6.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 6].ToString();
                txtMagLv7.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 7].ToString();
                txtMagLv8.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 8].ToString();
                txtMagLv9.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 9].ToString();
            }
        }

        private void cmbActors_SelectedIndexChanged(object sender, EventArgs e)
        {
            actorCheck = cmbActors.SelectedIndex*100;
                            if (numLevel.Value == 0)
                {
                    levelCheck = 0;
                    lblLevel0.Text = "0";
                    lblLevel1.Text = "1";
                    lblLevel2.Text = "2";
                    lblLevel3.Text = "3";
                    lblLevel4.Text = "4";
                    lblLevel5.Text = "5";
                    lblLevel6.Text = "6";
                    lblLevel7.Text = "7";
                    lblLevel8.Text = "8";
                    lblLevel9.Text = "9";
                }

                else if (numLevel.Value == 10)
                {
                    levelCheck = 10;
                    lblLevel0.Text = "10";
                    lblLevel1.Text = "11";
                    lblLevel2.Text = "12";
                    lblLevel3.Text = "13";
                    lblLevel4.Text = "14";
                    lblLevel5.Text = "15";
                    lblLevel6.Text = "16";
                    lblLevel7.Text = "17";
                    lblLevel8.Text = "18";
                    lblLevel9.Text = "19";
                }

                else if (numLevel.Value == 20)
                {
                    levelCheck = 20;
                    lblLevel0.Text = "20";
                    lblLevel1.Text = "21";
                    lblLevel2.Text = "22";
                    lblLevel3.Text = "23";
                    lblLevel4.Text = "24";
                    lblLevel5.Text = "25";
                    lblLevel6.Text = "26";
                    lblLevel7.Text = "27";
                    lblLevel8.Text = "28";
                    lblLevel9.Text = "29";
                }

                else if (numLevel.Value == 30)
                {
                    levelCheck = 30;
                    lblLevel0.Text = "30";
                    lblLevel1.Text = "31";
                    lblLevel2.Text = "32";
                    lblLevel3.Text = "33";
                    lblLevel4.Text = "34";
                    lblLevel5.Text = "35";
                    lblLevel6.Text = "36";
                    lblLevel7.Text = "37";
                    lblLevel8.Text = "38";
                    lblLevel9.Text = "39";
                }

                else if (numLevel.Value == 40)
                {
                    levelCheck = 40;
                    lblLevel0.Text = "40";
                    lblLevel1.Text = "41";
                    lblLevel2.Text = "42";
                    lblLevel3.Text = "43";
                    lblLevel4.Text = "44";
                    lblLevel5.Text = "45";
                    lblLevel6.Text = "46";
                    lblLevel7.Text = "47";
                    lblLevel8.Text = "48";
                    lblLevel9.Text = "49";
                }

                else if (numLevel.Value == 50)
                {
                    levelCheck = 50;
                    lblLevel0.Text = "50";
                    lblLevel1.Text = "51";
                    lblLevel2.Text = "52";
                    lblLevel3.Text = "53";
                    lblLevel4.Text = "54";
                    lblLevel5.Text = "55";
                    lblLevel6.Text = "56";
                    lblLevel7.Text = "57";
                    lblLevel8.Text = "58";
                    lblLevel9.Text = "59";
                }

                else if (numLevel.Value == 60)
                {
                    levelCheck = 60;
                    lblLevel0.Text = "60";
                    lblLevel1.Text = "61";
                    lblLevel2.Text = "62";
                    lblLevel3.Text = "63";
                    lblLevel4.Text = "64";
                    lblLevel5.Text = "65";
                    lblLevel6.Text = "66";
                    lblLevel7.Text = "67";
                    lblLevel8.Text = "68";
                    lblLevel9.Text = "69";
                }

                else if (numLevel.Value == 70)
                {
                    levelCheck = 70;
                    lblLevel0.Text = "70";
                    lblLevel1.Text = "71";
                    lblLevel2.Text = "72";
                    lblLevel3.Text = "73";
                    lblLevel4.Text = "74";
                    lblLevel5.Text = "75";
                    lblLevel6.Text = "76";
                    lblLevel7.Text = "77";
                    lblLevel8.Text = "78";
                    lblLevel9.Text = "79";
                }

                else if (numLevel.Value == 80)
                {
                    levelCheck = 80;
                    lblLevel0.Text = "80";
                    lblLevel1.Text = "81";
                    lblLevel2.Text = "82";
                    lblLevel3.Text = "83";
                    lblLevel4.Text = "84";
                    lblLevel5.Text = "85";
                    lblLevel6.Text = "86";
                    lblLevel7.Text = "87";
                    lblLevel8.Text = "88";
                    lblLevel9.Text = "89";
                }

                else if (numLevel.Value == 90)
                {
                    levelCheck = 90;
                    lblLevel0.Text = "90";
                    lblLevel1.Text = "91";
                    lblLevel2.Text = "92";
                    lblLevel3.Text = "93";
                    lblLevel4.Text = "94";
                    lblLevel5.Text = "95";
                    lblLevel6.Text = "96";
                    lblLevel7.Text = "97";
                    lblLevel8.Text = "98";
                    lblLevel9.Text = "99";
                }

                txtStrLv0.Text = gameArray[0x3301f4 + levelCheck + actorCheck].ToString();
                txtStrLv1.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 1].ToString();
                txtStrLv2.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 2].ToString();
                txtStrLv3.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 3].ToString();
                txtStrLv4.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 4].ToString();
                txtStrLv5.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 5].ToString();
                txtStrLv6.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 6].ToString();
                txtStrLv7.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 7].ToString();
                txtStrLv8.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 8].ToString();
                txtStrLv9.Text = gameArray[0x3301f4 + levelCheck + actorCheck + 9].ToString();
                txtAgiLv0.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15)].ToString();
                txtAgiLv1.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 1].ToString();
                txtAgiLv2.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 2].ToString();
                txtAgiLv3.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 3].ToString();
                txtAgiLv4.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 4].ToString();
                txtAgiLv5.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 5].ToString();
                txtAgiLv6.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 6].ToString();
                txtAgiLv7.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 7].ToString();
                txtAgiLv8.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 8].ToString();
                txtAgiLv9.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (100 * 15) + 9].ToString();
                txtStaLv0.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15)].ToString();
                txtStaLv1.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 1].ToString();
                txtStaLv2.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 2].ToString();
                txtStaLv3.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 3].ToString();
                txtStaLv4.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 4].ToString();
                txtStaLv5.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 5].ToString();
                txtStaLv6.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 6].ToString();
                txtStaLv7.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 7].ToString();
                txtStaLv8.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 8].ToString();
                txtStaLv9.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (200 * 15) + 9].ToString();
                txtMagLv0.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15)].ToString();
                txtMagLv1.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 1].ToString();
                txtMagLv2.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 2].ToString();
                txtMagLv3.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 3].ToString();
                txtMagLv4.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 4].ToString();
                txtMagLv5.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 5].ToString();
                txtMagLv6.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 6].ToString();
                txtMagLv7.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 7].ToString();
                txtMagLv8.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 8].ToString();
                txtMagLv9.Text = gameArray[0x3301f4 + levelCheck + actorCheck + (300 * 15) + 9].ToString();
            

        }
    }
}
