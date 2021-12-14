
namespace DeTaiLTCSDL
{
    partial class Form_SearchCustom
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gunaGroupBox2 = new Guna.UI.WinForms.GunaGroupBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.gunaPictureBox2 = new Guna.UI.WinForms.GunaPictureBox();
            this.txtTimKiem = new Guna.UI.WinForms.GunaTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id_Hd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.gunaGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.gunaGroupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 105);
            this.panel1.TabIndex = 6;
            // 
            // gunaGroupBox2
            // 
            this.gunaGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox2.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox2.Controls.Add(this.btnSearch);
            this.gunaGroupBox2.Controls.Add(this.gunaPictureBox2);
            this.gunaGroupBox2.Controls.Add(this.txtTimKiem);
            this.gunaGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaGroupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.gunaGroupBox2.ForeColor = System.Drawing.Color.White;
            this.gunaGroupBox2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.gunaGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.gunaGroupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.gunaGroupBox2.Name = "gunaGroupBox2";
            this.gunaGroupBox2.Radius = 20;
            this.gunaGroupBox2.Size = new System.Drawing.Size(932, 91);
            this.gunaGroupBox2.TabIndex = 1;
            this.gunaGroupBox2.Text = "Tìm kiếm";
            this.gunaGroupBox2.TextLocation = new System.Drawing.Point(430, 4);
            // 
            // btnSearch
            // 
            this.btnSearch.CheckedState.Parent = this.btnSearch;
            this.btnSearch.CustomImages.Parent = this.btnSearch;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverState.Parent = this.btnSearch;
            this.btnSearch.Location = new System.Drawing.Point(581, 48);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ShadowDecoration.Parent = this.btnSearch;
            this.btnSearch.Size = new System.Drawing.Size(89, 28);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gunaPictureBox2
            // 
            this.gunaPictureBox2.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox2.Image = global::DeTaiLTCSDL.Properties.Resources.search;
            this.gunaPictureBox2.Location = new System.Drawing.Point(271, 44);
            this.gunaPictureBox2.Margin = new System.Windows.Forms.Padding(2);
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
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PasswordChar = '\0';
            this.txtTimKiem.Radius = 5;
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(256, 29);
            this.txtTimKiem.TabIndex = 12;
            this.txtTimKiem.Text = "Tìm Kiếm";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Hd,
            this.TenSanPham,
            this.SoLuong,
            this.TenKH});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(932, 535);
            this.dataGridView1.TabIndex = 7;
            // 
            // Id_Hd
            // 
            this.Id_Hd.DataPropertyName = "Id_Hd";
            this.Id_Hd.HeaderText = "Số Hóa đơn";
            this.Id_Hd.Name = "Id_Hd";
            // 
            // TenSanPham
            // 
            this.TenSanPham.DataPropertyName = "TenSanPham";
            this.TenSanPham.HeaderText = "Sản phẩm";
            this.TenSanPham.Name = "TenSanPham";
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            // 
            // TenKH
            // 
            this.TenKH.DataPropertyName = "TenKH";
            this.TenKH.HeaderText = "Tên khách hàng";
            this.TenKH.Name = "TenKH";
            // 
            // Form_SearchCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 640);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_SearchCustom";
            this.Text = "Form_Customer";
            this.panel1.ResumeLayout(false);
            this.gunaGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox2;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox2;
        private Guna.UI.WinForms.GunaTextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Hd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
    }
}