using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace DataAccess
{
    public class Category
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }
    }
}
