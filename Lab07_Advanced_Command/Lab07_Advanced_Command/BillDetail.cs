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
    public partial class BillDetail : Form
    {
        public BillDetail()
        {
            InitializeComponent();
            
        }



        public void LoadBillDeTail(string billID)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE BillDetails_GetByID @id ";

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = billID;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();    

                adapter.Fill(dt);

                dgvBillDetails.DataSource = dt;
                dgvBillDetails.Columns[0].ReadOnly = true;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SQL Error");
            }
        }
    }
}
