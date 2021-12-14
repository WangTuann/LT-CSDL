namespace DeTaiLTCSDL
{
    partial class Form_Customer
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
            this.components = new System.ComponentModel.Container();
            this.lvKH = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiChiTietHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gunaGroupBox1 = new Guna.UI.WinForms.GunaGroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gunaGroupBox2 = new Guna.UI.WinForms.GunaGroupBox();
            this.gunaPictureBox2 = new Guna.UI.WinForms.GunaPictureBox();
            this.txtTimKiem = new Guna.UI.WinForms.GunaTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gunaGroupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gunaGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lvKH
            // 
            this.lvKH.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvKH.ContextMenuStrip = this.contextMenuStrip1;
            this.lvKH.FullRowSelect = true;
            this.lvKH.GridLines = true;
            this.lvKH.HideSelection = false;
            this.lvKH.Location = new System.Drawing.Point(9, 41);
            this.lvKH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvKH.MultiSelect = false;
            this.lvKH.Name = "lvKH";
            this.lvKH.Size = new System.Drawing.Size(938, 504);
            this.lvKH.TabIndex = 0;
            this.lvKH.UseCompatibleStateImageBehavior = false;
            this.lvKH.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mã hóa đơn";
            this.columnHeader4.Width = 313;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tên khách hàng";
            this.columnHeader5.Width = 343;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Số điện thoại";
            this.columnHeader6.Width = 329;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiChiTietHoaDon});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 26);
            // 
            // tsmiChiTietHoaDon
            // 
            this.tsmiChiTietHoaDon.Name = "tsmiChiTietHoaDon";
            this.tsmiChiTietHoaDon.Size = new System.Drawing.Size(191, 22);
            this.tsmiChiTietHoaDon.Text = "Xem chi tiết đơn hàng";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.gunaGroupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 105);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(932, 546);
            this.panel2.TabIndex = 7;
            // 
            // gunaGroupBox1
            // 
            this.gunaGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox1.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Controls.Add(this.lvKH);
            this.gunaGroupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGroupBox1.ForeColor = System.Drawing.Color.White;
            this.gunaGroupBox1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.gunaGroupBox1.Location = new System.Drawing.Point(0, 9);
            this.gunaGroupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gunaGroupBox1.Name = "gunaGroupBox1";
            this.gunaGroupBox1.Radius = 15;
            this.gunaGroupBox1.Size = new System.Drawing.Size(932, 581);
            this.gunaGroupBox1.TabIndex = 0;
            this.gunaGroupBox1.Text = "Danh sách khách hàng";
            this.gunaGroupBox1.TextLocation = new System.Drawing.Point(400, 5);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.gunaGroupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 105);
            this.panel1.TabIndex = 6;
            // 
            // gunaGroupBox2
            // 
            this.gunaGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox2.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox2.Controls.Add(this.gunaPictureBox2);
            this.gunaGroupBox2.Controls.Add(this.txtTimKiem);
            this.gunaGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaGroupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.gunaGroupBox2.ForeColor = System.Drawing.Color.White;
            this.gunaGroupBox2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.gunaGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.gunaGroupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gunaGroupBox2.Name = "gunaGroupBox2";
            this.gunaGroupBox2.Radius = 20;
            this.gunaGroupBox2.Size = new System.Drawing.Size(932, 91);
            this.gunaGroupBox2.TabIndex = 1;
            this.gunaGroupBox2.Text = "Tìm kiếm";
            this.gunaGroupBox2.TextLocation = new System.Drawing.Point(430, 4);
            // 
            // gunaPictureBox2
            // 
            this.gunaPictureBox2.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox2.Image = global::DeTaiLTCSDL.Properties.Resources.search;
            this.gunaPictureBox2.Location = new System.Drawing.Point(271, 44);
            this.gunaPictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gunaPictureBox2.Name = "gunaPictureBox2";
            this.gunaPictureBox2.Size = new System.Drawing.Size(36, 36);
            this.gunaPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaPictureBox2.TabIndex = 13;
            this.gunaPictureBox2.TabStop = false;
           
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.txtTimKiem.BaseColor = System.Drawing.Color.White;
            this.txtTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.txtTimKiem.BorderSize = 1;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.FocusedBaseColor = System.Drawing.Color.White;
            this.txtTimKiem.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtTimKiem.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.ForeColor = System.Drawing.Color.Black;
            this.txtTimKiem.Location = new System.Drawing.Point(319, 48);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PasswordChar = '\0';
            this.txtTimKiem.Radius = 5;
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(256, 29);
            this.txtTimKiem.TabIndex = 12;
            this.txtTimKiem.Text = "Tìm Kiếm";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            this.txtTimKiem.Click += new System.EventHandler(this.txtTimKiem_Click);
            // 
            // Form_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 640);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_Customer";
            this.Text = "Form_Customer";
            this.Load += new System.EventHandler(this.Form_Customer_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gunaGroupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gunaGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvKH;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiChiTietHoaDon;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox2;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox2;
        private Guna.UI.WinForms.GunaTextBox txtTimKiem;
    }
}