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

        public frmStudentInfo(QuanLySinhVien qlsv, NewRepo newRepo)
        {
            InitializeComponent();
            this.qlsv = qlsv;
            this.newRepo = newRepo;
        }

        #region Ham xu ly

        private void ThietLapCbb(List<Khoa> dskhoa)
        {
            cbbKhoa.Items.Clear();
            cbbLop.Items.Clear();
            foreach (var k in dskhoa)
            {
                cbbKhoa.Items.Add(k.Name);
                foreach (var l in k.Lop)
                {
                    cbbLop.Items.Add(l.Name);
                }
            }
        }

        private SinhVien GetSVToControl()
        {
            SinhVien sv = new SinhVien();
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
                rdNam.Checked = (sv.GioiTinh == true ? true : false);
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
            SinhVien svUpdate = GetSVToControl();
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
            ThietLapCbb(newRepo.GetKhoa());
            cbbKhoa.Text = tenKhoa;
            cbbLop.Text = tenLop;
            LoadSVToControl();
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string khoa = cbbKhoa.Text.Trim();
            cbbLop.Items.Clear();
            foreach (var item in newRepo.GetKhoa())
            {
                if (khoa.CompareTo(item.Name) == 0)
                {
                    foreach (var l in item.Lop)
                    {
                        cbbLop.Items.Add(l.Name);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //SinhVien sv = qlsv.Tim(GetSVToControl().MSSV, delegate (object obj1, object obj2)
            //       {
            //           return (obj2 as SinhVien).MSSV.CompareTo(obj1.ToString());
            //       });
            SinhVien sv = GetSVToControl();
            SinhVien kq = qlsv.Tim(sv.MSSV, delegate (object obj1, object obj2)
               {
                   return (obj2 as SinhVien).MSSV.CompareTo(obj1.ToString());
               });
            if (KiemTraThongTin())
            {
                if (kq != null)
                {
                    DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn cập nhật không?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dlg == DialogResult.Yes)
                    {
                        UpdateSinhVien(sv);
                        DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                }
                else
                {
                    qlsv.Them(GetSVToControl());
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
