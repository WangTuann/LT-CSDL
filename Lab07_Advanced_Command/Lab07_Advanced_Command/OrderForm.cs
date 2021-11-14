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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            LoadBill();
        }


        public void LoadBill()
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select *From Bills";


            cmd.Parameters.Add("@date", SqlDbType.SmallDateTime);
            cmd.Parameters["@date"].Value = dtpDate.Value.ToShortDateString();


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Open();

            adapter.Fill(dt);

            conn.Close();

            dgvBill.DataSource = dt;
            dgvBill.Columns[0].ReadOnly = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE Bills_GetByDate @date";


                cmd.Parameters.Add("@date", SqlDbType.SmallDateTime);
                cmd.Parameters["@date"].Value = DateTime.Parse(dtpDate.Value.ToString("dd/MM/yyyy"));

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                conn.Open();

                adapter.Fill(dt);

                cmd.CommandText = "Select SUM(Amount)from Bills where CheckoutDate =@date";

                var amountDate = cmd.ExecuteScalar();
                lblAmount.Text = amountDate.ToString();
                conn.Close();

                dgvBill.DataSource = dt;
                dgvBill.Columns[0].ReadOnly = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "SQL Error");
            }
        }


        private void dgvBill_DoubleClick(object sender, EventArgs e)
        {
            var billID = dgvBill.SelectedRows[0].Cells[0].Value.ToString();

            BillDetail frm = new BillDetail();
            frm.LoadBillDeTail(billID);
            frm.ShowDialog(this);
        }
    }
}
