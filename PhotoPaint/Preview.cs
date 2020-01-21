using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PhotoPaint.Primitives;

namespace PhotoPaint
{
    public partial class Preview : Form
    {
        public Preview(Panel frm)
        {
            InitializeComponent();            
            panel1.Width = this.Width =  frm.Width;
            panel1.Height = this.Height = frm.Height;
            panel1.BackColor = frm.BackColor;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawingModel.getInstance().Paint(g);
        }
    }
}
