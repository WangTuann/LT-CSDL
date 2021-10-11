using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnTap_QLSV.Model;
using OnTap_QLSV.IO;
using OnTap_QLSV.Data;


namespace OnTap_QLSV
{
    public partial class Form1 : Form
    {
        List<SinhVien> sinhVienList;
        QuanLySinhVien qlsv;
        string fileName;
        private readonly NewRepo newRepo;

        public Form1()
        {
            InitializeComponent();
            fileName = "Data\\data.txt";
            List<Khoa> dsKhoa = new List<Khoa>();
            qlsv = new QuanLySinhVien(Context.getInstance(new TextData(fileName)));
            newRepo = NewRepo.getInstance(qlsv);
        }

        #region Các hàm xử lý
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

        private void LoadListView(List<SinhVien>danhSach)
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.danhSach)
            {
                ThemSV(sv);
            }
        }
        private SinhVien GetSVLV(ListViewItem item)
        {
            return new SinhVien()
            {
                MSSV = item.SubItems[0].Text,
                TenLot = item.SubItems[1].Text,
                Ten = item.SubItems[2].Text,
                GioiTinh = item.SubItems[3].Text == "Nam" ? true : false,
                NgaySinh = DateTime.Parse(item.SubItems[4].Text),
                Sdt = item.SubItems[5].Text,
                Lop = item.SubItems[6].Text,
                Khoa = item.SubItems[7].Text,
                DiaChi = item.SubItems[8].Text
            };
        }
        private void ShowFeedOnTreeView(List<Khoa> dsKhoa)
        {
            tvwKhoa.Nodes.Clear();
            foreach (var k in dsKhoa)
            {
                var khoaNode = tvwKhoa.Nodes.Add(k.Name);
                foreach (var l in k.Lop)
                {
                    khoaNode.Nodes.Add(l.Name);
                }
            }
            tvwKhoa.ExpandAll();
        }
        private string GetKhoa(SinhVien sv)
        {
            return sv.Khoa;
        }
        private string GetLop(SinhVien sv)
        {
            return sv.Lop;
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
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            //ShowTreeOnTreeView(qlsv.danhSach);
            //qlsv = new QuanLySinhVien();
            //qlsv.DocTuFile();
            LoadListView(qlsv.danhSach);
            ShowFeedOnTreeView(newRepo.GetKhoa());
            LoadListView(qlsv.danhSach);

        }
        private void tvwKhoa_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<SinhVien> dsKQ = new List<SinhVien>();
            lvSinhVien.Items.Clear();
            if (e.Node.Level == 0)
            {
                string tenKhoa = tvwKhoa.SelectedNode.Text;
                dsKQ = qlsv.DSTim(tenKhoa.Trim(), SoSanhTheoLop);
                LoadListView(dsKQ);
            }
            else if (true)
            {
                string tenLop = tvwKhoa.SelectedNode.Text;
                dsKQ = qlsv.DSTim(tenLop.Trim(), SoSanhTheoLop);
                LoadListView(dsKQ);
            }
        }
        
    }
}

