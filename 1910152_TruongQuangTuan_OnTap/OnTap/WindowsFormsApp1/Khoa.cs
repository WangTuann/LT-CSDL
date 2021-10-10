using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Khoa
    {
        public string TenKhoa { get; set; }
        public List<Lop> Lops { get; set; }
        public Khoa()
        { 
            Lops = new List<Lop>();
        }

   
    }
}
