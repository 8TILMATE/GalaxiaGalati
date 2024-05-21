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
    public partial class Nebuloasa : Form
    {
        Rectangle nebuloasaBounds = new Rectangle(200, 100, 300, 300);
        public Nebuloasa()
        {
            InitializeComponent();
        }
        float angle = 0f;
        bool runfirsttime = true;
        Bitmap bmp;
        private void Nebuloasa_Load(object sender, EventArgs e)
        {

        }

        private void Nebuloasa_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, this.Width, this.Height);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e);

            if (runfirsttime)
            {
                runfirsttime = false;
                bmp = new Bitmap(panel1.Bounds.Width,panel1.Bounds.Height);
                panel1.DrawToBitmap(bmp, panel1.Bounds);
            }
            else
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
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            angle += 1f;
            panel1.Invalidate();

        }
        private void Draw(PaintEventArgs e)
        {
            using (GraphicsPath cloudPath = new GraphicsPath())
            {
                cloudPath.AddEllipse(nebuloasaBounds);
                using (PathGradientBrush cloudBrush = new PathGradientBrush(cloudPath))
                {
                    cloudBrush.CenterColor = Color.Black;

                    Color[] colors = new Color[] { Color.Orange, Color.Red };


                    float[] relativePositions = {
      0.0f,    // red at the boundary of the outer triangle
      1.0f};   // blue at the boundary of the inner triangle
                    /*
                    cloudBrush.InterpolationColors.Colors = colors;
                    cloudBrush.InterpolationColors.Positions=relativePositions;

                    cloudBrush.FocusScales = new PointF(0.9f, 0.9f);
                    */
                    cloudBrush.SurroundColors = colors;
                    Blend blend = new Blend
                    {
                        Factors = new float[] { 0.0f, 0.0f, 0.6f },
                        Positions = new float[] { 0.0f, 0.8f, 1.0f }
                    };
                    cloudBrush.Blend = blend;

                    e.Graphics.FillEllipse(cloudBrush, nebuloasaBounds);
                }
            }
        }
    }
}
