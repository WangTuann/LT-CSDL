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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string querry = "SELECT ID,Name,Type FROM Category";
            sqlCommand.CommandText = querry;
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            this.DisplayCategory(sqlDataReader);
            sqlConnection.Close();
        }
        private void DisplayCategory(SqlDataReader reader)
        {
            //lvCategory.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                lvCategory.Items.Add(item);
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Type"].ToString());
            }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText= "INSERT INTO Category(Name, [Type])" + "VALUES (N'" + txtName.Text + "', " + txtType.Text + ")";
            sqlConnection.Open();
            int numOfRowEffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (numOfRowEffected==1)
            {
                MessageBox.Show("Thêm nhóm món ăn thành công");
                btnLoad.PerformClick();
                txtName.Text = "";
                txtType.Text = "";
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra vui lòng thử lại");
            }
        }

        private void lvCategory_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvCategory.SelectedItems[0];

            txtID.Text = item.Text;
            txtName.Text = item.SubItems[1].Text;
            txtType.Text = item.SubItems[2].Text == "0" ? "Thức uống" : "Đồ ăn";

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlComd = sqlConn.CreateCommand();

            sqlComd.CommandText = "UPDATE Category SET Name = N'" + txtName.Text +
                                                    "', [Type] = " + (txtType.Text == "Thức uống" ? 0 : 1) +
                                                    " WHERE ID = " + txtID.Text;

            sqlConn.Open();
            int numOfRowEffected = sqlComd.ExecuteNonQuery();
            sqlConn.Close();

            if (numOfRowEffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];
                item.SubItems[1].Text = txtName.Text = txtName.Text;
                item.SubItems[2].Text = txtType.Text == "Thức uống" ? "0" : "1";

                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                MessageBox.Show("Cap nhat nhom mon an thanh cong");

            }
            else
            {
                MessageBox.Show("Da co loi xay ra, vui long thu lai");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlComd = sqlConn.CreateCommand();

            sqlComd.CommandText = "DELETE FROM Category " + "WHERE ID = " + txtID.Text;

            sqlConn.Open();
            int numOfRowsEffected = sqlComd.ExecuteNonQuery();
            sqlConn.Close();

            if (numOfRowsEffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];
                lvCategory.Items.Remove(item);

                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";

                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;

                MessageBox.Show("Xoa nhom mon an thanh cong");

            }
            else
            {
                MessageBox.Show("Da co loi xay ra. Vui long thu lai");
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count > 0)
                btnDelete.PerformClick();
        }

        private void tsmViewFood_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                frmFood frm = new frmFood();
                frm.Show(this);
                frm.LoadFood(Convert.ToInt32(txtID.Text));
            }
        }
    }
}
