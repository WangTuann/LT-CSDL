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
    public partial class BillsForm : Form
    {
        bool billStatus;
        string querry;
        public BillsForm()
        {
            InitializeComponent();
            LoadBill();
        }
        public void LoadBill()
        {
            if (billStatus == false)
            {
                querry = "SELECT * FROM Bills";

            }
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();

            command.CommandText = querry;

            connection.Open();



            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable("Bill");
            adapter.Fill(table);

            dgvBill.DataSource = table;

            // Prevent user to edit ID
            dgvBill.Columns[0].ReadOnly = true;

            connection.Close();

            command.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dtpDau = dtpNgayThangToi.Value.ToShortDateString();
            string dtpCuoi = dtpNgayThangDi.Value.ToShortDateString();

            querry = $"set dateformat dmy select * from Bills where '{dtpDau}' <= CHECKOUTDATE and CHECKOUTDATE <= '{dtpCuoi}'";
            billStatus = true;
            LoadBill();
        }

        private void dgvBill_DoubleClick(object sender, EventArgs e)
        {
            BillsDetailForm frm = new BillsDetailForm();
            string id = dgvBill.SelectedRows[0].Cells[0].Value.ToString();
            frm.Show(this);
            frm.LoadBillDetail(int.Parse(id));
        }
    }
}
