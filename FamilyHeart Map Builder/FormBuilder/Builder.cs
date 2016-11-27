using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FamilyHeart_Map_Builder.WinformController;

namespace FamilyHeart_Map_Builder.FormBuilder
{
    public partial class Builder : Form
    {
        private string slicezPath;

        public Builder()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

#if BUILDER
            
#endif
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlignAbout about = new AlignAbout();
            about.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DestroyHandle();
        }

        private void sliceTileMAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RectTileMap sliceWin = new RectTileMap();
            sliceWin.Show();
        }
    }
}
