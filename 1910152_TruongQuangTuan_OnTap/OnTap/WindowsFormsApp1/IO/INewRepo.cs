using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTap_QLSV.Model;

namespace OnTap_QLSV.IO
{
    public interface INewRepo
    {
        List<Khoa> GetKhoa();
    }
}
