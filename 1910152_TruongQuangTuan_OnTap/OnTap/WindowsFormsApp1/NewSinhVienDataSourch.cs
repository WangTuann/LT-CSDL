using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class NewSinhVienDataSourch : INewSinhVien
    {
        private const string filePath = "data.txt";
        public List<Khoa> GetNews()
        {
            var khoas = new List<Khoa>(); // tạo 1 list khoa
            Khoa office = null; // rỗng
            string line; // hàng

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))// file hàm mở file đọc gfile
                {
                    using (var reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            if (line == null)    // dòng trống
                            {
                                break; // bỏ qua
                            }
                            if (line.StartsWith("@"))// dòng bắt đầu bằng @
                            {
                                office = ParseKhoa(line); // dòng đó khởi gán cho office , luuw vào khoa xong khởi gán 
                                khoas.Add(office);// bỏ bô list
                            }
                            else if (line.StartsWith("#") && office != null) // tương tự cái này là lisy lớp
                            {
                                var lop = ParseLop(line);
                                office.Lops.Add(lop);
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;   
            }
            return khoas;  // cái này kiểu qua lại đọc tiếp á line 1,2,3 ...
        }





        public void Save(List<Khoa> khoas)// hàm lưu
        {
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (var writer = new StreamWriter(stream))// viết hàm treeview
                {
                    foreach (var khoa in khoas) // đến từng khoa trong danh sách khpa
                    {
                        writer.WriteLine("@{0}", khoa.TenKhoa);  // viết vào cái treeview
                        foreach (var lop in khoa.Lops) // rồi mỗi cái khoa
                        {
                            writer.WriteLine("#{0}", lop.TenLop); // viết con của Khoa là Lớp
                        }
                    }
                }
            }
        }


        private Khoa ParseKhoa(string info) // hàm parse Khoa cho phần trên
        {
            return new Khoa()
            {
                TenKhoa = info.Substring(1).Trim() // này kiểu đến từng khoa rồi bỏ vô thui
            };
        }
        private Lop ParseLop(string info)
        {
            var parts = info.Substring(1).Split('^');// cía này quên xoá cho m thôi lỡ rồi kiểu cái này phân tách với danh sách SV ( link css)
            return new Lop()
            {
                TenLop = parts[0].Trim(),
               
            };
        }
    }
}
