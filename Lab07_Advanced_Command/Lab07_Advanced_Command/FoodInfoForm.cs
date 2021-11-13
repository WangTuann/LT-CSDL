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
    public partial class FoodInfoForm : Form
    {
        public FoodInfoForm()
        {
            InitializeComponent();
        }

        private void FoodInfoForm_Load(object sender, EventArgs e)
        {
            this.InitValues();
        }
        private void InitValues()
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID,Name FROM Category";

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            conn.Open();
            //lay dl tu csdl dua vao datatb
            adapter.Fill(ds, "Category");

            //hien thi nhom mon an
            cbbCatName.DataSource = ds.Tables["Category"];
            cbbCatName.DisplayMember = "Name";
            cbbCatName.ValueMember = "ID";

            conn.Close();
            conn.Dispose();
        }

        private void Reset()
        {
            txtFoodId.ResetText();
            txtName.ResetText();
            txtNote.ResetText();
            txtUnit.ResetText();
            cbbCatName.ResetText();
            nudPrice.ResetText();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXCUTE InsertFood @id OUTPUT,@name,@unit,@foodCategoryID,@price,@notes";


                //them tham so vao command
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@foodCategoryID", SqlDbType.Int);
                cmd.Parameters.Add("@price", SqlDbType.Int);
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                //truyen gia tri vao thu tuc qua tham so
                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.Parameters["@unit"].Value = txtUnit.Text;
                cmd.Parameters["@foodCategory"].Value = cbbCatName.SelectedValue;
                cmd.Parameters["@price"].Value = nudPrice.Value;
                cmd.Parameters["@notes"].Value = txtNote.Text;


                conn.Open();
                int numofRowEffect = cmd.ExecuteNonQuery();
                if (numofRowEffect>0)
                {
                    string foodID = cmd.Parameters["@id"].Value.ToString();
                    MessageBox.Show("Successfully adding new food, Food ID=" + foodID, "Message");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Adding food failed");

                }
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException exeption)
            {
                MessageBox.Show(exeption.Message, "SQL Error");
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Error");
            }

        }
        public void DisplayFoodInfo(DataRowView rowView)
        {
            try
            {
                txtFoodId.Text = rowView["ID"].ToString();
                txtName.Text = rowView["Name"].ToString();
                txtUnit.Text = rowView["Unit"].ToString();
                txtNote.Text = rowView["Notes"].ToString();
                nudPrice.Text = rowView["Price"].ToString();

                cbbCatName.SelectedIndex = -1;

                for (int index = 0; index < cbbCatName.Items.Count; index++)
                {
                    DataRowView cat = cbbCatName.Items[index] as DataRowView;
                    if (cat["ID"].ToString()==rowView["FoodCategoryID"].ToString())
                    {
                        cbbCatName.SelectedIndex = index;
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
                this.Close();
            }
        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXCUTE UpdateFood @id ,@name,@unit,@foodCategoryID,@price,@notes";


                //them tham so vao command
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@foodCategoryID", SqlDbType.Int);
                cmd.Parameters.Add("@price", SqlDbType.Int);
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                // cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                //truyen gia tri vao thu tuc qua tham so
                cmd.Parameters["@id"].Value = int.Parse(txtFoodId.Text);
                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.Parameters["@unit"].Value = txtUnit.Text;
                cmd.Parameters["@foodCategory"].Value = cbbCatName.SelectedValue;
                cmd.Parameters["@price"].Value = nudPrice.Value;
                cmd.Parameters["@notes"].Value = txtNote.Text;


                conn.Open();
                int numofRowEffect = cmd.ExecuteNonQuery();
                if (numofRowEffect > 0)
                {
                    //string foodID = cmd.Parameters["@id"].Value.ToString();
                    MessageBox.Show("Successfully updating food","Message");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Updating food failed");

                }
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException exeption)
            {
                MessageBox.Show(exeption.Message, "SQL Error");
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
