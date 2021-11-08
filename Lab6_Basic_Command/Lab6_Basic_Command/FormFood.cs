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
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlComd = sqlConn.CreateCommand();

            sqlComd.CommandText = "UPDATE Food SET Name = N'" + txtFoodName.Text + "', Unit = '" + txtDonViTinh.Text + "', FoodCategoryID = " + txtNhom.Text + ", Price = " + txtGia.Text + ", Notes = '" + lb.Text + "'" +
                                                       " WHERE ID = " + txtFoodID.Text;
            // mở kết nối tới csdl
            sqlConn.Open();

            // thực thi lệnh bằng phương thức ExcuteReader
            int numOfRowsEffected = sqlComd.ExecuteNonQuery();

            // đóng kết nối
            sqlConn.Close();

            if (numOfRowsEffected == 1)
            {
                MessageBox.Show("Cập nhật món ăn thành công");

                //Tải lại dữ liệu
                LoadFood(Convert.ToInt32(txtNhom.Text));

                // xoá các ô đã nhập
                //txtName.Text = "";
                //txtUnit.Text = "";
                //txtFoodCategoryID.Text = "";
                //txtPrice.Text = "";
                //txtNote.Text = "";
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại");
            }
            sqlConn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows.Count == 0) return;

            var selectedRow = dgvFood.SelectedRows[0];
            string foodID = selectedRow.Cells[0].Value.ToString();

            // tạo đối tượng kết nối
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //tạo đối tượng thực thi lệnh
            SqlCommand command;
            command = sqlConnection.CreateCommand();

            // tạo truy vấn
            string query = "DELETE FROM Food WHERE ID =" + foodID;
            command.CommandText = query;

            sqlConnection.Open();

            int numOfRowsEffected = command.ExecuteNonQuery();
            if (numOfRowsEffected == 1)
            {
                dgvFood.Rows.Remove(selectedRow);
                MessageBox.Show("Da xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Da xay ra loi");
                return;
            }
            sqlConnection.Close();
        }

        private void dgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvFood.CurrentRow.Index;
            txtFoodID.Text = dgvFood.Rows[i].Cells[0].Value.ToString();
            txtFoodName.Text = dgvFood.Rows[i].Cells[1].Value.ToString();
            txtDonViTinh.Text = dgvFood.Rows[i].Cells[2].Value.ToString();
            txtGia.Text = dgvFood.Rows[i].Cells[4].Value.ToString();
            lb.Text = dgvFood.Rows[i].Cells[5].Value.ToString();
        }
    }
}
