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

            dgvFood.DataSource = dt;

            sqlConn.Close();
            sqlConn.Dispose();
            da.Dispose();
        }

    }
}
