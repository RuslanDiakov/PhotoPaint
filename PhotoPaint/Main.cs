using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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

        public Main(int width_panel, int height_panel, Color backColor_panel, Bitmap bitmapOpen)
        {
            this.width_panel = width_panel;
            this.height_panel = height_panel;
            this.backColor_panel = backColor_panel;
            InitializeComponent();
            DrawPanel.Width = width_panel;
            DrawPanel.Height = height_panel;
            DrawPanel.BackColor = backColor_panel;
            DrawPanel.BackgroundImage = bitmapOpen;
            toolStripTextBox_width.Text = Convert.ToString(width_panel);
            toolStripTextBox_height.Text = Convert.ToString(height_panel);

            pen = new Pen(Color.Black, 3);

            lgbFrom = Color.AliceBlue;
            lgbTo = Color.Red;
            lgbPos = 0;
            solidG = Color.Black;
            hatchColor = Color.Black;
            hatchStyle = HatchStyle.Percent50;

            TextureBmp = "C:\\Users\\Core00\\Documents\\Untitled.png";

            if (DrawPanel.Width < this.Width)
            {
                hScrollBar1.Hide();
            }
            else
            {
                hScrollBar1.Show();
                int r = DrawPanel.Width - this.Width;
                hScrollBar1.Maximum = r;
            }

            if (DrawPanel.Height < this.Height)
            {
                vScrollBar1.Hide();
            }
            else
            {
                vScrollBar1.Show();
                int r = DrawPanel.Height - this.Height;
                vScrollBar1.Maximum = r;
            }
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

        private void toolStripButton_ShowLayers_Click(object sender, EventArgs e)
        {
            LayersForm layersForm = new LayersForm(ref DrawPanel);
            layersForm.ShowDialog();
            if (layersForm.DialogResult == DialogResult.OK)
            {
                DrawingModel.getInstance().allDraw = layersForm.temp;
            }
            DrawPanel.Invalidate();
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripLabel_mousePos.Text = $" X = {e.X}  Y = {e.Y}";
            //if (CurrentDraw == DrawMode.DragImg)
            //{
            //    DrawPanel.Invalidate();
            //}
        }

        #region DragDrog

        private void DrawPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (s.Length == 1)
                {
                    e.Effect = DragDropEffects.Copy;
                    DrawPanel.Invalidate();
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void DrawPanel_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadTempImg = new Bitmap(s[0]);

            ChangeSizeimg changeF = new ChangeSizeimg(DrawPanel.Width, DrawPanel.Height, LoadTempImg.Width, LoadTempImg.Height);
            if (changeF.ShowDialog() != DialogResult.OK) return;
            DrawPanel.Width = changeF.w_f;
            DrawPanel.Height = changeF.h_f;
            int w_i = changeF.w_i;
            int h_i = changeF.h_i;
            LoadTempImg = new Bitmap(LoadTempImg, w_i, h_i);

            isLoadTempImg = true;
            CurrentDraw = DrawMode.DragImg;
            DrawPanel.Invalidate();
        }

        #endregion

        #region Изменения цвета пера, заливки, текста

        private void toolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            newText = toolStripTextBox.Text;
        }

        private void toolStripButton_setTexP_Click(object sender, EventArgs e)
        {
            var text = new FontDialog();
            text.Font = newFont;
            if (text.ShowDialog() != DialogResult.OK) return;
            newFont = text.Font;
        }

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

        private void toolStripMI_type1_Click(object sender, EventArgs e)
        {
            pen.StartCap = LineCap.Round;

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
            try
            {
                pen.Width = Convert.ToInt32(toolStripTextBox_PenWidth.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ввотите только цифры\nПример: 0.5 1 45 100", "Error");
                return;
            }
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

        private void toolStripButton_createLine_Click(object sender, EventArgs e)
        {
            CurrentDraw = DrawMode.Line;
        }

        private void toolStripButton_createEllipse_Click(object sender, EventArgs e)
        {
            CurrentDraw = DrawMode.Ellipse;
        }

        private void toolStripButton_createRectangle_Click(object sender, EventArgs e)
        {
            CurrentDraw = DrawMode.Rectangle;
        }

        private void toolStripButton_createPoint_Click(object sender, EventArgs e)
        {
            CurrentDraw = DrawMode.Point;
        }

        private void toolStripButton_createText_Click(object sender, EventArgs e)
        {
            CurrentDraw = DrawMode.Text;
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

                case DrawMode.Line:
                    DrawingModel.getInstance().CreateLine(this);
                    break;

                case DrawMode.Point:
                    //DrawingModel.getInstance().CreatePoint(this);
                    break;

                case DrawMode.Ellipse:
                    DrawingModel.getInstance().CreateEllipse(this);
                    break;

                case DrawMode.Rectangle:
                    DrawingModel.getInstance().CreateRectangle(this);
                    break;

                case DrawMode.Text:
                    DrawingModel.getInstance().CreateText(this);
                    DrawPanel.Invalidate();
                    break;

                case DrawMode.DragImg:
                    startX += LoadTempImg.Width/2; startY += LoadTempImg.Height/2;
                    DrawingModel.getInstance().CreateImg(this);
                    break;

                default:
                    break;
            }
        }

        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            Bottom_lable_straight.Text = "no";

            if (CurrentDraw == DrawMode.DragImg)
            {
                CurrentDraw = DrawMode.None;
            }
        }

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            // Graphics g = new Graphics;
            toolStripLabel_mousePos.Text = $" X = {e.X}  Y = {e.Y}";

            if (!isDrawing) return;
            endX = e.X;
            endY = e.Y;

            switch (CurrentDraw)
            {
                case DrawMode.None:
                    break;

                case DrawMode.Line:
                    if (DrawingModel.getInstance().GetLast() == null) break;

                    if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                    {
                        DrawingModel.getInstance().GetLast().endX = e.X;
                        DrawingModel.getInstance().GetLast().endY = startY;
                        Bottom_lable_straight.Text = "Прямая горизонтальная линия -";
                        DrawPanel.Invalidate();
                    }
                    else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        DrawingModel.getInstance().GetLast().endX = startX;
                        DrawingModel.getInstance().GetLast().endY = e.Y;
                        Bottom_lable_straight.Text = "Прямая вертикальная линия |";
                        DrawPanel.Invalidate();
                    }
                    else
                    {
                        DrawingModel.getInstance().GetLast().endX = e.X;
                        DrawingModel.getInstance().GetLast().endY = e.Y;
                        Bottom_lable_straight.Text = "no";
                        DrawPanel.Invalidate();
                    }
                    break;

                case DrawMode.Point:
                    //g.DrawLine(pen, startX,startY, endX, endY);
                    //startX = e.X;
                    //startY = e.Y;
                    DrawPanel.Invalidate();
                    break;

                case DrawMode.Ellipse:
                    if (DrawingModel.getInstance().GetLast() == null) break;
                    //toolStripButton_createEllipse.BackColor = Color.Yellow;
                    DrawingModel.getInstance().GetLast().endX = e.X;
                    DrawingModel.getInstance().GetLast().endY = e.Y;
                    DrawPanel.Invalidate();
                    break;

                case DrawMode.Rectangle:
                    if (DrawingModel.getInstance().GetLast() == null) break;
                    //toolStripButton_createEllipse.BackColor = Color.Yellow;
                    DrawingModel.getInstance().GetLast().endX = e.X;
                    DrawingModel.getInstance().GetLast().endY = e.Y;
                    DrawPanel.Invalidate();
                    break;

                case DrawMode.Text:
                    if (DrawingModel.getInstance().GetLast() == null) break;
                    //toolStripButton_createText.BackColor = Color.Yellow;
                    DrawingModel.getInstance().GetLast().endX = e.X;
                    DrawingModel.getInstance().GetLast().endY = e.Y;
                    DrawPanel.Invalidate();
                    break;

                case DrawMode.DragImg:
                    if (DrawingModel.getInstance().GetLast() == null) break;     
                    //toolStripButton_createText.BackColor = Color.Yellow;
                    DrawingModel.getInstance().GetLast().endX = e.X- LoadTempImg.Width / 2;
                    DrawingModel.getInstance().GetLast().endY = e.Y- LoadTempImg.Height / 2;
                    DrawPanel.Invalidate();
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region Сервис

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Photo Paint — многофункциональный, растровый графический редактор. \n" +
                "Версия: 0.6 \n" +
                "Автор: Дьяков Руслан", "Про PhotoPaint");
        }

        private void СправкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpAbout helpAbout = new HelpAbout();
            helpAbout.ShowDialog();
        }

        #endregion

        #region Выбор типа наконечника линии

        private void StartCap_type3_Click_1(object sender, EventArgs e)
        {
            pen.StartCap = LineCap.Round;
            toolStrip_StartPen.Image = StartCap_type3.Image;
        }

        private void StartCap_type7_Click_1(object sender, EventArgs e)
        {
            pen.StartCap = LineCap.Triangle;
            toolStrip_StartPen.Image = StartCap_type7.Image;
        }

        private void StartCap_type2_Click(object sender, EventArgs e)
        {
            pen.StartCap = LineCap.ArrowAnchor;
            toolStrip_StartPen.Image = StartCap_type2.Image;
        }

        private void StartCap_type4_Click(object sender, EventArgs e)
        {
            pen.StartCap = LineCap.DiamondAnchor;
            toolStrip_StartPen.Image = StartCap_type4.Image;
        }

        private void StartCap_type6_Click(object sender, EventArgs e)
        {
            pen.StartCap = LineCap.NoAnchor;
            toolStrip_StartPen.Image = StartCap_type1.Image;
        }

        private void StartCap_type8_Click(object sender, EventArgs e)
        {
            pen.StartCap = LineCap.RoundAnchor;
            toolStrip_StartPen.Image = StartCap_type5.Image;
        }

        private void StartCap_type10_Click(object sender, EventArgs e)
        {
            pen.StartCap = LineCap.SquareAnchor;
            toolStrip_StartPen.Image = StartCap_type6.Image;
        }

        /// <summary>
        /// CapEnd
        /// </summary>

        private void StartCapEnd_type1_Click(object sender, EventArgs e)
        {
            pen.EndCap = LineCap.NoAnchor;
            toolStrip_EndPen.Image = StartCapEnd_type1.Image;
        }

        private void StartCapEnd_type2_Click(object sender, EventArgs e)
        {
            pen.EndCap = LineCap.ArrowAnchor;
            toolStrip_EndPen.Image = StartCapEnd_type2.Image;
        }

        private void StartCapEnd_type3_Click(object sender, EventArgs e)
        {
            pen.EndCap = LineCap.Round;
            toolStrip_EndPen.Image = StartCapEnd_type3.Image;
        }

        private void StartCapEnd_type4_Click(object sender, EventArgs e)
        {
            pen.EndCap = LineCap.DiamondAnchor;
            toolStrip_EndPen.Image = StartCapEnd_type4.Image;
        }

        private void StartCapEnd_type5_Click(object sender, EventArgs e)
        {
            pen.EndCap = LineCap.RoundAnchor;
            toolStrip_EndPen.Image = StartCapEnd_type5.Image;
        }

        private void StartCapEnd_type6_Click(object sender, EventArgs e)
        {
            pen.EndCap = LineCap.SquareAnchor;
            toolStrip_EndPen.Image = StartCapEnd_type6.Image;
        }

        private void StartCapEnd_type7_Click(object sender, EventArgs e)
        {
            pen.EndCap = LineCap.Triangle;
            toolStrip_EndPen.Image = StartCapEnd_type7.Image;
        }

        #endregion

        #region Меню файл

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start formS = new Start();
            formS.Show();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new SaveFileDialog();
            f.FileName = "new";
            f.Filter = "*.xml| *.xml";
            if (f.ShowDialog() != DialogResult.OK) return;
           // DrawingModel.getInstance().saveToXml(f.FileName);
            try
            {
                DrawingModel.getInstance().saveToXml(f.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void открытьXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fName = "";
            var f = new OpenFileDialog();
            f.Filter = "*.xml| *.xml";

            if (f.ShowDialog() != DialogResult.OK) return;
            try
            {
                fName = f.FileName;
                DrawingModel.getInstance().loadToXml(fName);
                DrawPanel.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.FileName = "Untitled";
            dlg.Filter = "";
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");
            dlg.DefaultExt = ".png";

            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                Bitmap toSave = new Bitmap(DrawPanel.Width, DrawPanel.Height);
                Graphics g = Graphics.FromImage(toSave);
                g.Clear(DrawPanel.BackColor);
                DrawingModel.getInstance().Paint(g);
                toSave.Save(dlg.FileName, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить холст!\nПопробуйте изменить размер", "Error");
                return;
            }

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var dlg = new OpenFileDialog();
            dlg.Filter = "";
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");
            dlg.DefaultExt = ".png";

            if (dlg.ShowDialog() != DialogResult.OK) return;
            try
            {
                Bitmap toOpen = new Bitmap(dlg.FileName);
                DrawPanel.BackgroundImage = toOpen;
                DrawPanel.Width = toOpen.Width;
                DrawPanel.Height = toOpen.Height;
                toolStripTextBox_width.Text = $"{toOpen.Width}";
                toolStripTextBox_height.Text = $"{toOpen.Height}";


                DrawPanel.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть холст!\nПопробуйте изменить размер", "Error");
                return;
            }
        }


        private void предварительныйпросмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preview preview = new Preview(DrawPanel);
            preview.ShowDialog();
        }

        #endregion

        #region Меню правка

        private void отменадействияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DrawingModel.getInstance().canUndo())
                DrawingModel.getInstance().undo2();
            DrawPanel.Invalidate();
        }

        private void повторДействияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DrawingModel.getInstance().canRedo())
                DrawingModel.getInstance().redo();
            DrawPanel.Invalidate();
        }

        private void вставкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "";
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");
            dlg.DefaultExt = ".png";

            if (dlg.ShowDialog() != DialogResult.OK) return;
            LoadTempImg = new Bitmap(dlg.FileName);

            ChangeSizeimg changeF = new ChangeSizeimg(DrawPanel.Width, DrawPanel.Height, LoadTempImg.Width, LoadTempImg.Height);
            if (changeF.ShowDialog() != DialogResult.OK) return;
            DrawPanel.Width = changeF.w_f;
            DrawPanel.Height = changeF.h_f;
            int w_i = changeF.w_i;
            int h_i = changeF.h_i;
            LoadTempImg = new Bitmap(LoadTempImg, w_i, h_i);

            isLoadTempImg = true;
            CurrentDraw = DrawMode.DragImg;
            DrawPanel.Invalidate();
        }

        #endregion

        #region Полосы прокрутки

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

            if (hScrollBar1.Value > lastposX)
            {
                var location = DrawPanel.Location;
                location.X -= 1;
                DrawPanel.Location = location;
                lastposX = hScrollBar1.Value;
            }
            else if (hScrollBar1.Value < lastposX)
            {
                var location = DrawPanel.Location;
                location.X += 1;
                DrawPanel.Location = location;
                lastposX = hScrollBar1.Value;
            }
        }

        private void DrawPanel_Resize(object sender, EventArgs e)
        {
            if (DrawPanel.Width < this.Width)
            {
                hScrollBar1.Hide();
            }
            else
            {
                hScrollBar1.Show();
                int r = DrawPanel.Width - this.Width;
                hScrollBar1.Maximum = r;
            }

            if (DrawPanel.Height < this.Height)
            {
                vScrollBar1.Hide();
            }
            else
            {
                vScrollBar1.Show();
                int r = DrawPanel.Height - this.Height;
                vScrollBar1.Maximum = r;
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (DrawPanel.Width < this.Width)
            {
                hScrollBar1.Hide();
            }
            else
            {
                hScrollBar1.Show();
                int r = DrawPanel.Width - this.Width;
                hScrollBar1.Maximum = r;
            }

            if (DrawPanel.Height < this.Height)
            {
                vScrollBar1.Hide();
            }
            else
            {
                vScrollBar1.Show();
                int r = DrawPanel.Height - this.Height;
                vScrollBar1.Maximum = r;
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (vScrollBar1.Value > lastposY)
            {
                var location = DrawPanel.Location;
                location.Y -= 1;
                DrawPanel.Location = location;
                lastposY = vScrollBar1.Value;
            }
            else if (vScrollBar1.Value < lastposY)
            {
                var location = DrawPanel.Location;
                location.Y += 1;
                DrawPanel.Location = location;
                lastposY = vScrollBar1.Value;
            }
        }

        #endregion

        #region DashStyle

        private void DashStyle_Solid_Click(object sender, EventArgs e)
        {
            pen.DashStyle = DashStyle.Solid;
            ts_DashStyle.Image = DashStyle_Solid.Image;
        }

        private void DashStyle_Dash_Click(object sender, EventArgs e)
        {
            pen.DashStyle = DashStyle.Dash;
            ts_DashStyle.Image = DashStyle_Dash.Image;
        }

        private void DashStyle_DashDot_Click(object sender, EventArgs e)
        {
            pen.DashStyle = DashStyle.DashDot;
            ts_DashStyle.Image = DashStyle_DashDot.Image;
        }

        private void DashStyle_Dash_Dot_Dot_Click(object sender, EventArgs e)
        {
            pen.DashStyle = DashStyle.DashDotDot;
            ts_DashStyle.Image = DashStyle_Dash_Dot_Dot.Image;
        }

        private void DashStyle_Dot_Click(object sender, EventArgs e)
        {
            pen.DashStyle = DashStyle.Dot;
            ts_DashStyle.Image = DashStyle_Dot.Image;
        }

        #endregion


        #region Переменные

        public Start startForm;
        public int width_panel = 500;
        public int height_panel = 500;
        public Color backColor_panel = Color.LightGray;

        enum DrawMode { None, Point, Line, Ellipse, Rectangle, Text, DragImg };
        DrawMode CurrentDraw = DrawMode.None;
        bool isDrawing = false;

        public int startX, startY;
        public int endX, endY;
        public Pen pen;
        public Font newFont = new Font("Arial", 20);
        public String newText = "Sample Text";
        public Point Ppoint;

        public GradientType BrashType = GradientType.Transparent;

        public Color lgbFrom = Color.AliceBlue;
        public Color lgbTo = Color.Aqua;
        public float lgbPos = 0;

        public Color solidG = Color.Black;

        public HatchStyle hatchStyle;
        static int lastposX = 3;
        static int lastposY = 3;

        public Bitmap LoadTempImg;
        bool isLoadTempImg = false;

       

        public Color hatchColor;

        public string TextureBmp;

        #endregion
    }
}
