namespace DeTaiLTCSDL.CustomCotrols
{
    partial class ToyDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbToyName = new Guna.UI.WinForms.GunaLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPrice = new Guna.UI.WinForms.GunaLabel();
            this.btnValid = new Guna.UI.WinForms.GunaButton();
            this.ptbImageToy = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImageToy)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(220)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbToyName);
            this.panel2.ForeColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 33);
            this.panel2.TabIndex = 7;
            // 
            // lbToyName
            // 
            this.lbToyName.AutoSize = true;
            this.lbToyName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbToyName.ForeColor = System.Drawing.Color.Black;
            this.lbToyName.Location = new System.Drawing.Point(0, 6);
            this.lbToyName.Name = "lbToyName";
            this.lbToyName.Size = new System.Drawing.Size(76, 20);
            this.lbToyName.TabIndex = 0;
            this.lbToyName.Text = "NameToy";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(220)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Location = new System.Drawing.Point(0, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 33);
            this.panel1.TabIndex = 9;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.Black;
            this.lblPrice.Location = new System.Drawing.Point(0, 5);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(43, 20);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "Price";
            // 
            // btnValid
            // 
            this.btnValid.AnimationHoverSpeed = 0.07F;
            this.btnValid.AnimationSpeed = 0.03F;
            this.btnValid.BackColor = System.Drawing.Color.Transparent;
            this.btnValid.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnValid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnValid.BorderSize = 1;
            this.btnValid.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnValid.FocusedColor = System.Drawing.Color.Empty;
            this.btnValid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnValid.ForeColor = System.Drawing.Color.Transparent;
            this.btnValid.Image = global::DeTaiLTCSDL.Properties.Resources.add_24px;
            this.btnValid.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnValid.ImageSize = new System.Drawing.Size(20, 20);
            this.btnValid.Location = new System.Drawing.Point(151, 164);
            this.btnValid.Name = "btnValid";
            this.btnValid.OnHoverBaseColor = System.Drawing.Color.MediumTurquoise;
            this.btnValid.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnValid.OnHoverForeColor = System.Drawing.Color.Transparent;
            this.btnValid.OnHoverImage = null;
            this.btnValid.OnPressedColor = System.Drawing.Color.Black;
            this.btnValid.Radius = 5;
            this.btnValid.Size = new System.Drawing.Size(46, 42);
            this.btnValid.TabIndex = 10;
            this.btnValid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnValid.Click += new System.EventHandler(this.btnValid_Click);
            // 
            // ptbImageToy
            // 
            this.ptbImageToy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbImageToy.Location = new System.Drawing.Point(-1, 34);
            this.ptbImageToy.Name = "ptbImageToy";
            this.ptbImageToy.Size = new System.Drawing.Size(202, 175);
            this.ptbImageToy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbImageToy.TabIndex = 8;
            this.ptbImageToy.TabStop = false;
            // 
            // ToyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnValid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ptbImageToy);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(12);
            this.Name = "ToyDetails";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(201, 209);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbImageToy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaLabel lbToyName;
        private System.Windows.Forms.PictureBox ptbImageToy;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaLabel lblPrice;
        private Guna.UI.WinForms.GunaButton btnValid;
    }
}
