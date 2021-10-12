using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnTap_QLSV.IO;
using OnTap_QLSV.Model;

namespace OnTap_QLSV
{
    public partial class frmStudentInfo : Form
    {
        private QuanLySinhVien qlsv;
        private NewRepo newRepo;
        public string tenKhoa;
        public string tenLop;
        public SinhVien sv;

        public frmStudentInfo()
        {
            InitializeComponent();
            this.qlsv = qlsv;
            this.newRepo = newRepo;
        }

        #region Ham xu ly

        private void ThietLapCbb(List<Khoa> dsKhoa)
        {
            cbbKhoa.Items.Clear();
            cbbLop.Items.Clear();
            foreach (var k in dsKhoa)
            {
                cbbKhoa.Items.Add(k.Name);
                foreach (var l in k.Lop)
                {
                    cbbLop.Items.Add(l.Name);
                }
            }
        }

        private SinhVien GetSV()
        {
            SinhVien sv=new SinhVien();
            sv.MSSV = mtkMSSV.Text;
            sv.TenLot = txtHoLot.Text;
            sv.Ten = txtTen.Text;
            sv.Lop = cbbLop.Text;
            sv.Khoa = cbbKhoa.Text;
            sv.GioiTinh = (rdNam.Checked == true ? true : false);
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.Sdt = mtkbSDT.Text;
            sv.DiaChi = txtDiaChi.Text;
            return sv;
        }
        //KT trong

        private bool KiemTraThongTin()
        {
            if (string.IsNullOrEmpty(mtkMSSV.Text)) return false;
            else if (string.IsNullOrEmpty(txtHoLot.Text)) return false;
            else if (string.IsNullOrEmpty(txtTen.Text)) return false;
            else if (string.IsNullOrEmpty(cbbLop.Text)) return false;
            else if (string.IsNullOrEmpty(cbbKhoa.Text)) return false;
            else if (rdNam.Checked == false && rdNu.Checked == false) return false;
            else if (string.IsNullOrEmpty(mtkbSDT.Text)) return false;
            else if (string.IsNullOrEmpty(txtDiaChi.Text)) return false;
            return true;
        }

        private void LoadSVToControl()
        {
            if (sv != null)
            {
                mtkMSSV.Enabled = false;
                mtkMSSV.Text = sv.MSSV;
                txtHoLot.Text = sv.TenLot;
                txtTen.Text = sv.Ten;
                rdNam.Checked = (sv.GioiTinh== true ? true : false);
                rdNu.Checked = (sv.GioiTinh == false ? true : false);
                dtpNgaySinh.Text = DateTime.Now.ToShortDateString();
                cbbKhoa.Text = sv.Khoa;
                cbbLop.Text = sv.Lop;
                mtkbSDT.Text = sv.Sdt;
                txtDiaChi.Text = sv.DiaChi;
            }
        }

        private SinhVien UpdateSinhVien(SinhVien sv)
        {
            SinhVien svUpdate = GetSV();
            sv.TenLot = svUpdate.TenLot;
            sv.Ten = svUpdate.Ten;
            sv.Lop = svUpdate.Lop;
            sv.Khoa = svUpdate.Khoa;
            sv.GioiTinh = svUpdate.GioiTinh;
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.Sdt = svUpdate.Sdt;
            sv.DiaChi = svUpdate.DiaChi;
            return sv;
        }
        #endregion

        private void frmStudentInfo_Load(object sender, EventArgs e)
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            ThietLapCbb(newRepo.GetKhoa());
            cbbKhoa.Text = tenKhoa;
            cbbLop.Text = tenLop;
            LoadSVToControl();
        }
    }
}
