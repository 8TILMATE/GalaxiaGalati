using GalaxiaGalati.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalaxiaGalati
{

public partial class Simulare : Form
    {
        float angle = 0;
        Bitmap bmp;
        public Simulare()
        {
            InitializeComponent();
            // pictureBox1.DoubleBuffered = true;
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            angle += 0.1f;
            angle = angle%360;
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            int width = bmp.Width / 2;
            int height = bmp.Height / 2;
            g.TranslateTransform(width, height);
            g.RotateTransform(angle);
            g.TranslateTransform(-width, -height);
            g.DrawImage(bmp, 0, 0);
            g.ResetTransform();
        }

        private void Simulare_Load(object sender, EventArgs e)
        {
            bmp = Resources.cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTA4L3B4ODM3MDQxLWltYWdlLWpvYjg1MV8xLmpwZw_removebg_preview;
          
        }

        private void Simulare_Paint(object sender, PaintEventArgs e)
        {
  
        }
    }
}
