using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DukeArt
{
    public partial class frmMain : Form
    {
        ArtData artData;
        Thread dataThread;

        string palettePath;
        string artPath;
        string bmpPath;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cboAnimationType.SelectedIndex = 0;
        }

        private void LoadArt()
        {
            SetStatusAndMessage("Busy", "Loading ART file.");
            DisableControls();
            artData = new ArtData();
            artData.LoadArt(palettePath, artPath);

            Invoke(new Action(() => {
                txtIndexSelector.Minimum = artData.localtilestart;
                txtIndexSelector.Maximum = artData.localtileend;
                txtIndexSelector.Value = artData.localtilestart;
            }));
            
            EnableControls();

            LoadSpriteInfo();
            SetStatusAndMessage("Ready", "ART file loaded successfully.");
        }

        private void LoadSpriteInfo()
        {
            DisableControls();

            int[] tempInfo = new int[1];
            tempInfo[0] = artData.picanm[(int)txtIndexSelector.Value - artData.localtilestart];
            BitArray allBits = new BitArray(tempInfo);

            BitArray animationBits = new BitArray(4);
            int[] animationArray = new int[1];
            animationBits[3] = allBits[27];
            animationBits[2] = allBits[26];
            animationBits[1] = allBits[25];
            animationBits[0] = allBits[24];
            animationBits.CopyTo(animationArray, 0);
            uint finalAnimationSpeed = (uint)animationArray[0];

            BitArray ycenterBits = new BitArray(8);
            sbyte[] ycenterArray = new sbyte[1];
            ycenterBits[7] = allBits[23];
            ycenterBits[6] = allBits[22];
            ycenterBits[5] = allBits[21];
            ycenterBits[4] = allBits[20];
            ycenterBits[3] = allBits[19];
            ycenterBits[2] = allBits[18];
            ycenterBits[1] = allBits[17];
            ycenterBits[0] = allBits[16];
            ycenterBits.CopyTo(ycenterArray, 0);

            BitArray xcenterBits = new BitArray(8);
            sbyte[] xcenterArray = new sbyte[1];
            xcenterBits[7] = allBits[15];
            xcenterBits[6] = allBits[14];
            xcenterBits[5] = allBits[13];
            xcenterBits[4] = allBits[12];
            xcenterBits[3] = allBits[11];
            xcenterBits[2] = allBits[10];
            xcenterBits[1] = allBits[9];
            xcenterBits[0] = allBits[8];
            xcenterBits.CopyTo(xcenterArray, 0);
            
            BitArray animTypeBits = new BitArray(2);
            int[] animTypeArray = new int[1];
            animTypeBits[1] = allBits[7];
            animTypeBits[0] = allBits[6];
            animTypeBits.CopyTo(animTypeArray, 0);

            BitArray numFramesBits = new BitArray(6);
            int[] numFramesArray = new int[1];
            numFramesBits[5] = allBits[5];
            numFramesBits[4] = allBits[4];
            numFramesBits[3] = allBits[3];
            numFramesBits[2] = allBits[2];
            numFramesBits[1] = allBits[1];
            numFramesBits[0] = allBits[0];
            numFramesBits.CopyTo(numFramesArray, 0);

            Invoke(new Action(() => {
                preview.Image = artData.bitmaps[(int)txtIndexSelector.Value - artData.localtilestart];
                txtAnimationSpeed.Text = finalAnimationSpeed.ToString();
                txtYcenter.Text = ycenterArray[0].ToString();
                txtXcenter.Text = xcenterArray[0].ToString();
                cboAnimationType.SelectedIndex = animTypeArray[0];
                txtNumFrames.Text = numFramesArray[0].ToString();
            }));

            EnableControls();
        }

        private void DisableControls()
        {
            Invoke(new Action(() => {
                grpAttributes.Enabled = false;
                txtIndexSelector.Enabled = false;
                import24bitBitmapToolStripMenuItem.Enabled = false;
            }));
        }

        private void SetStatusAndMessage(string status, string msg)
        {
            Invoke(new Action(() => {
                toolStatus.Text = status;
                toolStatusMessage.Text = msg;
            }));
        }

        private void EnableControls()
        {
            Invoke(new Action(() => {
                grpAttributes.Enabled = true;
                txtIndexSelector.Enabled = true;
                import24bitBitmapToolStripMenuItem.Enabled = true;
            }));
        }

        private int MatchToPalette(Color color)
        {
            int num1 = 0;
            int num2 = 0 + Math.Abs((int)color.R - (int)artData.palette[0].R) + Math.Abs((int)color.G - (int)artData.palette[0].G) + Math.Abs((int)color.B - (int)artData.palette[0].B);
            for (int index = 1; index < artData.palette.Count; ++index)
            {
                int num3 = 0 + Math.Abs((int)color.R - (int)artData.palette[index].R) + Math.Abs((int)color.G - (int)artData.palette[index].G) + Math.Abs((int)color.B - (int)artData.palette[index].B);
                if (num3 < num2)
                {
                    num2 = num3;
                    num1 = index;
                }
            }
            return num1;
        }

        private void LoadBitmap()
        {
            DisableControls();

            int index = (int)txtIndexSelector.Value - artData.localtilestart;

            using (BinaryReader binaryReader = new BinaryReader((Stream)File.Open(bmpPath, FileMode.Open)))
            {
                binaryReader.BaseStream.Position = 10L;
                int num1 = binaryReader.ReadInt32();
                binaryReader.BaseStream.Position = 18L;
                int length1 = binaryReader.ReadInt32();
                int length2 = binaryReader.ReadInt32();
                byte[,] numArray = new byte[length1, length2];
                binaryReader.BaseStream.Position = (long)num1;
                for (int index2 = length2 - 1; index2 >= 0; --index2)
                {
                    for (int index3 = 0; index3 < length1; ++index3)
                    {
                        int blue = (int)binaryReader.ReadByte();
                        int green = (int)binaryReader.ReadByte();
                        int red = (int)binaryReader.ReadByte();
                        numArray[index3, index2] = (byte)MatchToPalette(Color.FromArgb(red, green, blue));
                    }
                    int num2 = length1 * 3 % 4;
                    if (num2 != 0)
                    {
                        for (int index3 = 0; index3 < 4 - num2; ++index3)
                        {
                            int num3 = (int)binaryReader.ReadByte();
                        }
                    }
                }
                artData.colorData[index] = new byte[length1 * length2];
                int index4 = 0;
                for (int index2 = 0; index2 < length1; ++index2)
                {
                    for (int index3 = 0; index3 < length2; ++index3)
                    {
                        artData.colorData[index][index4] = numArray[index2, index3];
                        ++index4;
                    }
                }
                artData.tilesizex[index] = (short)length1;
                artData.tilesizey[index] = (short)length2;
            }

            Bitmap tempBmp = new Bitmap(artData.tilesizex[index], artData.tilesizey[index], PixelFormat.Format24bppRgb);
            int count = 0;
            for (int x = 0; x < artData.tilesizex[index]; x++)
            {
                for (int y = 0; y < artData.tilesizey[index]; y++)
                {
                    tempBmp.SetPixel(x, y, artData.palette[artData.colorData[index][count]]);
                    count++;
                }
            }
            artData.bitmaps[index] = tempBmp;

            EnableControls();
        }

        private void import24bitBitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "bitmap files (*.bmp)|*.bmp";
            ofd.Title = "Select the 24-bit BMP file.";
            DialogResult dResult = ofd.ShowDialog();
            if (dResult != DialogResult.OK)
                return;
            bmpPath = ofd.FileName;

            dataThread = new Thread(new ThreadStart(LoadBitmap));
            dataThread.Start();
        }

        private void txtIndexSelector_ValueChanged(object sender, EventArgs e)
        {
            dataThread = new Thread(new ThreadStart(LoadSpriteInfo));
            dataThread.Start();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "art files (*.art)|*.art";
            sfd.Title = "Select the art file to save as.";
            DialogResult dResult = sfd.ShowDialog();
            if (dResult != DialogResult.OK)
                return;
            //save = sfd.FileName;

            dataThread = new Thread(new ThreadStart(SaveArt));
            dataThread.Start();
        }

        private void SaveArt()
        {
            SetStatusAndMessage("Busy", "Saving ART file.");
            DisableControls();
            artData.SaveArt(artPath);
            EnableControls();
            SetStatusAndMessage("Ready", "ART file saved successfully.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BitArray allBits = new BitArray(32);

            int[] animSpeedInt = { int.Parse(txtAnimationSpeed.Text.Trim()) };
            BitArray animSpeedBits = new BitArray(animSpeedInt);
            allBits[27] = animSpeedBits[3];
            allBits[26] = animSpeedBits[2];
            allBits[25] = animSpeedBits[1];
            allBits[24] = animSpeedBits[0];

            int[] ycenterInt = { int.Parse(txtYcenter.Text.Trim()) };
            BitArray ycenterBits = new BitArray(ycenterInt);
            allBits[23] = ycenterBits[7];
            allBits[22] = ycenterBits[6];
            allBits[21] = ycenterBits[5];
            allBits[20] = ycenterBits[4];
            allBits[19] = ycenterBits[3];
            allBits[18] = ycenterBits[2];
            allBits[17] = ycenterBits[1];
            allBits[16] = ycenterBits[0];

            int[] xcenterInt = { int.Parse(txtXcenter.Text.Trim()) };
            BitArray xcenterBits = new BitArray(xcenterInt);
            allBits[15] = xcenterBits[7];
            allBits[14] = xcenterBits[6];
            allBits[13] = xcenterBits[5];
            allBits[12] = xcenterBits[4];
            allBits[11] = xcenterBits[3];
            allBits[10] = xcenterBits[2];
            allBits[9] = xcenterBits[1];
            allBits[8] = xcenterBits[0];

            int[] animTypeInt = { cboAnimationType.SelectedIndex };
            BitArray animTypeBits = new BitArray(animTypeInt);
            allBits[7] = xcenterBits[1];
            allBits[6] = xcenterBits[0];

            int[] animFrameInt = { int.Parse(txtNumFrames.Text.Trim()) };
            BitArray animFrameBits = new BitArray(animFrameInt);
            allBits[5] = animFrameBits[5];
            allBits[4] = animFrameBits[4];
            allBits[3] = animFrameBits[3];
            allBits[2] = animFrameBits[2];
            allBits[1] = animFrameBits[1];
            allBits[0] = animFrameBits[0];

            allBits.CopyTo(artData.picanm, (int)txtIndexSelector.Value);
        }

        private void txtAnimationSpeed_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int animspeed = int.Parse(txtAnimationSpeed.Text);
                if (animspeed < 0 || animspeed > 15)
                {
                    e.Cancel = true;
                    txtAnimationSpeed.Select(0, txtAnimationSpeed.Text.Length);
                    errorProvider1.SetError(txtAnimationSpeed, "Enter a number between 0 and 15.");
                }
            }
            catch
            {
                e.Cancel = true;
                txtAnimationSpeed.Select(0, txtAnimationSpeed.Text.Length);
                errorProvider1.SetError(txtAnimationSpeed, "Enter a number between 0 and 15.");
            }
        }

        private void txtAnimationSpeed_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtAnimationSpeed, "");
        }

        private void txtYcenter_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int ycenter = int.Parse(txtYcenter.Text);
                if (ycenter < -127 || ycenter > 127)
                {
                    e.Cancel = true;
                    txtYcenter.Select(0, txtYcenter.Text.Length);
                    errorProvider1.SetError(txtYcenter, "Enter a number between -127 and 127.");
                }
            }
            catch
            {
                e.Cancel = true;
                txtYcenter.Select(0, txtYcenter.Text.Length);
                errorProvider1.SetError(txtYcenter, "Enter a number between -127 and 127.");
            }
        }

        private void txtYcenter_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtYcenter, "");
        }

        private void txtXcenter_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int xcenter = int.Parse(txtXcenter.Text);
                if (xcenter < -127 || xcenter > 127)
                {
                    e.Cancel = true;
                    txtXcenter.Select(0, txtXcenter.Text.Length);
                    errorProvider1.SetError(txtXcenter, "Enter a number between -127 and 127.");
                }
            }
            catch
            {
                e.Cancel = true;
                txtXcenter.Select(0, txtXcenter.Text.Length);
                errorProvider1.SetError(txtXcenter, "Enter a number between -127 and 127.");
            }
        }

        private void txtXcenter_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtXcenter, "");
        }

        private void txtNumFrames_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int numframes = int.Parse(txtNumFrames.Text);
                if (numframes < 0 || numframes > 63)
                {
                    e.Cancel = true;
                    txtNumFrames.Select(0, txtNumFrames.Text.Length);
                    errorProvider1.SetError(txtNumFrames, "Enter a number between 0 and 63.");
                }
            }
            catch
            {
                e.Cancel = true;
                txtNumFrames.Select(0, txtNumFrames.Text.Length);
                errorProvider1.SetError(txtNumFrames, "Enter a number between 0 and 63.");
            }
        }

        private void txtNumFrames_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNumFrames, "");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "palette files (*.dat)|*.dat";
            ofd.Title = "Select the palette DAT file.";
            DialogResult dResult = ofd.ShowDialog();
            if (dResult != DialogResult.OK)
                return;
            palettePath = ofd.FileName;
            OpenFileDialog ofd2 = new OpenFileDialog();
            ofd2.Filter = "art files (*.art)|*.art";
            ofd2.Title = "Select the ART file.";
            DialogResult dResult2 = ofd2.ShowDialog();
            if (dResult2 != DialogResult.OK)
                return;
            artPath = ofd2.FileName;
            dataThread = new Thread(new ThreadStart(LoadArt));
            dataThread.Start();
        }
    }
}
