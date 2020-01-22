namespace PhotoPaint
{
    partial class LayersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayersForm));
            this.lb_layers = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_up = new System.Windows.Forms.Button();
            this.b_up1 = new System.Windows.Forms.Button();
            this.b_down1 = new System.Windows.Forms.Button();
            this.b_down = new System.Windows.Forms.Button();
            this.b_cancle = new System.Windows.Forms.Button();
            this.b_save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_layers
            // 
            this.lb_layers.BackColor = System.Drawing.Color.DimGray;
            this.lb_layers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_layers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_layers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_layers.ForeColor = System.Drawing.Color.White;
            this.lb_layers.FormattingEnabled = true;
            this.lb_layers.ItemHeight = 18;
            this.lb_layers.Location = new System.Drawing.Point(3, 22);
            this.lb_layers.Name = "lb_layers";
            this.lb_layers.Size = new System.Drawing.Size(844, 339);
            this.lb_layers.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_layers);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 364);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Слои";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_cancle);
            this.groupBox2.Controls.Add(this.b_save);
            this.groupBox2.Controls.Add(this.b_down1);
            this.groupBox2.Controls.Add(this.b_down);
            this.groupBox2.Controls.Add(this.b_up1);
            this.groupBox2.Controls.Add(this.b_up);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(868, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 364);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Меню";
            // 
            // b_up
            // 
            this.b_up.BackColor = System.Drawing.Color.Green;
            this.b_up.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_up.Location = new System.Drawing.Point(6, 25);
            this.b_up.Name = "b_up";
            this.b_up.Size = new System.Drawing.Size(118, 26);
            this.b_up.TabIndex = 0;
            this.b_up.Text = "Вверх";
            this.b_up.UseVisualStyleBackColor = false;
            this.b_up.Click += new System.EventHandler(this.b_up_Click);
            // 
            // b_up1
            // 
            this.b_up1.BackColor = System.Drawing.Color.Green;
            this.b_up1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_up1.Location = new System.Drawing.Point(6, 57);
            this.b_up1.Name = "b_up1";
            this.b_up1.Size = new System.Drawing.Size(118, 26);
            this.b_up1.TabIndex = 1;
            this.b_up1.Text = "На 1 выше";
            this.b_up1.UseVisualStyleBackColor = false;
            this.b_up1.Click += new System.EventHandler(this.b_up1_Click);
            // 
            // b_down1
            // 
            this.b_down1.BackColor = System.Drawing.Color.Chocolate;
            this.b_down1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_down1.Location = new System.Drawing.Point(6, 184);
            this.b_down1.Name = "b_down1";
            this.b_down1.Size = new System.Drawing.Size(118, 26);
            this.b_down1.TabIndex = 3;
            this.b_down1.Text = "На 1 ниже";
            this.b_down1.UseVisualStyleBackColor = false;
            this.b_down1.Click += new System.EventHandler(this.b_down1_Click);
            // 
            // b_down
            // 
            this.b_down.BackColor = System.Drawing.Color.Chocolate;
            this.b_down.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_down.Location = new System.Drawing.Point(6, 152);
            this.b_down.Name = "b_down";
            this.b_down.Size = new System.Drawing.Size(118, 26);
            this.b_down.TabIndex = 2;
            this.b_down.Text = "Вниз";
            this.b_down.UseVisualStyleBackColor = false;
            this.b_down.Click += new System.EventHandler(this.b_down_Click);
            // 
            // b_cancle
            // 
            this.b_cancle.BackColor = System.Drawing.Color.OrangeRed;
            this.b_cancle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_cancle.Location = new System.Drawing.Point(6, 332);
            this.b_cancle.Name = "b_cancle";
            this.b_cancle.Size = new System.Drawing.Size(118, 26);
            this.b_cancle.TabIndex = 5;
            this.b_cancle.Text = "Отмена";
            this.b_cancle.UseVisualStyleBackColor = false;
            this.b_cancle.Click += new System.EventHandler(this.b_cancle_Click);
            // 
            // b_save
            // 
            this.b_save.BackColor = System.Drawing.Color.DodgerBlue;
            this.b_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_save.Location = new System.Drawing.Point(6, 300);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(118, 26);
            this.b_save.TabIndex = 4;
            this.b_save.Text = "Сохранить";
            this.b_save.UseVisualStyleBackColor = false;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // LayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1010, 389);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LayersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhotoPaint";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lb_layers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button b_cancle;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_down1;
        private System.Windows.Forms.Button b_down;
        private System.Windows.Forms.Button b_up1;
        private System.Windows.Forms.Button b_up;
    }
}