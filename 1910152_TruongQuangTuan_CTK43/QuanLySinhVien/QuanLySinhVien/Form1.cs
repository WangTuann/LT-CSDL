using QuanLySinhVien.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        
        Context _context;
        private List<string> dsMonHoc;
        private List<SinhVien> danhSachSV;
        QLSinhVien qlsv;
        public Form1(Context context)
        {
            InitializeComponent();
            _context = context;
            danhSachSV = context.GetSV();
            dsMonHoc = new List<string>
            {
                "Mạng máy tính",
                "Hệ điều hành",
                "Lập trình CSDL",
                "Lập trình mạng",
                "Đồ án cơ sở",
                "Phương pháp NCKH",
                "Lập trình trên thiết bị di động",
                "An toàn và bảo mật hệ thống"
            };
        }
        private void ThemSV(SinhVien sv)
        {
            ListViewItem item = new ListViewItem(sv.MaSo);
            item.SubItems.Add(sv.HoTenLot);
            item.SubItems.Add(sv.Ten);
            item.SubItems.Add(sv.NgaySinh.ToShortDateString());
            item.SubItems.Add(sv.Lop);
            item.SubItems.Add(sv.CMND);
            item.SubItems.Add(sv.SoDienThoai);
            item.SubItems.Add(sv.DiaChi);
            item.SubItems.Add(sv.GioiTinh == true ? "Nam" : "Nữ");
            item.SubItems.Add(string.Join(",", sv.monhoc));        

            this.lvSinhVien.Items.Add(item);
        }
        private void LoadListView(List<SinhVien> ds)
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.DanhSach)
            {
                ThemSV(sv);
            }
        }
        private void LoadSVToLV(List<SinhVien> danhsach)
        {
            lvSinhVien.Items.Clear();
            foreach (SinhVien sv in danhsach)
            {
                ThemSV(sv);
            }
        }
        private SinhVien GetSinhVienLV(ListViewItem item)
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = item.SubItems[0].Text;
            sv.HoTenLot = item.SubItems[1].Text;
            sv.Ten = item.SubItems[2].Text;
            sv.GioiTinh = false;
            if (item.SubItems[3].Text == "Nam")
            {
                sv.GioiTinh = true;
            }
            return sv;
            sv.NgaySinh = DateTime.Parse(item.SubItems[4].Text);
            sv.Lop = item.SubItems[5].Text;
            sv.CMND = item.SubItems[6].Text;
            sv.SoDienThoai = item.SubItems[7].Text;
            sv.DiaChi = item.SubItems[8].Text;
            
        }
        private void ThietLapThongTin(SinhVien sv)
        {
            this.mskMSSV.Text = sv.MaSo;
            this.txtHoDem.Text = sv.HoTenLot;
            this.txtTen.Text = sv.Ten;
            this.cbbLop.Text = sv.Lop;
            this.mtxtCMND.Text = sv.CMND;
            this.mtxtSDT.Text = sv.SoDienThoai;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.txtDiaChi.Text = sv.DiaChi;
            this.cbbLop.Text = sv.Lop;
            this.mtxtCMND.Text = sv.CMND;
            if (sv.GioiTinh)
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;
            for (int i = 0; i < clbMonHoc.Items.Count; i++)
                clbMonHoc.SetItemChecked(i, false);
            foreach (var mh in sv.monhoc)
            {
                for (int i = 0; i < clbMonHoc.Items.Count; i++)
                {
                    if (clbMonHoc.Items[i].ToString().CompareTo(mh) == 0)
                        clbMonHoc.SetItemChecked(i, true);
                }
            }
        }
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            sv.MaSo = this.mskMSSV.Text;
            sv.HoTenLot = this.txtHoDem.Text;
            sv.Ten = this.txtTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.GioiTinh = gt;
            sv.Lop = this.cbbLop.Text;
            sv.SoDienThoai = this.mtxtSDT.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            sv.CMND = this.mtxtCMND.Text;
            sv.GioiTinh = (rdNam.Checked == true ? true : false);
            List<string> dsmh = new List<string>();
            foreach (var item in clbMonHoc.CheckedItems)
            {
                dsmh.Add(item as string);
            }
            sv.monhoc = dsmh;
            return sv;
        }
        private SinhVien UpdateSV(SinhVien sv)
        {
            SinhVien svUpdate = GetSinhVien();
            sv.MaSo = svUpdate.MaSo;
            sv.HoTenLot = svUpdate.HoTenLot;
            sv.Ten = svUpdate.Ten;
            sv.NgaySinh = svUpdate.NgaySinh;
            sv.Lop = svUpdate.Lop;
            sv.CMND = svUpdate.CMND;
            sv.SoDienThoai = svUpdate.SoDienThoai;
            sv.DiaChi = svUpdate.DiaChi;
            sv.GioiTinh = svUpdate.GioiTinh;
            sv.monhoc = svUpdate.monhoc;
            return sv;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in dsMonHoc)
            {
                clbMonHoc.Items.Add(item, false);
                qlsv = new QLSinhVien(_context);
                LoadSVToLV(qlsv.DanhSach);
            }
        }
    }
}
