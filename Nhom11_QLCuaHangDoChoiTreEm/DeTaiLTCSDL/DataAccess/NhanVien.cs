using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class NhanVien
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public bool TrangThai { get; set; }
    }
}
