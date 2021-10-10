using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Lop
    {
        public string TenLop { get; set; }
  
        public List<SinhVien> listSinhVien { get; set; }
        public Lop()
        {
            listSinhVien = new List<SinhVien>();
        }
 
    }
}
