using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.DATA;
using QuanLySinhVien.Model;

namespace QuanLySinhVien.DATA
{
    public class DSSV_Text_data:ISVDataSource
    {
        private string fileName;

        public DSSV_Text_data(string fileName)
        {
            this.fileName = fileName;
        }

        public List<SinhVien> GetSV()
        {
            List<SinhVien> sinhViens = new List<SinhVien>();
            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var sinhvien = ParseSV(line);
                        sinhViens.Add(sinhvien);
                    }
                }
            }
            return sinhViens;
        }

        public void Save(List<SinhVien> sv)
        {
            using (var writer = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite)))
            {
                foreach (var item in sv)
                {
                    var line = SaveFormat(item);
                    writer.WriteLine(line);
                }
            }
        }

        private SinhVien ParseSV(string line)
        {
            var parts = line.Split('*');
            return new SinhVien()
            {
                MaSo = parts[0],
                HoTenLot = parts[1],
                Ten = parts[2],
                GioiTinh = (int.Parse(parts[3]) == 1 ? true : false),
                NgaySinh = DateTime.Parse(parts[4]),
                Lop = parts[5],
                CMND = parts[6],
                SoDienThoai = parts[7],
                DiaChi = parts[8],
                
                monhoc = addMonHoc(parts[9])
            };
        }
        private string SaveFormat(SinhVien sinhvien)
        {
            string dsMonHoc = string.Join(",", sinhvien.monhoc);
            if (string.IsNullOrWhiteSpace(dsMonHoc))
                dsMonHoc = "null";
            return string.Format("{0}*{1}*{2}*{3}*{4}*{5}*{6}*{7}*{8}*{9}",
                sinhvien.MaSo,
                sinhvien.HoTenLot,
                sinhvien.Ten,
                sinhvien.NgaySinh.ToShortDateString(),
                sinhvien.Lop,
                sinhvien.CMND,
                sinhvien.SoDienThoai,
                sinhvien.DiaChi,
                (sinhvien.GioiTinh == true ? "1" : "0"),
                dsMonHoc);
        }
        private List<string> addMonHoc(string line)
        {
            List<string> mh = new List<string>();
            string[] monHoc = line.Split(',');
            foreach (string item in monHoc)
            {
                mh.Add(item);
            }
            return mh;
        }
    }
}

