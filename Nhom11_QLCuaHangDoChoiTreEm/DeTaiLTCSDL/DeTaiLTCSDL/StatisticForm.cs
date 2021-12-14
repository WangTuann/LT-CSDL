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
    public partial class StatisticForm : Form
    {
        int listBills = 0;
        int listToy = 0;
        int sumDiscount = 0;
        int sumDoanhThu = 0;
        List<Bills> dsBills = new List<Bills>();
        public StatisticForm()
        {
            InitializeComponent();
        }

        private void txtNameCustomer_TextChanged(object sender, EventArgs e)
        {
            BillsBL billsBL = new BillsBL();
            listBills = billsBL.countBills();
            txtCountBills.Text = listBills.ToString();
            
        }
        private void SoLuongHoaDon()
        {
            BillsBL billsBL = new BillsBL();
            listBills = billsBL.countBills();
            txtCountBills.Text = listBills.ToString();
        }
        private void chiPhiNhap()
        {
            ToyBL toyBL = new ToyBL();
            listToy = toyBL.chiphiNhap();
            txtChiPhiNhap.Text = listToy.ToString() + " VND";

        }

        private void TongKhuyenMai()
        {
            BillsBL billsBL = new BillsBL();
            sumDiscount = billsBL.SumDiscount();
            txtDiscount.Text = sumDiscount.ToString() + " VND";
        }

        private void DoanhThu()
        {
            BillDetailsBL billsBL = new BillDetailsBL();
            sumDoanhThu = billsBL.Get_DoanhThu();
            txtDoanhThu.Text = sumDoanhThu.ToString();   
        }

        private void LoadBill()
        {
            BillsBL billsBL = new BillsBL();
            dsBills = billsBL.GetAll();
            int count = 1;
            lvBills.Items.Clear();
            foreach (var bills in dsBills)
            {
                ListViewItem item = lvBills.Items.Add(count.ToString());
                item.SubItems.Add(bills.TenKH);
                item.SubItems.Add(bills.SDT);
                item.SubItems.Add(bills.NgayBan.ToString());
                item.SubItems.Add(bills.KhuyenMai.ToString());
                item.SubItems.Add(bills.ID_NV.ToString());
                count++;
            }
        }

        private void StatisticForm_Load(object sender, EventArgs e)
        {
            SoLuongHoaDon();
            chiPhiNhap();
            TongKhuyenMai();
            DoanhThu();
            LoadBill();
        }
    }
}
