using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeTaiLTCSDL
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        #region Các hàm xử lý
        private void txtAccount_Click(object sender, EventArgs e)
        {
            txtAccount.Text = "";
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            try
            {
                sqlCommand.CommandText = "Select * From NhanVien Where TaiKhoan = @taikhoan and MatKhau = @matkhau";
                sqlCommand.Parameters.Add("@taikhoan", SqlDbType.NVarChar, 50);
                sqlCommand.Parameters.Add("@matkhau", SqlDbType.NVarChar, 50);
                sqlCommand.Parameters["@taikhoan"].Value = txtAccount.Text;
                sqlCommand.Parameters["@matkhau"].Value = txtPass.Text;

                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read() == true)
                {
                    
                    Form_Main frm = new Form_Main();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!", "Lỗi", MessageBoxButtons.OKCancel);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi SQL");
            }
            
        }
        #endregion


    }
}
