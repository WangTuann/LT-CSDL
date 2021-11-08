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
            if (cbbSort.SelectedItem=="Nhóm")
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

            
            sqlCommand.CommandText= string.Format("insert into Account(AccountName,Password, FullName, Email, Tell, DateCreated) values ('{0}', '{1}', N'{2}', '{3}', '{4}', '{5}')",txtAccount.Text, txtPass.Text, txtName.Text, txtEmail.Text, txtTell.Text, DateTime.Now);
            int numofRowEffect = sqlCommand.ExecuteNonQuery();
            if (numofRowEffect==1)
            {
                LoadAccount();
                MessageBox.Show("Them account thanh cong");

            }
            else
            {
                MessageBox.Show("loi");

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlConnection.Open();
            sqlCommand.CommandText="UPDATE Account SET Password=N'"+
        }
    }
}
