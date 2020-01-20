using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoPaint
{
    public partial class Start : Form
    {
        public int width = 1200;
        public int height = 500;
        public Color backColor = Color.LightGray;


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
            Main LoadForm = new Main(width, height, backColor);
            LoadForm.Show();
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

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
