﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PhotoPaint
{
    public partial class FillGradient : Form
    {
        public Main mother;
        public FillGradient()
        {
            InitializeComponent();
            b_start.BackColor = lgbFrom;
            b_end.BackColor = lgbTo;
            textBox.Text = "0";
            cb_patern_type.DataSource = Enum.GetNames(typeof(HatchStyle));
            cb_patern_type.SelectedIndex = 1;
            b_patern_setColor.BackColor = hatchColor;
        }

        #region LineGradient

        public Color lgbFrom = Color.White;
        public Color lgbTo = Color.Black;
        public float lgbPos = 0;

        public GradientType BrashType;

        private void b_start_Click(object sender, EventArgs e)
        {
            var startColor = new ColorDialog();
            startColor.Color = lgbFrom;
            if (startColor.ShowDialog() != DialogResult.OK) return;
            lgbFrom = startColor.Color;
            groupBox2.Invalidate();
            b_start.BackColor = lgbFrom;
        }

        private void b_end_Click(object sender, EventArgs e)
        {
            var endColor = new ColorDialog();
            endColor.Color = lgbTo;
            if (endColor.ShowDialog() != DialogResult.OK) return;
            lgbTo = endColor.Color;
            groupBox2.Invalidate();
            b_end.BackColor = lgbTo;
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            textBox.Text = Convert.ToString(trackBar.Value);
            lgbPos = trackBar.Value;
            groupBox2.Invalidate();
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectLGB = new Rectangle(18, 54, 365, 40);
            Graphics g = e.Graphics;
            LinearGradientBrush lgb = new LinearGradientBrush
                (rectLGB, lgbFrom, lgbTo, lgbPos, true);
            g.FillRectangle(lgb, rectLGB);
            g.Dispose();
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void b_cancle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void tP_LineGradient_Enter(object sender, EventArgs e)
        {
            BrashType = GradientType.Line;
        }

        #region Заготовки

        private void b_patern_1_Click(object sender, EventArgs e)
        {
            lgbFrom = Color.White;
            lgbTo = Color.Black;
            b_start.BackColor = lgbFrom;
            b_end.BackColor = lgbTo;
            groupBox2.Invalidate();
        }

        private void b_patern_2_Click(object sender, EventArgs e)
        {
            lgbFrom = Color.Red;
            lgbTo = Color.Green;
            b_start.BackColor = lgbFrom;
            b_end.BackColor = lgbTo;
            groupBox2.Invalidate();
        }

        private void b_patern_3_Click(object sender, EventArgs e)
        {
            lgbFrom = Color.Blue;
            lgbTo = Color.Orange;
            b_start.BackColor = lgbFrom;
            b_end.BackColor = lgbTo;
            groupBox2.Invalidate();
        }

        private void b_patern_4_Click(object sender, EventArgs e)
        {
            lgbFrom = Color.DeepPink;
            lgbTo = Color.LightGreen;
            b_start.BackColor = lgbFrom;
            b_end.BackColor = lgbTo;
            groupBox2.Invalidate();
        }

        private void b_patern_5_Click(object sender, EventArgs e)
        {
            lgbFrom = Color.DarkViolet;
            lgbTo = Color.DarkGreen;
            b_start.BackColor = lgbFrom;
            b_end.BackColor = lgbTo;
            groupBox2.Invalidate();
        }

        private void b_patern_6_Click(object sender, EventArgs e)
        {
            lgbFrom = Color.Cyan;
            lgbTo = Color.SandyBrown;
            b_start.BackColor = lgbFrom;
            b_end.BackColor = lgbTo;
            groupBox2.Invalidate();
        }

        private void b_patern_7_Click(object sender, EventArgs e)
        {
            lgbFrom = Color.Red;
            lgbTo = Color.Yellow;
            b_start.BackColor = lgbFrom;
            b_end.BackColor = lgbTo;
            groupBox2.Invalidate();
        }

        private void b_patern_8_Click(object sender, EventArgs e)
        {
            lgbFrom = Color.DeepSkyBlue;
            lgbTo = Color.Red;
            b_start.BackColor = lgbFrom;
            b_end.BackColor = lgbTo;
            groupBox2.Invalidate();
        }

        private void b_patern_9_Click(object sender, EventArgs e)
        {
            lgbFrom = Color.Brown;
            lgbTo = Color.SandyBrown;
            b_start.BackColor = lgbFrom;
            b_end.BackColor = lgbTo;
            groupBox2.Invalidate();
        }

        private void b_patern_10_Click(object sender, EventArgs e)
        {
            lgbFrom = Color.DeepPink;
            lgbTo = Color.ForestGreen;
            b_start.BackColor = lgbFrom;
            b_end.BackColor = lgbTo;
            groupBox2.Invalidate();
        }




        #endregion

        #endregion

        #region HatchFilled

        public HatchStyle hatchStyle = HatchStyle.LargeConfetti;
        public Color hatchColor = Color.Orange;

        private void b_patern_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void b_patern_cancle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void b_patern_setColor_Click(object sender, EventArgs e)
        {
            var color = new ColorDialog();
            color.Color = hatchColor;
            if (color.ShowDialog() != DialogResult.OK) return;
            hatchColor = color.Color;
            b_patern_setColor.BackColor = hatchColor;
            groupBox6.Invalidate();
        }
       
        #region Заготовки
        private void b_patern_z1_Click(object sender, EventArgs e)
        {

        }

        private void b_patern_z2_Click(object sender, EventArgs e)
        {

        }

        private void b_patern_z3_Click(object sender, EventArgs e)
        {

        }

        private void b_patern_z4_Click(object sender, EventArgs e)
        {

        }

        private void b_patern_z5_Click(object sender, EventArgs e)
        {

        }

        private void b_patern_z6_Click(object sender, EventArgs e)
        {

        }

        private void b_patern_z7_Click(object sender, EventArgs e)
        {

        }

        private void b_patern_z8_Click(object sender, EventArgs e)
        {

        }

        private void b_patern_z9_Click(object sender, EventArgs e)
        {

        }

        private void b_patern_z10_Click(object sender, EventArgs e)
        {

        }
        #endregion
        
        private void cb_patern_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            hatchStyle = (HatchStyle)cb_patern_type.SelectedIndex;
            groupBox6.Invalidate();
        }

        private void groupBox6_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectHatch = new Rectangle(150, 25, 230, 145);
            Graphics g = e.Graphics;

            try
            {
                HatchBrush hatch = new HatchBrush(hatchStyle, hatchColor);
                g.FillRectangle(hatch, rectHatch);
                g.Dispose();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void tP_PageHatch_Enter(object sender, EventArgs e)
        {
            BrashType = GradientType.Hatch;
        }

        #endregion


        #region Img

        public string TextureBmp;

        private void b_img_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void b_img_cancle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void b_img_load_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.FileName = TextureBmp;
            if (fileDialog.ShowDialog() != DialogResult.OK) return;
            TextureBmp = fileDialog.FileName;
            groupBox8.Invalidate();
        }

        private void groupBox8_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectTexture = new Rectangle(150, 25, 230, 145);
            Graphics g = e.Graphics;
            try
            {
                TextureBrush textureBrush = new TextureBrush(new Bitmap(TextureBmp));
                g.FillRectangle(textureBrush, rectTexture);
                g.Dispose();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void tP_img_Enter(object sender, EventArgs e)
        {
            BrashType = GradientType.Image;
        }
        #endregion
    }
}
