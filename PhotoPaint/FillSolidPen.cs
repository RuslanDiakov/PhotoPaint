using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoPaint
{
    public partial class FillSolidPen : Form
    {
        public  Color solidColor { get; set; }// = Color.Orange;
       
        public FillSolidPen()
        {
            InitializeComponent();
        }

        private void b_ok_Click(object sender, EventArgs e)
        {           
            DialogResult = DialogResult.OK;
        }

        private void b_transparent_Click(object sender, EventArgs e)
        {
            solidColor = Color.Transparent;
            gb_Transparent.BackColor = Color.DimGray;
            gb_Color.BackColor = Color.FromArgb(255, 64, 64, 64);
        }
            
        private void b_SelectColor_Click(object sender, EventArgs e)
        {
            var color = new ColorDialog();
            color.Color = solidColor;
            if (color.ShowDialog() != DialogResult.OK) return;
            solidColor = color.Color;

            b_SelectColor.BackColor = solidColor;
            gb_Transparent.BackColor = Color.FromArgb(255, 64, 64, 64);
            gb_Color.BackColor = Color.DimGray;
        }

        private void b_cancle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
