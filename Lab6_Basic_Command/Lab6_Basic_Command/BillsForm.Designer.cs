
namespace Lab6_Basic_Command
{
    partial class BillsForm
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
            this.dgvBill = new System.Windows.Forms.DataGridView();
            this.dtpNgayThangToi = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpNgayThangDi = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBill
            // 
            this.dgvBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBill.Location = new System.Drawing.Point(1, 69);
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBill.Size = new System.Drawing.Size(798, 381);
            this.dgvBill.TabIndex = 0;
            this.dgvBill.DoubleClick += new System.EventHandler(this.dgvBill_DoubleClick);
//            this.dgvBill.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvBill_MouseDoubleClick);
            // 
            // dtpNgayThangToi
            // 
            this.dtpNgayThangToi.CustomFormat = "dd/mm/yyyy";
            this.dtpNgayThangToi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayThangToi.Location = new System.Drawing.Point(81, 16);
            this.dtpNgayThangToi.Name = "dtpNgayThangToi";
            this.dtpNgayThangToi.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayThangToi.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(312, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tim";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpNgayThangDi
            // 
            this.dtpNgayThangDi.CustomFormat = "dd/mm/yyyy";
            this.dtpNgayThangDi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayThangDi.Location = new System.Drawing.Point(81, 42);
            this.dtpNgayThangDi.Name = "dtpNgayThangDi";
            this.dtpNgayThangDi.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayThangDi.TabIndex = 3;
            // 
            // BillsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpNgayThangDi);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpNgayThangToi);
            this.Controls.Add(this.dgvBill);
            this.Name = "BillsForm";
            this.Text = "BillForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBill;
        private System.Windows.Forms.DateTimePicker dtpNgayThangToi;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpNgayThangDi;
    }
}