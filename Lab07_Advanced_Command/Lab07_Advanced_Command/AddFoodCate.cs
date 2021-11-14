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
    public partial class AddFoodCate : Form
    {
        public AddFoodCate()
        {
            InitializeComponent();
        }

        private void LoadType()
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT Type FROM Category";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            conn.Open();

            adapter.Fill(dt);
            conn.Close();
            conn.Dispose();

            cbbType.DataSource = dt;
            cbbType.DisplayMember = "Type";

        }

        private void AddFoodCate_Load(object sender, EventArgs e)
        {
            this.LoadType();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE InsertCategory @id OUTPUT, @name, @type";

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@type", SqlDbType.Int);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                cmd.Parameters["@name"].Value = txtCate.Text;
                cmd.Parameters["@type"].Value = cbbType.Text;

                conn.Open();


                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    string cateID = cmd.Parameters["@id"].Value.ToString();
                    MessageBox.Show("Sucessful adding new category, Category ID" + cateID, "Message");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Adding category fail");
                }
                conn.Close();
                conn.Dispose();
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
        }
        private void ResetText()
        {
            txtID.ResetText();
            txtCate.ResetText();
            cbbType.ResetText();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            cbbType.ResetText();
        }
    }
}
