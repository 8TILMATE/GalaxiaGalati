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
    public partial class IncepeSimularea : Form
    {
        public IncepeSimularea()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var simulare = new Simulare();
            simulare.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var simulare = new MagellanicClouds();
            simulare.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var simulare = new Nebuloasa();

            simulare.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var simulare = new GalaxiaGalatex();

            simulare.ShowDialog();
        }
    }
}
