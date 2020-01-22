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
    public partial class LayersForm : Form
    {
        public List<Primitives> temp = new List<Primitives>();
        Panel panel;

        public LayersForm(ref Panel ResetPanel)
        {
            InitializeComponent();
            panel = ResetPanel;
            lb_layers.DataSource = DrawingModel.getInstance().allDraw;
            temp = DrawingModel.getInstance().clone();
        }

        private void b_up_Click(object sender, EventArgs e)
        {
            int number = lb_layers.SelectedIndex;
            temp.Add(temp[number]);
            temp.RemoveAt(number);
            lb_layers.DataSource = temp;
            DrawingModel.getInstance().allDraw = temp;
            lb_layers.Invalidate();
            panel.Invalidate();
        }

        private void b_up1_Click(object sender, EventArgs e)
        {
            try
            {
                int number = lb_layers.SelectedIndex;
                temp.Insert(number + 2, temp[number]);
                temp.RemoveAt(number);
                lb_layers.DataSource = temp;
                DrawingModel.getInstance().allDraw = temp;
                lb_layers.Invalidate();
                panel.Invalidate();
            }
            catch { }
        }

        private void b_down_Click(object sender, EventArgs e)
        {
            int number = lb_layers.SelectedIndex;
            temp.Insert(0, temp[number]);
            temp.RemoveAt(number + 1);
            lb_layers.DataSource = temp;            
            DrawingModel.getInstance().allDraw = temp;

            lb_layers.Invalidate();
            panel.Invalidate();
        }

        private void b_down1_Click(object sender, EventArgs e)
        {
            try
            {
                int number = lb_layers.SelectedIndex;
                temp.Insert(number - 1, temp[number]);
                temp.RemoveAt(number + 1);
                lb_layers.DataSource = temp;
                DrawingModel.getInstance().allDraw = temp;
                
                lb_layers.Invalidate();
                panel.Invalidate();
            }
            catch { }
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void b_cancle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
