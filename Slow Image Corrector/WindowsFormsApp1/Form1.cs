using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private Image filteredImage;

        public MainForm()
        {
            InitializeComponent();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result != DialogResult.OK) return;
            
            sourcePictureBox.Image = new Bitmap(openFileDialog1.FileName);
            resultPixtureBox.Image = new Bitmap(openFileDialog1.FileName);
            filteredImage = sourcePictureBox.Image;

            panel1.Enabled = true;

            Reset();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resultPixtureBox.Image == null) return;


            DialogResult result = saveFileDialog1.ShowDialog();

            if (result != DialogResult.OK) return;

            resultPixtureBox.Image.Save(saveFileDialog1.FileName);

        }

        private void ApplyCorrection()
        {

            if (filteredImage == null) return;

            ImageProcessor img = new ImageProcessor(filteredImage);
            int r, g, b;
            int britness = britnessTrackBar.Value;
            int contrast = contrastTrackBar.Value;
            int rcor = redTrackBar.Value;
            int gcor = greenTrackBar.Value;
            int bcor = blueTrackBar.Value;

            for (int i = 0; i < img.Pixels.Length; i += img.BytePerPixel)
            {
                b = img.Pixels[i + 0];
                g = img.Pixels[i + 1];
                r = img.Pixels[i + 2];

                r += rcor;
                g += gcor;
                b += bcor;

                PixelProcessor.ClampColor(ref r, ref g, ref b);

                PixelProcessor.ApplyBritness(ref r, ref g, ref b, britness);
                PixelProcessor.ApplyContrast(ref r, ref g, ref b, (int)contrast);

                img.Pixels[i + 0] = (byte)b;
                img.Pixels[i + 1] = (byte)g;
                img.Pixels[i + 2] = (byte)r;
            }

            img.Unlock();

            resultPixtureBox.Image = img.Bitmap;
        }

        private void Reset()
        {
            resultPixtureBox.Image = sourcePictureBox.Image;
            filteredImage = sourcePictureBox.Image;
            redTrackBar.Value = 0;
            greenTrackBar.Value = 0;
            blueTrackBar.Value = 0;
            britnessTrackBar.Value = 0;
            contrastTrackBar.Value = 0;
        }
        
        private void обесцветитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filteredImage == null) return;

            Reset();

            ImageProcessor img = new ImageProcessor(filteredImage);
            int r, g, b;

            for (int i = 0; i < img.Pixels.Length; i += img.BytePerPixel)
            {
                b = img.Pixels[i + 0];
                g = img.Pixels[i + 1];
                r = img.Pixels[i + 2];

                PixelProcessor.ApplyDiscolor(ref r, ref g, ref b);


                img.Pixels[i + 0] = (byte)b;
                img.Pixels[i + 1] = (byte)g;
                img.Pixels[i + 2] = (byte)r;
            }

            img.Unlock();

            filteredImage = img.Bitmap;
            resultPixtureBox.Image = img.Bitmap;
        }

        private void морозToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filteredImage == null) return;

            Reset();

            ImageProcessor img = new ImageProcessor(filteredImage);
            int r, g, b;

            for (int i = 0; i < img.Pixels.Length; i += img.BytePerPixel)
            {
                b = img.Pixels[i + 0];
                g = img.Pixels[i + 1];
                r = img.Pixels[i + 2];

                r -= 20;
                b += 10;
                PixelProcessor.ClampColor(ref r, ref g, ref b);

                PixelProcessor.ApplyBritness(ref r, ref g, ref b, 10);
                PixelProcessor.ApplyContrast(ref r, ref g, ref b, (int)15);



                img.Pixels[i + 0] = (byte)b;
                img.Pixels[i + 1] = (byte)g;
                img.Pixels[i + 2] = (byte)r;
            }

            img.Unlock();

            filteredImage = img.Bitmap;
            resultPixtureBox.Image = img.Bitmap;
        }

        private void радостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filteredImage == null) return;

            Reset();

            ImageProcessor img = new ImageProcessor(filteredImage);
            int r, g, b;

            for (int i = 0; i < img.Pixels.Length; i += img.BytePerPixel)
            {
                b = img.Pixels[i + 0];
                g = img.Pixels[i + 1];
                r = img.Pixels[i + 2];

                r += 10;
                g += 10;
                b += 10;

                PixelProcessor.ClampColor(ref r, ref g, ref b);

                PixelProcessor.ApplyBritness(ref r, ref g, ref b, 10);
                PixelProcessor.ApplyContrast(ref r, ref g, ref b, 30);



                img.Pixels[i + 0] = (byte)b;
                img.Pixels[i + 1] = (byte)g;
                img.Pixels[i + 2] = (byte)r;
            }

            img.Unlock();

            filteredImage = img.Bitmap;
            resultPixtureBox.Image = img.Bitmap;
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filteredImage == null) return;

            Reset();

            ImageProcessor img = new ImageProcessor(filteredImage);
            int r = 0, g = 0, b = 0;

            for (int i = 0; i < img.Pixels.Length; i += img.BytePerPixel)
            {
                b = img.Pixels[i + 0];
                g = img.Pixels[i + 1];
                r = img.Pixels[i + 2];

                PixelProcessor.ApplyDiscolor(ref r, ref g, ref b);

                r += 5;
                b -= 40;
                g -= 10;

                PixelProcessor.ClampColor(ref r, ref g, ref b);


                img.Pixels[i + 0] = (byte)b;
                img.Pixels[i + 1] = (byte)g;
                img.Pixels[i + 2] = (byte)r;
            }


            img.Unlock();

            filteredImage = img.Bitmap;
            resultPixtureBox.Image = img.Bitmap;
        }

        private void britnessTrackBar_Scroll(object sender, EventArgs e)
        {
            ApplyCorrection();
        }

        private void contrastTrackBar_Scroll(object sender, EventArgs e)
        {
            ApplyCorrection();
        }

        private void redTrackBar_Scroll(object sender, EventArgs e)
        {
            ApplyCorrection();
        }

        private void greenTrackBar_Scroll(object sender, EventArgs e)
        {
            ApplyCorrection();
        }

        private void blueTrackBar_Scroll(object sender, EventArgs e)
        {
            ApplyCorrection();
        }

        private void сброситьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

      
    }

}
