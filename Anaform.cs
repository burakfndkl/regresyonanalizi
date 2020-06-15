using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ekonometri
{
    public partial class Ekonometri : Form
    {
        public Ekonometri()
        {
            InitializeComponent();

        }

        private void chowTestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChowTestForm goster = new ChowTestForm();
            goster.Show();
        }

        private void basitDogrusalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasitDogrusalForm goster = new BasitDogrusalForm();
            goster.Show();
        }

        private void lMTestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lmTestForm goster = new lmTestForm();
            goster.Show();
        }

        private void mvdTestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mvdForm goster = new mvdForm();
            goster.Show();
        }
    }
}
