using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeTaiLTCSDL
{
    public partial class Form_Sell : Form
    {
        // Truyền và nhận dữ liệu từ form Toy
        List<Toy> listToy = new List<Toy>();
        public delegate void ReceiveToy(Toy toy);
        public delegate void RecieveBillsDetails(BillDetails billDetails);

        Bills BillCurrent = new Bills();
        int toyId;
        int quantity;
        int tongTien;
        int discount;
        int thanhTien;

        List<NhanVien> listNV = new List<NhanVien>();
        public Form_Sell()
        {
            InitializeComponent();
        }

        #region Hiển thị
        private void SetToyToPanel(Toy toy)
        {
            listToy.Add(toy);
            this.toyId = toy.Id;
            var item = new CustomCotrols.OrderToys();
            item.InitUI(toy.TenDoChoi, toy.GiaBan, 1, toy.Id);
            int soLuong = item.soLuong;

            flpToyOder.Controls.Add(item);

            tongTien += toy.GiaBan;
            txtTongTien.Text = tongTien.ToString();

            discount = Convert.ToInt32(txtDiscount.Text) * tongTien;
            txtThanhTien.Text = discount.ToString();

        }

        public void LoadToys()
        {
            List<Toy> toys = new List<Toy>();
            flpDsToy.Controls.Clear();
            ToyBL toyBL = new ToyBL();
            toys = toyBL.GetAll();

            foreach (var toy in toys)
            {
                var item = new CustomCotrols.ToyDetails(SetToyToPanel);
                item.LoadToy(toy.TenDoChoi, toy.GiaBan, toy);
                flpDsToy.Controls.Add(item);
            }
        }

        private void Form_Sell_Load(object sender, EventArgs e)
        {
            LoadToys();
            LoadCbbNhanVien();
        }
        #endregion


        #region Thêm hóa đơn & Chi tiết hóa đơn
        public int InsertBill()
        {
            Bills bill = BillCurrent;

            bill.TenKH = txtName.Text;
            bill.SDT = txtSDT.Text;
            bill.NgayBan = dtpNgayLapHD.Value;
            bill.KhuyenMai = Convert.ToDecimal(txtDiscount.Text);
            bill.ID_NV = int.Parse(cbbNhanVien.SelectedValue.ToString());
            BillsBL billBL = new BillsBL();

            return billBL.Insert(bill);

        }

        private int InsertBillDetail(int billID, int toyId, int quantity)
        {
            int result = 0;
            BillDetailsBL bdBL = new BillDetailsBL();
            BillDetails bd = new BillDetails();

            foreach (var item in listToy)
            {
                if (billID == 0) return -1;
                else
                {
                    bd.ID = 0;
                    bd.ID_HoaDon = billID;
                    bd.ToyID = item.Id;
                    bd.SoLuong = quantity;
                }
                result = bdBL.Insert(bd);
            }
            return result;
        }

        #endregion

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            int result = InsertBillDetail(InsertBill(), toyId, quantity);
            if (result > 0)
            {
                MessageBox.Show("Thêm hóa đơn thành công");
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thất bại");
            }
        }

        public void LoadCbbNhanVien()
        {
            NhanVienBL nhanVienBL = new NhanVienBL();
            listNV = nhanVienBL.GetAll();

            cbbNhanVien.DataSource = listNV;
            cbbNhanVien.ValueMember = "ID";
            cbbNhanVien.DisplayMember = "HoTen";
        }

        private void cbbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Toy> toys = new List<Toy>();
            flpDsToy.Controls.Clear();
            ToyBL toyBL = new ToyBL();
            toys = toyBL.Find(txtSearch.Text);
            foreach (var toy in toys)
            {
                var item = new CustomCotrols.ToyDetails(SetToyToPanel);
                item.LoadToy(toy.TenDoChoi, toy.GiaBan, toy);

                flpDsToy.Controls.Add(item);
            }
        }
    }
}
