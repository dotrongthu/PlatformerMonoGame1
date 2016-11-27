using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace FamilyHeart_Map_Builder.FormBuilder
{


    public partial class RectTileMap : Form

            
    {
        public string pathSlice;
        private bool isSlecting = false;
        private Image originalPic;

        private List<String> names;
        private List<Vector4> rects;
        Vector4 temp = new Vector4();

        public RectTileMap()
        {
            InitializeComponent();
           
            
        }


    
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isSlecting = true;

            
            temp.X = e.X;
            temp.Y = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isSlecting) return;

            temp.Z = e.X;
            temp.W = e.Y;


            //Draw Rectangle onto image
            using (Graphics graph = Graphics.FromImage(originalPic))
            {
                graph.DrawRectangle(Pens.CornflowerBlue, Math.Min(temp.X, temp.Z), Math.Min(temp.Y, temp.W), Math.Abs(temp.X - temp.Z), Math.Abs(temp.Y - temp.W));
            }

            
            

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isSlecting) return;
            isSlecting = false;

            Image ugly = Image.FromFile(pathSlice);
            pictureBox1.Image = (Image)(ResizeImage(ugly, pictureBox1.Width, pictureBox1.Height));

            

        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                pathSlice = openFileDialog1.FileName;
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
