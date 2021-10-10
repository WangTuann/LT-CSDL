using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class SinhVien
    {
        // này thì tạo lặp khỏi gán giá trị thui
        public string MSSV { get; set; }
        public string TenLot { get; set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }

        public string Sdt { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }
        public string DiaChi { get; set; }
        public List<string> DSSinhVien;

        public SinhVien()
        {

        }
        public SinhVien(string mssv, string hoVaTenLot, string ten, bool gt, DateTime ngaySinh, string sdt, string dc, string lop, string khoa)
        {
            this.MSSV = mssv;
            this.TenLot = hoVaTenLot;
            this.Ten = ten;
            this.GioiTinh = gt;
            this.NgaySinh = ngaySinh;
            this.Sdt = sdt;
            this.DiaChi = dc;
            this.Lop = lop;
            this.Khoa = khoa;
        
        }
    }
}
