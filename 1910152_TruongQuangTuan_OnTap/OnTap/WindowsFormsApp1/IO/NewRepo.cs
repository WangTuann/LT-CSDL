using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTap_QLSV.Model;


namespace OnTap_QLSV.IO
{
    public class NewRepo : INewRepo
    {
        private static NewRepo singleObject;
        private QuanLySinhVien qlsv;
        private NewRepo(QuanLySinhVien qlsv)
        {
            this.qlsv = qlsv;
        }

        public static NewRepo getInstance(QuanLySinhVien qlsv)
        {
            if (singleObject == null)
                singleObject = new NewRepo(qlsv);
            return singleObject;
        }
        public List<Khoa> GetKhoa()
        {
            List<Khoa> dsKhoa = new List<Khoa>();
            foreach (var item in GetDSKhoa(qlsv.danhSach))
            {
                List<Lop> dsLop = new List<Lop>();
                foreach (var l in GetDSLop(item))
                    dsLop.Add(new Lop(l));
                dsKhoa.Add(new Khoa(item, dsLop));
            }
            return dsKhoa;
        }

        private List<string> GetDSKhoa(List<SinhVien> dssv)
        {
            List<string> tenKhoa = new List<string>();
            foreach (var item in dssv)
            {
                if (!tenKhoa.Contains(item.Khoa))
                    tenKhoa.Add(item.Khoa);
            }
            return tenKhoa;
        }
        private List<string> GetDSLop(string tenKhoa)
        {
            List<string> dsLop = new List<string>();
            foreach (var item in qlsv.danhSach)
                if (item.Khoa.CompareTo(tenKhoa) == 0)
                    if (!dsLop.Contains(item.Lop))
                        dsLop.Add(item.Lop);
            return dsLop;
        }
    }
}
