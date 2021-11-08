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


namespace Lab6_Basic_Command
{
    public partial class AccountManager : Form
    {
        public AccountManager()
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
            connection.Open();

            string categoryName = command.ExecuteScalar().ToString();
            this.Text = "Danh sach toan bo tai khoan";

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable("Food");
            adapter.Fill(table);

            dgvAccount.DataSource = table;

            // Prevent user to edit ID
            dgvAccount.Columns[0].ReadOnly = true;

            connection.Close();
        }

        private void cbbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            if (cbbSort.SelectedItem == "Nhóm")
            {
                command.CommandText = "SELECT RoleID, Account.AccountName, Password, FullName, Email, Tell, DateCreated FROM Account, RoleAccount " +
                    " WHERE Account.AccountName = RoleAccount.AccountName" +
                    " ORDER BY RoleAccount.RoleID";
                connection.Open();

                this.Text = "Danh sách toàn bộ tài khoản";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvAccount.DataSource = table;
                dgvAccount.Columns[0].ReadOnly = true;
                connection.Close();
            }
            else
            {
                command.CommandText = "SELECT Actived, Account.AccountName, Password, FullName, Email, Tell, DateCreated FROM Account, RoleAccount " +
                    " WHERE Account.AccountName = RoleAccount.AccountName" +
                    " ORDER BY RoleAccount.Actived";
                connection.Open();

                this.Text = "Danh sách toàn bộ tài khoản";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvAccount.DataSource = table;
                dgvAccount.Columns[0].ReadOnly = true;
                connection.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlConnection.Open();

            sqlCommand.CommandText = "SELECT * From Account where Account.AccountName='" + txtAccount.Text + "'";

            sqlCommand.CommandText = string.Format("insert into Account(AccountName,Password, FullName, Email, Tell, DateCreated) values ('{0}', '{1}', N'{2}', '{3}', '{4}', '{5}')", txtAccount.Text, txtPass.Text, txtName.Text, txtEmail.Text, txtTell.Text, DateTime.Now);
            int numofRowEffect = sqlCommand.ExecuteNonQuery();
            if (numofRowEffect == 1)
            {
                LoadAccount();
                MessageBox.Show("Them account thanh cong");

            }
            else
            {
                MessageBox.Show("loi");
            }

            sqlConnection.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string defaultPass = "111111";
            sqlConnection.Open();
            sqlCommand.CommandText = "UPDATE Account SET Password=N'" + defaultPass + "'where [AccountName]=N'" + txtAccount.Text + "'";
            int numofRowEffect = sqlCommand.ExecuteNonQuery();
            if (numofRowEffect >= 1)
            {
                MessageBox.Show("Đã đặt lại thành công:");
                LoadAccount();

            }
            sqlConnection.Close();
        }

        private void dgvAccount_Click(object sender, EventArgs e)
        {
            int index = dgvAccount.CurrentRow.Index;

            txtAccount.Text = dgvAccount.Rows[index].Cells["AccountName"].Value.ToString();
            txtPass.Text = dgvAccount.Rows[index].Cells["Password"].Value.ToString();
            txtName.Text = dgvAccount.Rows[index].Cells["FullName"].Value.ToString();
            txtEmail.Text = dgvAccount.Rows[index].Cells["Email"].Value.ToString();
            txtTell.Text = dgvAccount.Rows[index].Cells["Tell"].Value.ToString();

            btnAdd.Enabled = true;
            btnReset.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlComd = sqlConn.CreateCommand();

            sqlComd.CommandText = string.Format("UPDATE Account SET AccountName = '{0}', Password = '{1}', FullName = N'{2}', Email = '{3}', Tell = '{4}', DateCreated = '{5}' WHERE AccountName = '{0}' ",
                txtAccount.Text, txtPass.Text, txtName.Text, txtEmail.Text, txtTell.Text, DateTime.Now);

            sqlConn.Open();

            int numOfRows = sqlComd.ExecuteNonQuery();

            if (numOfRows == 1)
            {
                LoadAccount();  
                MessageBox.Show("Cap nhat tai khoan thanh cong");
            }
            else
            {
                MessageBox.Show("Loi", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
            sqlConn.Close();
        }

        private void xoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count == 0) return;

            var selectedRow = dgvAccount.SelectedRows[0];
            string account = selectedRow.Cells[0].Value.ToString();

            // tạo đối tượng kết nối
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //tạo đối tượng thực thi lệnh
            SqlCommand command;
            command = sqlConnection.CreateCommand();

            // tạo truy vấn
            string query = string.Format("UPDATE RoleAccount SET Actived = '0' WHERE AccountName = '{0}'", account);
            command.CommandText = query;

            sqlConnection.Open();

            int numOfRowsEffected = command.ExecuteNonQuery();
            if (numOfRowsEffected == 1)
            {
                dgvAccount.Rows.Remove(selectedRow);
                MessageBox.Show("Da xoa thanh cong");
            }
            sqlConnection.Close();
        }
    }
}
