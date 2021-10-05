using QuanLySinhVien.DATA;
using QuanLySinhVien.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    public class Context
    {
        private static Context singleObject;
        private List<SinhVien> _sinhVien;
        private ISVDataSource _dataSource;

        public   Context(ISVDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public static Context getInstance(ISVDataSource dataSource)
        {
            if (singleObject == null)
            {
                singleObject = new Context(dataSource);
            }
            return singleObject;
        }

        public List<SinhVien> GetSV()
        {
            if (_sinhVien == null) 
                _sinhVien= _dataSource.GetSV();
            return _sinhVien;
        }

        public void SaveSV()
        {
            _dataSource.Save(_sinhVien);
        }
    }
}
