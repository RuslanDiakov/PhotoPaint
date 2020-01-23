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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }
        Bitmap b;
        bool go = false;
        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
            b = new Bitmap(s[0]);
            go = true;
            panel1.Invalidate();
            if (panel1.Size != b.Size) 
            {
                ChangeSizeimg change = new ChangeSizeimg();
                change.ShowDialog();
            }
            //panel1.Width = b.Width;
            //panel1.Height = b.Height;
            //panel1.BackgroundImage = b;
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (s.Length == 1)
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (go)
            {
                PointF point = new PointF(endX, endY);
                g.DrawImage(b, point);
                go = false;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            endX = e.X;
            endY = e.Y;
        }
        public int endX = 0;
        public int endY = 0;
    }
}
