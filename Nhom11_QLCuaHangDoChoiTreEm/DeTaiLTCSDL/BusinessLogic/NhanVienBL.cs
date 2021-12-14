using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class NhanVienBL
    {
        NhanVienDA nhanVienDA = new NhanVienDA();

        public List<NhanVien> GetAll()
        {
            return nhanVienDA.GetAll();
        }
    }
}
