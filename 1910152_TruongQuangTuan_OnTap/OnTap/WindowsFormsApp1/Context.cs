using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTap_QLSV.Data;

namespace OnTap_QLSV
{
    public class Context
    {
        private static Context singleObject;
        private List<SinhVien> listSV;
        private IDataSource dataSource;

        private Context(IDataSource data)
        {
            this.dataSource = data;
        }

        public static Context getInstance(IDataSource data)
        {
            if (singleObject == null)
            {
                singleObject = new Context(data);
            }
            return singleObject;
        }
        public List<SinhVien> GetSV()
        {
            if (listSV == null) listSV = dataSource.GetSV();
            return listSV;
        }


        public void SaveSV()
        {
            dataSource.Save(listSV);
        }
    }
}

