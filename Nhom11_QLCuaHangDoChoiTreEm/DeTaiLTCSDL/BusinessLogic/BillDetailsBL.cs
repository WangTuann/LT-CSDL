using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLogic
{
    public class BillDetailsBL
    {
        BillDetailsDA bdDA = new BillDetailsDA();

        public List<BillDetails> GetAll()
        {
            return bdDA.GetAll();
        }

        public DataTable GetSearch(int id)
        {
            return bdDA.GetSearchBillCustom(id);
        }
        public int Get_DoanhThu()
        {
            return bdDA.Get_DoanhThu();
        }
        public BillDetails GetByID(int ID)
        {
            List<BillDetails> list = GetAll();
            foreach (var bill in list)
            {
                if (bill.ID == ID)
                {
                    return bill;
                }
            }
            return null;
        }

        public int Insert(BillDetails billDetail)
        {
            return bdDA.Insert_Update_Delete(billDetail, 0);
        }

        public int Update(BillDetails billDetail)
        {
            return bdDA.Insert_Update_Delete(billDetail, 1);
        }

        public int Delete(BillDetails billDetail)
        {
            return bdDA.Insert_Update_Delete(billDetail, 2);
        }
    }
}
