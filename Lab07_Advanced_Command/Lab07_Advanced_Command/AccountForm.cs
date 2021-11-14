using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab07_Advanced_Command
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
            LoadAccount();
        }
        private void LoadAccount()
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Account";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable("ACcount");

            connection.Open();

          
            adapter.Fill(table);

            dgvAccount.DataSource = table;

            // Prevent user to edit ID
            dgvAccount.Columns[0].ReadOnly = true;

            connection.Close();
        }

        private void dgvAccount_Click(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvAccount_Click(object sender, EventArgs e)
        {
            int index = dgvAccount.CurrentRow.Index;
            if (index != null)
            {
                txtAcc.Text = dgvAccount.Rows[index].Cells["AccountName"].Value.ToString();
                txtPass.Text = dgvAccount.Rows[index].Cells["Password"].Value.ToString();
                txtFullName.Text = dgvAccount.Rows[index].Cells["FullName"].Value.ToString();
                txtEmail.Text = dgvAccount.Rows[index].Cells["Email"].Value.ToString();
                txtTell.Text = dgvAccount.Rows[index].Cells["Tell"].Value.ToString();

                btnUpdate.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE InsertAccount @Account,@Pass,@Fullname,@Email,@Tell,@Date";

                // thêm tham số vào đối tượng command
                cmd.Parameters.Add("@Account", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@Pass", SqlDbType.NVarChar, 200);
                cmd.Parameters.Add("@Fullname", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@Tell", SqlDbType.NVarChar, 200);
                cmd.Parameters.Add("@Date", SqlDbType.SmallDateTime);

                cmd.Parameters["@Account"].Value = txtAcc.Text;
                cmd.Parameters["@Pass"].Value = txtPass.Text;
                cmd.Parameters["@Fullname"].Value = txtFullName.Text;
                cmd.Parameters["@Email"].Value = txtEmail.Text;
                cmd.Parameters["@Tell"].Value = txtTell.Text;
                cmd.Parameters["@Date"].Value = DateTime.Now.ToShortDateString();

                // mở kết nối
                conn.Open();

                int numRowAffected = cmd.ExecuteNonQuery();

                // thông báo kết quả
                if (numRowAffected > 0)
                {

                    LoadAccount();
                    ResetForm();
                    MessageBox.Show("Successfully add new account!" +"Message");
                    
                }
                else
                {
                    MessageBox.Show("Adding account failed");
                }

                // đóng kết nối
                conn.Close();
                conn.Dispose();
            }
            // bắt lỗi SQL và các lỗi khác
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
        }
        private void ResetForm()
        {
            txtAcc.Text = "";
            txtPass.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtTell.Text = "";
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE UpdateAccount @Account,@Pass,@Fullname,@Email,@Tell,@Date";

                // thêm tham số vào đối tượng command
                cmd.Parameters.Add("@Account", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@Pass", SqlDbType.NVarChar, 200);
                cmd.Parameters.Add("@Fullname", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@Tell", SqlDbType.NVarChar, 200);
                cmd.Parameters.Add("@Date", SqlDbType.SmallDateTime);

                cmd.Parameters["@Account"].Value = txtAcc.Text;
                cmd.Parameters["@Pass"].Value = txtPass.Text;
                cmd.Parameters["@Fullname"].Value = txtFullName.Text;
                cmd.Parameters["@Email"].Value = txtEmail.Text;
                cmd.Parameters["@Tell"].Value = txtTell.Text;
                cmd.Parameters["@Date"].Value = DateTime.Now.ToShortDateString();

                // mở kết nối
                conn.Open();

                int numRowAffected = cmd.ExecuteNonQuery();

                // thông báo kết quả
                if (numRowAffected > 0)
                {

                    LoadAccount();
                    ResetForm();
                    MessageBox.Show("Successfully add new account!" + "Message");

                }
                else
                {
                    MessageBox.Show("Adding updating failed");
                }

                // đóng kết nối
                conn.Close();
                conn.Dispose();
            }
            // bắt lỗi SQL và các lỗi khác
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
        }

        private void tsmRole_Click(object sender, EventArgs e)
        {

        }
    }
}
