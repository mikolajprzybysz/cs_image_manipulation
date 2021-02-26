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
    public partial class brightnessContrastWindow : Form
    {
        private Bitmap bmp;
        private double brightness = 1.0f; // no change in brightness
        private double contrast = 1.0f; // no change in contrast
        private double gamma = 1.0f; // no change in gamma

        public brightnessContrastWindow()
        {
            InitializeComponent();
        }
        public void setBitmap(ref Bitmap yourBmp)
        {
            bmp = yourBmp;
        }
        private void okButton_Click(object sender, EventArgs e)
        {            
            changeBrightnessContrast(brightnessTrackBar.Value, contrastTrackBar.Value);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void contrastChange(object sender, EventArgs e)
        {
            contrastTextBox.Text = contrastTrackBar.Value.ToString();
        }      
        private void brightnessChange(object sender, EventArgs e)
        {
            brightnessTextBox.Text = brightnessTrackBar.Value.ToString();
        }        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adjustedBrightness">Brigthness adjusted value <-100,100></param>
        /// <param name="adjustedContrast">Contrast adjusted value <-100,100></param>
        private void changeBrightnessContrast(float adjustedBrightness, float adjustedContrast)
        {
            try
            {
                adjustedBrightness = adjustedBrightness / 100.0f;
                adjustedContrast = (100.0f + adjustedContrast) / 100.0f;
                adjustedContrast *= adjustedContrast;
                //(((Red - 0.5f) * Value) + 0.5f) * 255.0f
                adjustedContrast = (float)((contrast - 0.5f) * adjustedContrast) + 0.5f;                
                //            MessageBox.Show(adjustedBrightness.ToString());
                // create matrix that will brighten and contrast the image
                float[][] ptsArray ={
                    new float[] {(float)adjustedContrast, 0, 0, 0, 0}, // scale red
                    new float[] {0, (float)adjustedContrast, 0, 0, 0}, // scale green
                    new float[] {0, 0, (float)adjustedContrast, 0, 0}, // scale blue
                    new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
                    new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};

                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.ClearColorMatrix();
                imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                imageAttributes.SetGamma((float)gamma, ColorAdjustType.Bitmap);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height)
                    , 0, 0, bmp.Width, bmp.Height,
                    GraphicsUnit.Pixel, imageAttributes);
                ((Form1)Owner).rfrshViewport();
                this.Dispose();
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("No image");
            }
        }
    }
}

