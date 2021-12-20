using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeTaiLTCSDL
{
    public partial class Form_Customer : Form
    {
        List<Bills> dsKH = new List<Bills>();
        Bills billCurrent = new Bills();
        public Form_Customer()
        {
            InitializeComponent();
        }

        public void Load_Customer()
        {
            BillsBL billsBL = new BillsBL();
            dsKH = billsBL.GetAll();
            int count = 1;
            lvKH.Items.Clear();
            foreach (var kh in dsKH)
            {
                ListViewItem item = lvKH.Items.Add(count.ToString());
                item.SubItems.Add(kh.TenKH);
                item.SubItems.Add(kh.SDT);
                count++;
            }
        }

        private void Form_Customer_Load(object sender, EventArgs e)
        {
            Load_Customer();
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = " ";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<Bills> bills = new List<Bills>();
            lvKH.Items.Clear();
            BillsBL billsBL = new BillsBL();
            bills = billsBL.Find(txtTimKiem.Text);
            foreach (Bills bill in bills)
            {

                ListViewItem item = new ListViewItem(bill.ID.ToString());
                item.SubItems.Add(bill.TenKH);
                item.SubItems.Add(bill.SDT);

                lvKH.Items.Add(item);
            }
        }


        private void lvKH_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvKH.Items.Count; i++)
            {
                if (lvKH.Items[i].Selected)
                {
                    billCurrent = dsKH[i];
                    txtCusName.Text = billCurrent.TenKH;
                    txtTel.Text = billCurrent.SDT;
                }
            }
            
        }

        public int UpdateCusInfo()
        {
            Bills bills = billCurrent;
            if (txtCusName.Text == "" || txtTel.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
            else
            {
                //Nhận giá trị Name, Unit, và Notes khi người dùng sửa
                bills.TenKH = txtCusName.Text;
                bills.SDT = txtTel.Text;
                // Khao báo đối tượng FoodBL từ tầng Business
                BillsBL billsBL= new BillsBL();
                // Cập nhật dữ liệu trong bảng
                return billsBL.Update(bills);
            }
            return -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = UpdateCusInfo();
            if (result>0)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công");
                Load_Customer();    
            }
            else MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            Form_CustomerDetail frm = new Form_CustomerDetail();
            //txtCusName.Text = frm.CusName;
            frm.Show();
        }
    }
}
