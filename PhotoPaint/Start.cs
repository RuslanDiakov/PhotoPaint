using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PhotoPaint
{
    public partial class Start : Form
    {
        public int width;
        public int height;
        public Color backColor = Color.LightGray;
        Bitmap toOpen;
        Bitmap clear;
        bool load = false;
        Graphics g;
        public Start()
        {
            InitializeComponent();
            cb_backColor.SelectedIndex = 0;
            width = 500;
            height = 500;
            backColor = Color.LightGray;
        }
        private void Start_Load(object sender, EventArgs e)
        {

        }

        private void button_create_Click(object sender, EventArgs e)
        {
            width = Convert.ToInt32(tb_width.Text);
            height = Convert.ToInt32(tb_height.Text);
            backColor = button_checkBackColor.BackColor;

            //this.Hide(); 
            if (load)
            {
                Main LoadForm2 = new Main(width, height, backColor, toOpen);
                LoadForm2.Show();
            }
            else
            {
                Main LoadForm1 = new Main(width, height, backColor, clear);
                LoadForm1.Show();
            }
        }

        private void cb_backColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_backColor.SelectedIndex)
            {
                case 0:
                    button_checkBackColor.BackColor = Color.LightGray;
                    break;
                case 1:
                    button_checkBackColor.BackColor = Color.White;
                    break;
                case 2:
                    button_checkBackColor.BackColor = Color.Black;
                    break;
                default:
                    break;
            }
        }

        private void button_checkBackColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            colorDialog.Color = button_checkBackColor.BackColor;
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            button_checkBackColor.BackColor = colorDialog.Color;
            cb_backColor.SelectedIndex = 3;
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            HelpAbout helpAbout = new HelpAbout();
            helpAbout.ShowDialog();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_open_Click(object sender, EventArgs e)
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
                toOpen = new Bitmap(dlg.FileName);
                width = toOpen.Width;
                height = toOpen.Height;
                tb_width.Text = Convert.ToString(width);
                tb_height.Text = Convert.ToString(height);
                groupBox2.Invalidate();
                load = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть холст!\nПопробуйте изменить размер", "Error");
                return;
            }
        }
        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            if (load)
            {
                Bitmap objBitmap = new Bitmap(toOpen, new Size(180, 120));
                Rectangle rectTexture = new Rectangle(10, 215, 180, 120);               
                try
                {
                    TextureBrush textureBrush = new TextureBrush(objBitmap);
                    //g.FillRectangle(textureBrush, rectTexture);
                    PointF ulCorner = new PointF(10.0F, 215.0F);
                    g.DrawImage(objBitmap, ulCorner);
                    g.Dispose();
                }
                catch (Exception)
                {
                    return;
                }
            }
            if(delImg)
            {              
                SolidBrush solid = new SolidBrush(Color.DimGray);
                Rectangle r = new Rectangle(10, 215, 180, 120);
                g.FillRectangle(solid, r);
                groupBox2.Invalidate();
                delImg = false;
            }

        }
        bool delImg = false;
        private void button_clear_Click(object sender, EventArgs e)
        {
            delImg = true;
            load = false;
            tb_width.Text = "500";
            tb_height.Text = "500";
            button_checkBackColor.BackColor = Color.LightGray;
            groupBox2.Invalidate();
        }

        #region КнопкиМакетов

        private void button_m_1_Click(object sender, EventArgs e)
        {
            tb_width.Text = "100";
            tb_height.Text = "100";
            cb_backColor.SelectedIndex = 0;
        }

        private void button_m_2_Click(object sender, EventArgs e)
        {
            tb_width.Text = "50";
            tb_height.Text = "50";
            cb_backColor.SelectedIndex = 0;
        }

        private void button_m_3_Click(object sender, EventArgs e)
        {
            tb_width.Text = "200";
            tb_height.Text = "200";
            cb_backColor.SelectedIndex = 0;
        }

        private void button_m_4_Click(object sender, EventArgs e)
        {
            tb_width.Text = "1000";
            tb_height.Text = "500";
            cb_backColor.SelectedIndex = 0;
        }

        private void button_m_5_Click(object sender, EventArgs e)
        {
            tb_width.Text = "1280";
            tb_height.Text = "720";
            cb_backColor.SelectedIndex = 0;
        }

        private void button_m_6_Click(object sender, EventArgs e)
        {
            tb_width.Text = "1500";
            tb_height.Text = "800";
            cb_backColor.SelectedIndex = 0;
        }


        #endregion

       
    }
}
