namespace DeTaiLTCSDL
{
    partial class Form_Main
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
            this.pnlTong = new System.Windows.Forms.Panel();
            this.pn_Menu = new Guna.UI.WinForms.GunaPanel();
            this.lblNameUser = new System.Windows.Forms.Label();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.btnCustomer = new Guna.UI.WinForms.GunaButton();
            this.btnStatistic = new Guna.UI.WinForms.GunaButton();
            this.btnLogout = new Guna.UI.WinForms.GunaButton();
            this.btnManager = new Guna.UI.WinForms.GunaButton();
            this.btnSell = new Guna.UI.WinForms.GunaButton();
            this.gunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.pn_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTong
            // 
            this.pnlTong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTong.BackColor = System.Drawing.Color.White;
            this.pnlTong.Location = new System.Drawing.Point(207, 0);
            this.pnlTong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlTong.Name = "pnlTong";
            this.pnlTong.Size = new System.Drawing.Size(954, 694);
            this.pnlTong.TabIndex = 3;
            // 
            // pn_Menu
            // 
            this.pn_Menu.BackColor = System.Drawing.Color.White;
            this.pn_Menu.Controls.Add(this.gunaButton1);
            this.pn_Menu.Controls.Add(this.lblNameUser);
            this.pn_Menu.Controls.Add(this.gunaPictureBox1);
            this.pn_Menu.Controls.Add(this.btnCustomer);
            this.pn_Menu.Controls.Add(this.btnStatistic);
            this.pn_Menu.Controls.Add(this.btnLogout);
            this.pn_Menu.Controls.Add(this.btnManager);
            this.pn_Menu.Controls.Add(this.btnSell);
            this.pn_Menu.Controls.Add(this.gunaSeparator1);
            this.pn_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_Menu.Location = new System.Drawing.Point(0, 0);
            this.pn_Menu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pn_Menu.Name = "pn_Menu";
            this.pn_Menu.Size = new System.Drawing.Size(202, 640);
            this.pn_Menu.TabIndex = 2;
            // 
            // lblNameUser
            // 
            this.lblNameUser.AutoSize = true;
            this.lblNameUser.Location = new System.Drawing.Point(66, 102);
            this.lblNameUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNameUser.Name = "lblNameUser";
            this.lblNameUser.Size = new System.Drawing.Size(47, 13);
            this.lblNameUser.TabIndex = 8;
            this.lblNameUser.Text = "thienson";
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.ErrorImage = null;
            this.gunaPictureBox1.Image = global::DeTaiLTCSDL.Properties.Resources.user;
            this.gunaPictureBox1.Location = new System.Drawing.Point(60, 34);
            this.gunaPictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(59, 54);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaPictureBox1.TabIndex = 7;
            this.gunaPictureBox1.TabStop = false;
            // 
            // btnCustomer
            // 
            this.btnCustomer.AnimationHoverSpeed = 0.07F;
            this.btnCustomer.AnimationSpeed = 0.03F;
            this.btnCustomer.BaseColor = System.Drawing.Color.White;
            this.btnCustomer.BorderColor = System.Drawing.Color.Black;
            this.btnCustomer.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCustomer.FocusedColor = System.Drawing.Color.Empty;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnCustomer.Image = global::DeTaiLTCSDL.Properties.Resources.group_users;
            this.btnCustomer.ImageOffsetX = 5;
            this.btnCustomer.ImageSize = new System.Drawing.Size(30, 30);
            this.btnCustomer.Location = new System.Drawing.Point(16, 346);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnCustomer.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnCustomer.OnHoverForeColor = System.Drawing.Color.White;
            this.btnCustomer.OnHoverImage = null;
            this.btnCustomer.OnPressedColor = System.Drawing.Color.Black;
            this.btnCustomer.Size = new System.Drawing.Size(172, 45);
            this.btnCustomer.TabIndex = 6;
            this.btnCustomer.Text = "Khách hàng";
            this.btnCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnStatistic
            // 
            this.btnStatistic.AnimationHoverSpeed = 0.07F;
            this.btnStatistic.AnimationSpeed = 0.03F;
            this.btnStatistic.BaseColor = System.Drawing.Color.White;
            this.btnStatistic.BorderColor = System.Drawing.Color.Black;
            this.btnStatistic.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStatistic.FocusedColor = System.Drawing.Color.Empty;
            this.btnStatistic.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnStatistic.Image = global::DeTaiLTCSDL.Properties.Resources.bar_chart;
            this.btnStatistic.ImageOffsetX = 5;
            this.btnStatistic.ImageSize = new System.Drawing.Size(30, 30);
            this.btnStatistic.Location = new System.Drawing.Point(16, 284);
            this.btnStatistic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnStatistic.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnStatistic.OnHoverForeColor = System.Drawing.Color.White;
            this.btnStatistic.OnHoverImage = null;
            this.btnStatistic.OnPressedColor = System.Drawing.Color.Black;
            this.btnStatistic.Size = new System.Drawing.Size(172, 45);
            this.btnStatistic.TabIndex = 5;
            this.btnStatistic.Text = "Thống kê";
            this.btnStatistic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AnimationHoverSpeed = 0.07F;
            this.btnLogout.AnimationSpeed = 0.03F;
            this.btnLogout.BaseColor = System.Drawing.Color.White;
            this.btnLogout.BorderColor = System.Drawing.Color.Black;
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogout.FocusedColor = System.Drawing.Color.Empty;
            this.btnLogout.Font = new System.Drawing.Font("Book Antiqua", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnLogout.Image = global::DeTaiLTCSDL.Properties.Resources.sign_out;
            this.btnLogout.ImageOffsetX = 5;
            this.btnLogout.ImageSize = new System.Drawing.Size(30, 30);
            this.btnLogout.Location = new System.Drawing.Point(16, 552);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnLogout.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLogout.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLogout.OnHoverImage = null;
            this.btnLogout.OnPressedColor = System.Drawing.Color.Black;
            this.btnLogout.Size = new System.Drawing.Size(164, 45);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Log out";
            this.btnLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnManager
            // 
            this.btnManager.AnimationHoverSpeed = 0.07F;
            this.btnManager.AnimationSpeed = 0.03F;
            this.btnManager.BackColor = System.Drawing.Color.Transparent;
            this.btnManager.BaseColor = System.Drawing.Color.White;
            this.btnManager.BorderColor = System.Drawing.Color.Black;
            this.btnManager.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnManager.FocusedColor = System.Drawing.Color.Empty;
            this.btnManager.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnManager.Image = global::DeTaiLTCSDL.Properties.Resources.data_management;
            this.btnManager.ImageOffsetX = 5;
            this.btnManager.ImageSize = new System.Drawing.Size(30, 30);
            this.btnManager.Location = new System.Drawing.Point(16, 228);
            this.btnManager.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnManager.Name = "btnManager";
            this.btnManager.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnManager.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnManager.OnHoverForeColor = System.Drawing.Color.White;
            this.btnManager.OnHoverImage = null;
            this.btnManager.OnPressedColor = System.Drawing.Color.Black;
            this.btnManager.Size = new System.Drawing.Size(172, 45);
            this.btnManager.TabIndex = 2;
            this.btnManager.Text = "Quản lý";
            this.btnManager.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // btnSell
            // 
            this.btnSell.AnimationHoverSpeed = 0.07F;
            this.btnSell.AnimationSpeed = 0.03F;
            this.btnSell.BaseColor = System.Drawing.Color.White;
            this.btnSell.BorderColor = System.Drawing.Color.Black;
            this.btnSell.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSell.FocusedColor = System.Drawing.Color.Empty;
            this.btnSell.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.btnSell.Image = global::DeTaiLTCSDL.Properties.Resources.add;
            this.btnSell.ImageOffsetX = 5;
            this.btnSell.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSell.Location = new System.Drawing.Point(16, 170);
            this.btnSell.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSell.Name = "btnSell";
            this.btnSell.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSell.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSell.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSell.OnHoverImage = null;
            this.btnSell.OnPressedColor = System.Drawing.Color.Black;
            this.btnSell.Size = new System.Drawing.Size(172, 45);
            this.btnSell.TabIndex = 1;
            this.btnSell.Text = "Lập hóa đơn";
            this.btnSell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // gunaSeparator1
            // 
            this.gunaSeparator1.LineColor = System.Drawing.Color.Silver;
            this.gunaSeparator1.Location = new System.Drawing.Point(9, 133);
            this.gunaSeparator1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gunaSeparator1.Name = "gunaSeparator1";
            this.gunaSeparator1.Size = new System.Drawing.Size(178, 9);
            this.gunaSeparator1.TabIndex = 0;
            // 
            // gunaButton1
            // 
            this.gunaButton1.AnimationHoverSpeed = 0.07F;
            this.gunaButton1.AnimationSpeed = 0.03F;
            this.gunaButton1.BaseColor = System.Drawing.Color.White;
            this.gunaButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.gunaButton1.Image = global::DeTaiLTCSDL.Properties.Resources.group_users;
            this.gunaButton1.ImageOffsetX = 5;
            this.gunaButton1.ImageSize = new System.Drawing.Size(30, 30);
            this.gunaButton1.Location = new System.Drawing.Point(16, 395);
            this.gunaButton1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton1.Size = new System.Drawing.Size(172, 45);
            this.gunaButton1.TabIndex = 9;
            this.gunaButton1.Text = "Tìm Hóa đơn";
            this.gunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton1.Click += new System.EventHandler(this.gunaButton1_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.pnlTong);
            this.Controls.Add(this.pn_Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pn_Menu.ResumeLayout(false);
            this.pn_Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTong;
        private Guna.UI.WinForms.GunaPanel pn_Menu;
        private System.Windows.Forms.Label lblNameUser;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaButton btnCustomer;
        private Guna.UI.WinForms.GunaButton btnStatistic;
        private Guna.UI.WinForms.GunaButton btnLogout;
        private Guna.UI.WinForms.GunaButton btnManager;
        private Guna.UI.WinForms.GunaButton btnSell;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator1;
        private Guna.UI.WinForms.GunaButton gunaButton1;
    }
}