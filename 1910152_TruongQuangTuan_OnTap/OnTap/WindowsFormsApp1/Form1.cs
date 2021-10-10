using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<SinhVien> sinhVienList;
        QuanLySinhVien qlsv;

        public Form1(QuanLySinhVien quanLySinhVien)
        {
            qlsv = quanLySinhVien;
            InitializeComponent();
        }
        private void ShowTreeOnTreeView(List<Khoa> khoas)
        {
            tvwKhoa.Nodes.Clear();
            lvSinhVien.Controls.Clear();
            foreach (var khoa in khoas)
            {
                var khoaNode = tvwKhoa.Nodes.Add(khoa.TenKhoa);
                foreach (var lop in khoa.Lops)
                {
                    khoaNode.Nodes.Add(lop.TenLop);
                }

            }
            tvwKhoa.ExpandAll();
        }
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MSSV);
            lvitem.SubItems.Add(sv.TenLot);
            lvitem.SubItems.Add(sv.Ten);
            string gt = (sv.GioiTinh == true ? "Nam" : "Nữ");
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Sdt);
            lvitem.SubItems.Add(sv.Lop);
            this.lvSinhVien.Items.Add(lvitem);
        }
        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.danhSach)
            {
                ThemSV(sv);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowTreeOnTreeView(qlsv.GetNew());
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile();
            LoadListView();

        }
        private SinhVien GetSVLV(ListViewItem item)
        {
            return new SinhVien()
            {
                MSSV = item.SubItems[0].Text,
                TenLot= item.SubItems[1].Text,
                Ten = item.SubItems[2].Text,
                GioiTinh = item.SubItems[3].Text == "Nam" ? true : false,
                NgaySinh = DateTime.Parse(item.SubItems[4].Text),
                Sdt = item.SubItems[5].Text,
                Lop= item.SubItems[6].Text,
                Khoa= item.SubItems[7].Text,
                DiaChi= item.SubItems[8].Text
            };
        }
        private int SoSanhTheoKhoa(object obj1, object obj2)
        {
            return (obj2 as SinhVien).Khoa.CompareTo(obj1.ToString());
        }
        private int SoSanhTheoLop(object obj1, object obj2)
        {
            return (obj2 as SinhVien).Lop.CompareTo(obj1.ToString());
        }
        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MSSV.CompareTo(obj1);
        }
        private int SoSanhTheoTen(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.Ten.CompareTo(obj1);
        }
        private string GetKhoa(SinhVien sv)
        {
            return sv.Khoa;
        }
        private string GetLop(SinhVien sv)
        {
            return sv.Lop;
        }

        private void tvwKhoa_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<SinhVien> dsKQ = new List<SinhVien>();
            lvSinhVien.Items.Clear();
            if (e.Node.Level==0)
            {
                string tenKhoa = tvwKhoa.SelectedNode.Text;
                dsKQ = qlsv.Tim(tenKhoa.Trim(), SoSanhTheoLop);
                LoadListView();
            }
            else if (true)
            {
                string tenLop = tvwKhoa.SelectedNode.Text;
                dsKQ = qlsv.Tim(tenLop.Trim(), SoSanhTheoLop);
                LoadListView();
            }

        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
