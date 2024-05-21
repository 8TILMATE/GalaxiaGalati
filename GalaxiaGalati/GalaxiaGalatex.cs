using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace GalaxiaGalati
{
    public partial class GalaxiaGalatex : Form
    {
        public GalaxiaGalatex()
        {
            InitializeComponent();
        }
        Bitmap bmp;
        bool hasrun = true;
        bool firstelse = true;
        float angle = 0f;
        int[] xx = new int[100];
        int[] yy = new int[100];
        private void GalaxiaGalatex_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            if (hasrun)
            {
                Random rand = new Random();
                using (SolidBrush black = new SolidBrush(Color.Yellow))
                {
                    for (int i = 0; i < 100; i++)
                    {
                        int x = rand.Next(30, panel1.Width - 30);
                        int y = rand.Next(30, panel1.Height - 30);
                        xx[i] = x;
                        yy[i] = y;
                        e.Graphics.FillEllipse(black, x, y, 5, 5);
                    }
                }
                hasrun = false;
                bmp = new Bitmap(panel1.Bounds.Width, panel1.Bounds.Height);
                panel1.DrawToBitmap(bmp, panel1.Bounds);
                
            }
            else
            {
                if (firstelse)
                {
                    using (SolidBrush black = new SolidBrush(Color.Yellow))
                    {
                        for (int i = 0; i < 100; i++)
                        {

                            e.Graphics.FillEllipse(black, xx[i], yy[i], 5, 5);
                        }
                    }
                    firstelse = false;
                }
                
                
                Graphics g = panel1.CreateGraphics();
                int width = bmp.Width / 2;
                int height = bmp.Height / 2;
                g.TranslateTransform(width, height);
                g.RotateTransform(angle);
                g.TranslateTransform(-width, -height);
                g.DrawImage(bmp, 0, 0);
                g.ResetTransform();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            angle += 0.2f;
            panel1.Invalidate();
        }
    }
}
