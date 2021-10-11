using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTap_QLSV.Data
{
    public class TextData : IDataSource
    {
        private string fileName;

        public TextData(string fileName)
        {
            this.fileName = fileName;
        }

        public List<SinhVien> GetSV()
        {
            List<SinhVien> listSV = new List<SinhVien>();
            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(new FileStream(fileName, FileMode.Open, FileAccess.Read)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var sinhvien = ParseSV(line);
                        listSV.Add(sinhvien);
                    }
                }
            }
            return listSV;
        }

        //public List<SinhVien> GETSV()
        //{
        //    throw new NotImplementedException();
        //}

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
            var parts = line.Split('\t');
            return new SinhVien()
            {
                MSSV = parts[0],
                TenLot= parts[1],
                Ten = parts[2],
                Lop= parts[3],
                Khoa= parts[4],
                GioiTinh= true,
                NgaySinh = DateTime.MinValue,
                Sdt = "",
                DiaChi= ""
            };
        }

        private string SaveFormat(SinhVien sv)
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}",
                sv.MSSV,
                sv.TenLot,
                sv.Ten,
                sv.Lop,
                sv.Khoa,
                (sv.GioiTinh== true ? "1" : "0"),
                sv.NgaySinh,
                sv.Sdt,
                sv.DiaChi);
        }
    }
}
