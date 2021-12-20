using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeTaiLTCSDL
{
    public partial class Form_Main : Form
    {
        private Form activeForm;
        private GunaButton currentButton;
        private const int CS_DropShadow = 0x00020000;
        public Form_Main()
        {
            InitializeComponent();
        }
        #region Các hàm xử lý
        // Hiển thị form Sell khi đăng nhập thành công
        private void FormMain_Load(object sender, EventArgs e)
        {
            Form_Sell frm = new Form_Sell();
            frm.TopLevel = false;
            pnlTong.Controls.Add(frm);
            frm.Show();
        }

        // Tạo bóng cho form
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in pn_Menu.Controls)
            {
                if (previousBtn.GetType() == typeof(GunaButton))
                {
                    previousBtn.BackColor = Color.FromArgb(0, 117, 214);
                    previousBtn.ForeColor = Color.Gainsboro;
                }

            }
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (GunaButton)btnSender)
                {
                    DisableButton();
                    Color color = new Color();
                    currentButton = (GunaButton)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.Black;
                }
            }
        }

        // Mở form con
        private void OpenChildForm(Form childForm, object btnSender)
        {

            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlTong.Controls.Add(childForm);
            this.pnlTong.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Đăng xuất
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        // Hiện form Bán hàng
        private void btnSell_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_Sell(), sender);
        }

        // Hiện form Quản lý mặt hàng
        private void btnManager_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_Manager(), sender);
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StatisticForm(), sender);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_Customer(), sender);
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form_SearchCustom(), sender);
        }
        #endregion


    }
}
