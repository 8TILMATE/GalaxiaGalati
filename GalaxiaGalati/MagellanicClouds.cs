using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalaxiaGalati
{
    public partial class MagellanicClouds : Form
    {
        public MagellanicClouds()
        {
            InitializeComponent();
        }

        private void MagellanicClouds_Paint(object sender, PaintEventArgs e)
        {
        
            Rectangle cloudBounds = new Rectangle(50, 50, 400, 300);

            
            using (LinearGradientBrush backgroundBrush = new LinearGradientBrush(
                new Point(0, 0), new Point(0, this.Height),
                Color.Black, Color.FromArgb(36,36,36)))
            {
                e.Graphics.FillRectangle(backgroundBrush, ClientRectangle);
            }

            using (GraphicsPath cloudPath = new GraphicsPath())
            {
                cloudPath.AddEllipse(cloudBounds);

                using (PathGradientBrush cloudBrush = new PathGradientBrush(cloudPath))
                {
                    cloudBrush.CenterColor = Color.LightGoldenrodYellow;
                    cloudBrush.SurroundColors = new Color[] { Color.Black };

                    e.Graphics.FillEllipse(cloudBrush, cloudBounds);
                }
            }

            Random rand = new Random();
            using (SolidBrush starBrush = new SolidBrush(Color.Black))
            {
                for (int i = 0; i < 100; i++)
                {
                    starBrush.Color = Color.FromArgb(rand.Next(100, 255), rand.Next(100, 255),0);
                    int x = rand.Next(cloudBounds.Left+30, cloudBounds.Right-40);
                    int y = rand.Next(cloudBounds.Top+30, cloudBounds.Bottom-40);
                    e.Graphics.FillEllipse(starBrush, x, y, rand.Next(4,10), rand.Next(4,10));
                }
            }
            using (SolidBrush black = new SolidBrush(Color.Black))
            {
                for (int i = 0; i < 100; i++)
                {
                    int x = rand.Next(cloudBounds.Left+30, cloudBounds.Right - 30);
                    int y = rand.Next(cloudBounds.Top+30, cloudBounds.Bottom - 30);
                    e.Graphics.FillEllipse(black, x, y, 5, 5);
                }
            }
        }

        private void MagellanicClouds_Load(object sender, EventArgs e)
        {

        }
    }
}
