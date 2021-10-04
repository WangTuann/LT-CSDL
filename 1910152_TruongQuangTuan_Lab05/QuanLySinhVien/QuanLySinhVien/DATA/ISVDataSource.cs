using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Model;

namespace QuanLySinhVien.DATA
{
    public interface ISVDataSource
    {
        List<SinhVien> GetSV();
        void Save(List<SinhVien> sv);
    }
}
