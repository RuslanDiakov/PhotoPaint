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
using static PhotoPaint.Primitives;

namespace PhotoPaint
{
    public enum GradientType { Transparent, Solid, Line, Hatch, Image }
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public Main(int width_panel, int height_panel, Color backColor_panel)
        {
            this.width_panel = width_panel;
            this.height_panel = height_panel;
            this.backColor_panel = backColor_panel;
            InitializeComponent();
            DrawPanel.Width = width_panel;
            DrawPanel.Height = height_panel;
            DrawPanel.BackColor = backColor_panel;
            toolStripTextBox_width.Text = Convert.ToString(width_panel);
            toolStripTextBox_height.Text = Convert.ToString(height_panel);

            pen = new Pen(Color.Black, 3);

            lgbFrom = Color.AliceBlue;
            lgbTo = Color.Red;
            lgbPos = 0;
            solidG = Color.Red;
            hatchColor = Color.Black;
            hatchStyle = HatchStyle.Percent50;

            TextureBmp = "C:\\Users\\Core00\\Documents\\Untitled.png";
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton_fillDrawPanel_Click(object sender, EventArgs e)
        {
            var color = new ColorDialog();
            color.Color = DrawPanel.BackColor;
            if (color.ShowDialog() != DialogResult.OK) return;
            DrawPanel.BackColor = color.Color;
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel_mousePos.Text = $" X = {e.X}  Y = {e.Y}";
        }

        #region Изменения цвета пера и заливки

        private void toolStripButton_PenColor_Click(object sender, EventArgs e)
        {
            var color = new ColorDialog();
            color.Color = pen.Color;
            if (color.ShowDialog() != DialogResult.OK) return;
            pen.Color = color.Color;
        }

        private void toolStripButton_PenFillColor_Click(object sender, EventArgs e)
        {
            FillSolidPen LoadPenFillColorForm = new FillSolidPen();
            DialogResult dr = LoadPenFillColorForm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                solidG = (LoadPenFillColorForm as FillSolidPen).solidColor;
                BrashType = GradientType.Solid;
            }
        }

        private void toolStripButton_PenFillGradient_Click(object sender, EventArgs e)
        {           
            var f = new FillGradient();
            f.mother = this;
            if (f.ShowDialog() != DialogResult.OK) return;

            switch (f.BrashType)
            {
                case GradientType.Line:
                    lgbFrom = f.lgbFrom;
                    lgbTo = f.lgbTo;
                    lgbPos = f.lgbPos;
                    BrashType = f.BrashType;

                    break;
                case GradientType.Hatch:
                    hatchStyle = f.hatchStyle;
                    hatchColor = f.hatchColor;
                    BrashType = f.BrashType;
                    break;

                case GradientType.Image:
                    TextureBmp = f.TextureBmp;
                    BrashType = f.BrashType;
                    break;
            }
        }

        #endregion

        #region Изменения толщины пера
        private void toolStripMenuItem_PenWidth05_Click(object sender, EventArgs e)
        {
            pen.Width = 1 / 2;
        }

        private void toolStripMenuItem_PenWidth1_Click(object sender, EventArgs e)
        {
            pen.Width = 1;
        }

        private void toolStripMenuItem_PenWidth3_Click(object sender, EventArgs e)
        {
            pen.Width = 3;
        }

        private void toolStripMenuItem_PenWidth5_Click(object sender, EventArgs e)
        {
            pen.Width = 5;
        }

        private void toolStripMenuItem_PenWidth10_Click(object sender, EventArgs e)
        {
            pen.Width = 10;
        }

        private void toolStripTextBox_PenWidth_TextChanged(object sender, EventArgs e)
        {
            pen.Width = Convert.ToInt32(toolStripTextBox_PenWidth.Text);
        }
        #endregion

        #region toolStrip нижняя часть экрана

        private void toolStripTextBox_width_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DrawPanel.Width = Convert.ToInt32(toolStripTextBox_width.Text);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void toolStripTextBox_height_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DrawPanel.Height = Convert.ToInt32(toolStripTextBox_height.Text);
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        #region Кнопки на toolStrip отрисовка фигур       

        private void toolStripButton_none_Click(object sender, EventArgs e)
        {
            CurrentDraw = DrawMode.None;
        }

        private void toolStripButton_createEllipse_Click(object sender, EventArgs e)
        {
            CurrentDraw = DrawMode.Ellipse;
        }

        #endregion

        #region События росования на форме

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawingModel.getInstance().Paint(g);
        }

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startX = e.X; startY = e.Y;
            switch (CurrentDraw)
            {
                case DrawMode.None:
                    break;
                case DrawMode.Ellipse:
                    DrawingModel.getInstance().CreateEllipse(this);
                    break;
                case DrawMode.Rectangle:
                    startX = e.X;
                    startY = e.Y;
                    break;
                default:
                    break;
            }
        }

        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel_mousePos.Text = $" X = {e.X}  Y = {e.Y}";

            if (!isDrawing) return;
            endX = e.X;
            endY = e.Y;
            switch (CurrentDraw)
            {
                case DrawMode.None:
                    break;
                case DrawMode.Ellipse:
                    if (DrawingModel.getInstance().GetLast() == null) break;
                    //toolStripButton_createEllipse.BackColor = Color.Yellow;
                    DrawingModel.getInstance().GetLast().endX = e.X;
                    DrawingModel.getInstance().GetLast().endY = e.Y;
                    DrawPanel.Invalidate();
                    break;
                case DrawMode.Rectangle:

                    DrawPanel.Invalidate();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Переменные

        public Start startForm;
        public int width_panel = 500;
        public int height_panel = 500;
        public Color backColor_panel = Color.LightGray;

        enum DrawMode { None, Ellipse, Rectangle };
        DrawMode CurrentDraw = DrawMode.None;
        bool isDrawing = false;

        public int startX, startY;
        public int endX, endY;
        public Pen pen;

        public GradientType BrashType = GradientType.Transparent;

        public Color lgbFrom = Color.AliceBlue;
        public Color lgbTo = Color.Aqua;
        public float lgbPos = 0;

        public Color solidG = Color.Red;

        public HatchStyle hatchStyle;

        public Color hatchColor;

        public string TextureBmp;

        #endregion
    }
}
