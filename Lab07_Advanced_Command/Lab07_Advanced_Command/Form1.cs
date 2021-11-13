﻿using System;
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
    public partial class Form1 : Form
    {
        private DataTable foodTable;
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadCategory()
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID, Name FROM Category";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            conn.Open();

            adapter.Fill(dt);
            conn.Close();
            conn.Dispose();

            cbbCategory.DataSource = dt;
            cbbCategory.DisplayMember = "Name";
            cbbCategory.ValueMember = "ID";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadCategory();
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedIndex == -1) return;

            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Food Where FoodCategoryID=@categoryID";

            //truyen tham so
            cmd.Parameters.Add("@categoryID", SqlDbType.Int);
            if (cbbCategory.SelectedValue is DataRowView)
            {
                DataRowView rowView = cbbCategory.SelectedValue as DataRowView;
                cmd.Parameters["@categoryID"].Value = rowView["ID"];
            }
            else
            {
                cmd.Parameters["@categoryID"].Value = cbbCategory.SelectedValue;
            }
            //tao bp dieu khien du lieu
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            foodTable = new DataTable();
            conn.Open();
            //lay data tw db --> datatb
            adapter.Fill(foodTable);

            conn.Close();
            conn.Dispose();

            dgvFoodList.DataSource = foodTable;

            lblQuantity.Text = foodTable.Rows.Count.ToString();
            lblCatName.Text = cbbCategory.Text;

        }

        private void tsmCalculateQuantity_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-3TTGTB4\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT @numSaleFood=sum(Quantity)FROM BillDetails WHERE FoodID=@foodID";
            //lay thong tin item

            if (dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                //Truyen tham so
                cmd.Parameters.Add("@foodID", SqlDbType.Int);
                cmd.Parameters["@foodID"].Value = rowView["ID"];

                cmd.Parameters.Add("@numSaleFood", SqlDbType.Int);
                cmd.Parameters["@numSaleFood"].Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();
                string result = cmd.Parameters["@numSaleFood"].Value.ToString();
                MessageBox.Show("Tổng số lượng món " + rowView["Name"] + "đã bán là:" + result + " " + rowView["Unit"]);
                conn.Close();
            }
            cmd.Dispose();
            conn.Dispose();
        }

        private void tsmAddFood_Click(object sender, EventArgs e)
        {
            FoodInfoForm frm = new FoodInfoForm();
            frm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
            frm.Show(this);
        }
        void foodForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbCategory.SelectedIndex;
            cbbCategory.SelectedIndex = -1;
            cbbCategory.SelectedIndex = index;
        }

        private void tsmUpdateFood_Click(object sender, EventArgs e)
        {
            if (dgvFoodList.SelectedRows.Count > 0)
            {
                // lấy thông tin sản phẩn được chọn
                if (dgvFoodList.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                    DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                    FoodInfoForm foodForm = new FoodInfoForm();
                    foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);

                    foodForm.Show(this);
                    foodForm.DisplayFoodInfo(rowView);

                }
            }
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (foodTable == null) return;

            string filterExpression = "Name like '%" + txtSearchByName.Text + "%'";
            string sortExpression = "Price DESC";

            DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;

            DataView foodView = new DataView(foodTable, filterExpression, sortExpression, rowStateFilter);
            dgvFoodList.DataSource = foodView;
        }
    }

}
