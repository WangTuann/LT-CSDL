using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Bills
    {
        public int ID { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public DateTime NgayBan { get; set; }
        public Decimal KhuyenMai { get; set; }

        public int ID_NV { get; set; }
    }
}
