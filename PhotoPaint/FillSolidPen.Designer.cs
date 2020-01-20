namespace PhotoPaint
{
    partial class FillSolidPen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FillSolidPen));
            this.b_ok = new System.Windows.Forms.Button();
            this.b_cancle = new System.Windows.Forms.Button();
            this.gb_Transparent = new System.Windows.Forms.GroupBox();
            this.b_transparent = new System.Windows.Forms.Button();
            this.gb_Color = new System.Windows.Forms.GroupBox();
            this.b_SelectColor = new System.Windows.Forms.Button();
            this.gb_Transparent.SuspendLayout();
            this.gb_Color.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_ok
            // 
            this.b_ok.BackColor = System.Drawing.Color.RoyalBlue;
            this.b_ok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_ok.Font = new System.Drawing.Font("Myriad Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_ok.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.b_ok.Location = new System.Drawing.Point(86, 137);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 0;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = false;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // b_cancle
            // 
            this.b_cancle.BackColor = System.Drawing.Color.Tomato;
            this.b_cancle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_cancle.Font = new System.Drawing.Font("Myriad Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_cancle.ForeColor = System.Drawing.Color.White;
            this.b_cancle.Location = new System.Drawing.Point(167, 137);
            this.b_cancle.Name = "b_cancle";
            this.b_cancle.Size = new System.Drawing.Size(75, 23);
            this.b_cancle.TabIndex = 1;
            this.b_cancle.Text = "Отмена";
            this.b_cancle.UseVisualStyleBackColor = false;
            this.b_cancle.Click += new System.EventHandler(this.b_cancle_Click);
            // 
            // gb_Transparent
            // 
            this.gb_Transparent.Controls.Add(this.b_transparent);
            this.gb_Transparent.Font = new System.Drawing.Font("Myriad Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gb_Transparent.ForeColor = System.Drawing.Color.White;
            this.gb_Transparent.Location = new System.Drawing.Point(12, 12);
            this.gb_Transparent.Name = "gb_Transparent";
            this.gb_Transparent.Size = new System.Drawing.Size(112, 119);
            this.gb_Transparent.TabIndex = 6;
            this.gb_Transparent.TabStop = false;
            this.gb_Transparent.Text = "Прозрачный";
            // 
            // b_transparent
            // 
            this.b_transparent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_transparent.Image = global::PhotoPaint.Properties.Resources.transparent;
            this.b_transparent.Location = new System.Drawing.Point(15, 26);
            this.b_transparent.Name = "b_transparent";
            this.b_transparent.Size = new System.Drawing.Size(75, 75);
            this.b_transparent.TabIndex = 2;
            this.b_transparent.UseVisualStyleBackColor = true;
            this.b_transparent.Click += new System.EventHandler(this.b_transparent_Click);
            // 
            // gb_Color
            // 
            this.gb_Color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gb_Color.Controls.Add(this.b_SelectColor);
            this.gb_Color.Font = new System.Drawing.Font("Myriad Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gb_Color.ForeColor = System.Drawing.Color.White;
            this.gb_Color.Location = new System.Drawing.Point(130, 12);
            this.gb_Color.Name = "gb_Color";
            this.gb_Color.Size = new System.Drawing.Size(112, 119);
            this.gb_Color.TabIndex = 7;
            this.gb_Color.TabStop = false;
            this.gb_Color.Text = "Цвет";
            // 
            // b_SelectColor
            // 
            this.b_SelectColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.b_SelectColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_SelectColor.Location = new System.Drawing.Point(19, 26);
            this.b_SelectColor.Name = "b_SelectColor";
            this.b_SelectColor.Size = new System.Drawing.Size(75, 75);
            this.b_SelectColor.TabIndex = 2;
            this.b_SelectColor.UseVisualStyleBackColor = false;
            this.b_SelectColor.Click += new System.EventHandler(this.b_SelectColor_Click);
            // 
            // FillSolidPen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(262, 180);
            this.Controls.Add(this.gb_Color);
            this.Controls.Add(this.gb_Transparent);
            this.Controls.Add(this.b_cancle);
            this.Controls.Add(this.b_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FillSolidPen";
            this.Text = "FillSolidPen";
            this.gb_Transparent.ResumeLayout(false);
            this.gb_Color.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Button b_cancle;
        private System.Windows.Forms.Button b_transparent;
        private System.Windows.Forms.GroupBox gb_Transparent;
        private System.Windows.Forms.GroupBox gb_Color;
        private System.Windows.Forms.Button b_SelectColor;
    }
}