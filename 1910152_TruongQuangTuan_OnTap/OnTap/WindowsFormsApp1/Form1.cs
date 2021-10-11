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
        private const string _placeHolderText = "Nhập thông tin cần tìm !!!!";
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

        private void LoadListView(List<SinhVien> danhSach)
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in danhSach)
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
            SetUpSearchInputText();

        }

        private void SetUpSearchInputText()
        {
            txtSearch.Text = _placeHolderText;
            txtSearch.GotFocus += RemovePlaceHolerText;
            txtSearch.LostFocus += ShowPlaceHolderText;
        }
       

        private void ShowPlaceHolderText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                txtSearch.Text = _placeHolderText;
        }

        private void RemovePlaceHolerText(object sender, EventArgs e)
        {
            if (txtSearch.Text == _placeHolderText)
                txtSearch.Text = "";
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
            else if (e.Node.Level > 0)
            {
                string tenLop = tvwKhoa.SelectedNode.Text;
                dsKQ = qlsv.DSTim(tenLop.Trim(), SoSanhTheoLop);
                LoadListView(dsKQ);
            }
        }

        //private void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    SinhVien sv = null;
        //    KieuTim kieu = KieuTim.MSSV;
        //    if (rdMSSV.Checked)
        //        kieu = KieuTim.MSSV;
        //    if (rdTen.Checked)
        //        kieu = KieuTim.Ten;
        //    if (rdSDT.Checked)
        //        kieu = KieuTim.SDT;


        //    switch (kieu)
        //    {
        //        case KieuTim.Ten:
        //            sv = qlsv.danhSach.Find(x => x.Ten == txtSearch.Text);
        //            break;
        //        case KieuTim.MSSV:
        //            sv = qlsv.danhSach.Find(x => x.MSSV == txtSearch.Text);
        //            break;
        //        case KieuTim.SDT:
        //            sv = qlsv.danhSach.Find(x => x.NgaySinh.Day == int.Parse(txtSearch.Text));
        //            break;
        //        default:
        //            break;
        //    }

        //        ListViewItem item = new ListViewItem(sv.MSSV);
        //        item.SubItems.Add(sv.Ten);
        //        item.SubItems.Add(sv.MSSV);
        //        item.SubItems.Add(sv.TenLot);
        //        item.SubItems.Add(sv.Lop);
        //        item.SubItems.Add(sv.GioiTinh ? "Nam" : "Nữ");
        //        item.SubItems.Add(sv.Sdt);
        //        item.SubItems.Add(sv.DiaChi);
        //        item.SubItems.Add(sv.Khoa);
        //        item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));

        //        lvSinhVien.Items.Clear();
        //        lvSinhVien.Items.Add(item);

        //}

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<SinhVien> dsKQ = new List<SinhVien>();
            lvSinhVien.Items.Clear();
            if (rdMSSV.Checked)
            {
                foreach (var sv in qlsv.danhSach)
                    if (sv.MSSV.ToLower().StartsWith(txtSearch.Text.Trim().ToLower()))
                        dsKQ.Add(sv);
                LoadListView(dsKQ);
            }
            if (rdTen.Checked)
            {
                foreach (var sv in qlsv.danhSach)
                    if (sv.Ten.ToLower().StartsWith(txtSearch.Text.Trim().ToLower()))
                        dsKQ.Add(sv);
                LoadListView(dsKQ);
            }
            if (rdSDT.Checked)
            {
                foreach (var sv in qlsv.danhSach)
                    if (sv.Sdt.ToLower().StartsWith(txtSearch.Text.Trim().ToLower()))
                        dsKQ.Add(sv);
                LoadListView(dsKQ);
            }
            if (txtSearch.Text == _placeHolderText)
                LoadListView(qlsv.danhSach);

        }
        //xoa

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int count;
            ListViewItem lvItems;
            count = lvSinhVien.Items.Count - 1;
            for (int i = count; i>=0; i--)
            {
                lvItems = lvSinhVien.Items[i];
                if (lvItems.Selected)
                {
                    qlsv.Xoa(lvItems.SubItems[0].Text, SoSanhTheoMa);
                }
            }
            LoadListView(qlsv.danhSach);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<SinhVien> dsKQ = new List<SinhVien>();
            frmStudentInfo frm = new frmStudentInfo();
            int count = lvSinhVien.SelectedItems.Count;
        }
    }
}

