using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BillsBL
    {
        BillDA billDA = new BillDA();
        public List<Bills> GetAll()
        {
            return billDA.GetAll();
        }
        public int countBills()
        {
            return billDA.countBills();
        }

        public int SumDiscount()
        {
            return billDA.SumDiscount();
        }

        public Bills GetByID(int ID)
        {
            List<Bills> list = GetAll();
            foreach (var item in list)
            {
                if (item.ID == ID)
                    return item;
            }
            return null;
        }

        public List<Bills> Find(string key)
        {
            List<Bills> list = GetAll();
            List<Bills> result = new List<Bills>();

            foreach (var item in list)
            {
                if (item.TenKH.ToString().Contains(key)
                    || item.SDT.Contains(key))
                    result.Add(item);
            }
            return result;
        }
        public int Insert(Bills bill)
        {
            return billDA.Insert_Update_Delete(bill, 0);
        }

        public int Update(Bills bill)
        {
            return billDA.Insert_Update_Delete(bill, 1);
        }

        public int Delete(Bills bill)
        {
            return billDA.Insert_Update_Delete(bill, 2);
        }
    }
}
