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
    public partial class ChangeSizeimg : Form
    {
        public ChangeSizeimg(int w_f, int h_f, int w_i, int h_i)
        {
            InitializeComponent();
            tb_h_f.Text = $"{h_f}";
            tb_w_f.Text = $"{w_f}";

            tb_h_i.Text = $"{h_i}";
            tb_w_i.Text = $"{w_i}";
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            w_f = Convert.ToInt32(tb_w_f.Text);
            h_f = Convert.ToInt32(tb_h_f.Text);

            w_i = Convert.ToInt32(tb_w_i.Text);
            h_i = Convert.ToInt32(tb_h_i.Text);

            DialogResult = DialogResult.OK;
        }
     
        private void b_i_minus_Click(object sender, EventArgs e)
        {
            tb_h_i.Text = $"{Convert.ToInt32(Convert.ToInt32(tb_h_i.Text) /1.1)}";
            tb_w_i.Text = $"{Convert.ToInt32(Convert.ToInt32(tb_w_i.Text) /1.1)}";
        }

        private void b_i_plus_Click(object sender, EventArgs e)
        {
            tb_h_i.Text = $"{Convert.ToInt32(Convert.ToInt32(tb_h_i.Text) * 1.1)}";
            tb_w_i.Text = $"{Convert.ToInt32(Convert.ToInt32(tb_w_i.Text) * 1.1)}";
        }
     
        private void b_f_minus_Click(object sender, EventArgs e)
        {
            tb_h_f.Text = $"{Convert.ToInt32(Convert.ToInt32(tb_h_f.Text) / 1.1)}";
            tb_w_f.Text = $"{Convert.ToInt32(Convert.ToInt32(tb_w_f.Text) / 1.1)}";
        }

        private void b_f_plus_Click(object sender, EventArgs e)
        {
            tb_h_f.Text = $"{Convert.ToInt32(Convert.ToInt32(tb_h_f.Text) * 1.1)}";
            tb_w_f.Text = $"{Convert.ToInt32(Convert.ToInt32(tb_w_f.Text) * 1.1)}";
        }

        public int w_f, h_f, w_i, h_i;
    }
}
