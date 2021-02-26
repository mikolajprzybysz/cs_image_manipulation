using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageManipulation
{
    public partial class Form1 : Form
    {
        private Bitmap originalBitmap;
        


        public Form1()
        {
            InitializeComponent();
        }
        /* x*y*8 vs x*y + x*2 + y*2 +4 */
        private Bitmap getWorkingBitmap(Bitmap bmp)
        {
            Bitmap transformed = new Bitmap(bmp.Width+2, bmp.Height+2);
            for (int i = 1; i < transformed.Width - 1; i++)
                for (int j = 1; j < transformed.Height - 1; j++)
                    transformed.SetPixel(i, j, bmp.GetPixel(i, j));

            for (int i = 1; i < transformed.Width - 1; i++)
            {
                transformed.SetPixel(i, 0, bmp.GetPixel(i, 1));
                transformed.SetPixel(i, transformed.Height-1, bmp.GetPixel(i, bmp.Height-1));
            }

            for (int j = 1; j < transformed.Height - 1; j++)
            {
                transformed.SetPixel(0, j, bmp.GetPixel(0, j));
                transformed.SetPixel(transformed.Width-1, j, bmp.GetPixel(bmp.Width-1, j));
            }

            transformed.SetPixel(0, 0, bmp.GetPixel(0, 0));
            transformed.SetPixel(0, transformed.Width, bmp.GetPixel(0, bmp.Width));
            transformed.SetPixel(transformed.Height, 0, bmp.GetPixel(bmp.Height, 0));
            transformed.SetPixel(transformed.Height, transformed.Width, bmp.GetPixel(bmp.Height, bmp.Width));
            return transformed;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Bitmap files (*.bmp)|*.bmp";

            if (DialogResult.OK == openFile.ShowDialog())
            {
                originalBitmap = new Bitmap(openFile.OpenFile());
                originalBox.Image = originalBitmap;
                customBox.Image = originalBitmap;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] GaussianValues = { { 1, 4, 7, 4, 1 }, { 4, 16, 26, 16, 4 }, { 7, 26, 41, 26, 7 } ,{ 4, 16, 26, 16, 4 }, { 1, 4, 7, 4, 1 } };
            int offset = 0;
            
            Filter Gaussian = new Filter( GaussianValues, offset );
            Gaussian.setBitmap(new Bitmap(customBox.Image));
            customBox.Image = Gaussian.getFilteredBitmap();
             
        }
        
        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] SharpenValues = { { 0, 0, 0, 0, 0 }, { 0, 0, -1, 0, 0 }, { 0, -1, 5, -1, 0 }, { 0, 0, -1, 0, 0 }, { 0, 0, 0, 0, 0 } };
            int offset = 0;

            Filter Sharpen = new Filter(SharpenValues, offset);
            Sharpen.setBitmap(new Bitmap(customBox.Image));
            customBox.Image = Sharpen.getFilteredBitmap();
        }

        public void customFilter(int[,] data, int factor, int offset)
        {
            int[,] CustomValues = data;

            Filter Custom = new Filter(CustomValues, factor, offset);
            Custom.setBitmap(new Bitmap(customBox.Image));
            customBox.Image = Custom.getFilteredBitmap();
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Custom newCustomFilter = new Custom(this);
            newCustomFilter.Owner = this;
            newCustomFilter.Show();            
        }

        private void findEdgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] MeanRemovalValues = { 
                                    { 0,  0,  0,  0, 0 }, 
                                    { 0, -1, -1, -1, 0 }, 
                                    { 0, -1,  8, -1, 0 }, 
                                    { 0, -1, -1, -1, 0 }, 
                                    { 0,  0,  0,  0, 0 } };
            int offset = 0;

            Filter MeanRemoval = new Filter(MeanRemovalValues, offset);
            MeanRemoval.setBitmap(new Bitmap(customBox.Image));
            customBox.Image = MeanRemoval.getFilteredBitmap();
        }
            
        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap tmp = new Bitmap(originalBitmap);
            customBox.Image = tmp;
            brightnessContrastWindow changeBrightnessContrastWindow = new brightnessContrastWindow();
            changeBrightnessContrastWindow.Owner = this;
            changeBrightnessContrastWindow.setBitmap(ref tmp);
            changeBrightnessContrastWindow.Show();
        }
        public void rfrshViewport()
        {
            customBox.Refresh();
        }
    }
}
