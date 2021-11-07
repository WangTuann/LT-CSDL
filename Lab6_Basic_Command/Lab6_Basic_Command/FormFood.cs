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
    public partial class frmFood : Form
    {
        public frmFood()
        {
            InitializeComponent();
        }

        public void LoadFood(int categoryID)
        {

            string connnectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConn = new SqlConnection(connnectionString);
            SqlCommand sqlCommand = sqlConn.CreateCommand();

            sqlCommand.CommandText = "SELECT Name FROM Category WHERE ID = " + categoryID;

            sqlConn.Open();

            string catName = sqlCommand.ExecuteScalar().ToString();
            this.Text = "Danh dach cac mon an thuoc nhom: " + catName;

            sqlCommand.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = " + categoryID;

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("Food");
            da.Fill(dt);

            setFoodToG(dt);

            sqlConn.Close();
            sqlConn.Dispose();
            da.Dispose();
        }

        void setFoodToG(DataTable table)
        {
            dgvFood.DataSource = table;
            dgvFood.Columns[0].ReadOnly = true;
            dgvFood.Columns[0].HeaderCell.Value = "Mã món";
            dgvFood.Columns[1].HeaderCell.Value = "Tên món";
            dgvFood.Columns[2].HeaderCell.Value = "Đơn vị";
            dgvFood.Columns[3].Visible = false;
            dgvFood.Columns[4].HeaderCell.Value = "Giá";
            dgvFood.Columns[5].HeaderCell.Value = "Ghi chú";
            dgvFood.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows.Count == 0) return;

            var selectedRow = dgvFood.SelectedRows[0];
            string foodID = selectedRow.Cells[0].Value.ToString();

            // tạo đối tượng kết nối
            string connectionString = @"Data Source=DESKTOP-O55J47Q;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //tạo đối tượng thực thi lệnh
            SqlCommand command;
            command = sqlConnection.CreateCommand();

            // tạo truy vấn
            string query = "DELETE FROM Food WHERE ID =" + foodID;
            command.CommandText = query;

            sqlConnection.Open();

            int numOfRowsEffected = command.ExecuteNonQuery();
            if (numOfRowsEffected != 1)
            {
                MessageBox.Show("Không thực hiện được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Đã xoá đối tượng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvFood.Rows.Remove(selectedRow);
            sqlConnection.Close();
        }
    }
}
