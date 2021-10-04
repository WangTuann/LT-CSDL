using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Model
{
    public class SinhVien
    {
        public string MaSo { get; set; }
        public string HoTenLot { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string Lop { get; set; }
        public bool GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        List<String> monhoc { get; set; }



        public SinhVien(string ms, string ht, DateTime ngay, string ten,
 string dc, string lop, string hinh, bool gt, string sdt, string mail)
        {
            this.MaSo = ms;
            this.HoTenLot = ht;
            this.NgaySinh = ngay;
            this.DiaChi = dc;
            this.Lop = lop;
            this.GioiTinh = gt;
            this.SoDienThoai = sdt;
            this.Email = mail;
            this.Ten = ten;

        }

        public SinhVien()
        {
        }
    }
}
