using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ToyBL
    {
        ToyDA toyDA = new ToyDA();

        // Phương thức lấy hết dữ liệu đồ chơi
        public List<Toy> GetAll()
        {
            return toyDA.GetAll();
        }
        public int chiphiNhap()
        {
            return toyDA.chiPhiNhap();
        }

        public List<Toy> Find(string key)
        {
            List<Toy> list = GetAll();
            List<Toy> result = new List<Toy>();

            foreach (var item in list)
            {
                if (item.GiaBan.ToString().Contains(key)
                    || item.TenDoChoi.Contains(key)
                    || item.SoLuong.ToString().Contains(key)
                    || item.DoTuoi.Contains(key)
                    || item.XuatXu.Contains(key))
                    result.Add(item);
            }
            return result;
        }

        public int Insert(Toy toy)
        {
            return toyDA.Insert_Update_Delete(toy, 0);
        }
        public int Update(Toy toy)
        {
            return toyDA.Insert_Update_Delete(toy, 1);
        }
        public int Delete(Toy toy)
        {
            return toyDA.Insert_Update_Delete(toy, 2);
        }
    }
}
