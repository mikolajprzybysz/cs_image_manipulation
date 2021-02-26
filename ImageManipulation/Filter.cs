using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace ImageManipulation
{
    class Filter
    {
        private int SIZE;        
        private int RADIUS;
        private int[,] matrix;
        private int factor;
        private int offset; 
        Bitmap workingBitmap;
        Bitmap extendedBitmap;


        public Filter(int[,] values, int offset)
        {
            this.factor = 0;
            this.offset = offset;
            SIZE = values.GetLength(0);
            RADIUS = (int)Math.Floor( (double)SIZE / 2 );
            matrix = new int[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)
                {
                    factor = factor + values[i, j];
                    matrix[i, j] = values[i, j];
                }
        }
        public Filter(int[,] values, int factor, int offset)
        {
            this.factor = factor;
            this.offset = offset;
            SIZE = values.GetLength(0);
            RADIUS = (int)Math.Floor((double)SIZE / 2);
            matrix = new int[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
                for (int j = 0; j < SIZE; j++)                
                    matrix[i, j] = values[i, j];
                
        }

        public void setBitmap(Bitmap originalBitmap)
        {
            extendedBitmap = extendBitmap(originalBitmap);
            workingBitmap = new Bitmap(originalBitmap);
        }

        private Bitmap extendBitmap(Bitmap bmp)
        {
            Bitmap transformed = new Bitmap(bmp.Width + RADIUS * 2, bmp.Height + RADIUS * 2);
            for (int i = RADIUS; i < transformed.Width - RADIUS; i++)
                for (int j = RADIUS; j < transformed.Height - RADIUS; j++)
                    transformed.SetPixel(i, j, bmp.GetPixel(i - RADIUS, j - RADIUS));

            //horizontal
            for (int i = RADIUS; i < transformed.Width - RADIUS; i++)
            {
                for (int j = 0; j < RADIUS; j++)
                {
                    transformed.SetPixel(i, j, bmp.GetPixel(i -RADIUS, RADIUS));
                    transformed.SetPixel(i, (transformed.Height - 1) - j, bmp.GetPixel(i - RADIUS, (bmp.Height - 1) - RADIUS));
                }
            }

            //vertical
            for (int i = RADIUS; i < transformed.Height - RADIUS; i++)
            {
                for (int j = 0; j < RADIUS; j++)
                {
                    transformed.SetPixel(j, i, bmp.GetPixel(RADIUS, i - RADIUS));
                    transformed.SetPixel((transformed.Width - 1) - RADIUS, i, bmp.GetPixel((bmp.Width - 1) - RADIUS, i - RADIUS));
                }
            }

            Color current = bmp.GetPixel(0, 0);
            for (int i = 0; i < RADIUS; i++)
            {
                for (int j = 0; j < RADIUS; j++)
                {
                    transformed.SetPixel(i, j, current);
                }
            }
            //transformed.SetPixel(0, 0, bmp.GetPixel(0, 0));
            current = bmp.GetPixel(0, bmp.Height -1);
            for (int i = transformed.Width -1 -RADIUS; i < transformed.Width -1; i++)
            {
                for (int j = 0; j < RADIUS; j++)
                {
                    transformed.SetPixel(i, j, current);
                }
            }
            //transformed.SetPixel(0, transformed.Width, bmp.GetPixel(0, bmp.Width));
            current = bmp.GetPixel(bmp.Width - 1, 0);
            for (int i = 0; i < RADIUS; i++)
            {
                for (int j = transformed.Height - 1 - RADIUS; j < transformed.Height - 1; j++)
                {
                    transformed.SetPixel(i, j, current);
                }
            }
            //transformed.SetPixel(transformed.Height, 0, bmp.GetPixel(bmp.Height, 0));
            current = bmp.GetPixel(bmp.Width - 1, bmp.Height - 1);
            for (int i = transformed.Width - 1 - RADIUS; i < transformed.Width - 1; i++)
            {
                for (int j = transformed.Height - 1 - RADIUS; j < transformed.Height - 1; j++)
                {
                    transformed.SetPixel(i, j, current);
                }
            }
            //transformed.SetPixel(transformed.Height, transformed.Width, bmp.GetPixel(bmp.Height, bmp.Width));
            return transformed;
        }      

        public Bitmap getFilteredBitmap()
        {
            
            for (int i = RADIUS; i < extendedBitmap.Width-1-RADIUS; i++)
                for (int j = RADIUS; j < extendedBitmap.Height - 1 - RADIUS; j++)
                    workingBitmap.SetPixel(i -RADIUS, j -RADIUS, getTransformedPixel(i, j));
                

            return workingBitmap;
        }

        private Color getTransformedPixel(int pixelPosX, int pixelPosY)
        {            
            int sumR = 0;
            int sumG = 0;
            int sumB = 0;
            for (int i = -RADIUS; i < RADIUS; i++)
                for (int j = -RADIUS; j < RADIUS; j++)
                {
                    sumR += extendedBitmap.GetPixel(pixelPosX + i, pixelPosY + j).R * matrix[i+RADIUS,j+RADIUS];
                    sumG += extendedBitmap.GetPixel(pixelPosX + i, pixelPosY + j).G * matrix[i+RADIUS,j+RADIUS];
                    sumB += extendedBitmap.GetPixel(pixelPosX + i, pixelPosY + j).B * matrix[i+RADIUS,j+RADIUS];
                }

            int[] sumRGB = { (sumR / factor) + offset, (sumG / factor) + offset, (sumB / factor) + offset };
            for (int i = 0; i < sumRGB.Length; i++)
            {
                if (sumRGB[i] > 255) sumRGB[i] = 255;
                if (sumRGB[i] < 0) sumRGB[i] = 0;
            }

            Color finalColor = new Color();
            finalColor = Color.FromArgb(sumRGB[0], sumRGB[1], sumRGB[2]);
            return finalColor;
            
        }


    }
}
