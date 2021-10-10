using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class QuanLySinhVien
    {
        public delegate int SoSanh(object sv1, object sv2);
        private readonly INewSinhVien _newsSinhVien;
        private List<Khoa> _khoas; // mấy cái này biết hết rồi chứ gì
        public List<SinhVien> danhSach;

        public QuanLySinhVien()
        {
            danhSach = new List<SinhVien>();
        }

        public QuanLySinhVien(INewSinhVien newsSinhVien)
        {
            _newsSinhVien = newsSinhVien;
        }
        // khỏi tạo 1 cái list khoa rỗng
        public List<Khoa> GetNew()
        {
            if (_khoas == null)
            {
                _khoas = _newsSinhVien.GetNews(); // thêm từng cái vào nó
            }
            return _khoas; // lăph lại file data.txt
        }
        // Lưu thay đổi
        public void SaveChanges()
        {
            _newsSinhVien.Save(_khoas);
        }
        // lười m chả làm thêm cái gì hết vậy
        public void Them(SinhVien sv)
        {
            this.danhSach.Add(sv);
        }
        public SinhVien this[int index]
        {
            get { return danhSach[index]; }
            set { danhSach[index] = value; }
        }
        public void DocTuFile()
        {
            string filename = "DanhSachSV.txt", t;
            string[] s;
            SinhVien sv;
            StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open));
            while ((t = sr.ReadLine()) != null)
            {
                s = t.Split('\t');
                sv = new SinhVien();
                sv.MSSV = s[0];
                sv.TenLot = s[1];
                sv.Ten = s[2];
                sv.Lop = s[3];
                sv.GioiTinh = false;
                if (s[4] == "1")
                    sv.GioiTinh = true;
                this.Them(sv);
            }
        }
        public List<SinhVien> Tim(object obj, SoSanh ss)
        {
            List<SinhVien> dskq = new List<SinhVien>();
            foreach (SinhVien item in danhSach)
            {
                if (ss(obj, item) == 0)
                {
                    dskq.Add(item);
                }
            }
            return dskq;
        }
        public void Xoa(object obj1,SoSanh ss)
        {
            int i = danhSach.Count - 1;
            for (; i >= 0; i--)
            {
                if (ss(obj1, this[i]) == 0)
                    this.danhSach.RemoveAt(i);
            }
        }
        public bool Sua(SinhVien svSua, object obj1, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.danhSach.Count - 1;
            for (i = 0; i < count; i++)
            {
                if (ss(obj1, this[i]) == 0)
                {
                    this[i] = svSua;
                    kq = true;
                    break;
                }
            }
            return kq;
        }
    }
}
