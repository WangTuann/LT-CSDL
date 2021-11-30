using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AccountBL
    {
        AccountDA accountDA = new AccountDA();
        public List<Account> GetAll()
        {
            return accountDA.GetAll();
        }
        public Account GetByAccName(string name)
        {
            List<Account> list = GetAll();
            foreach (var item in list)
            {
                if (item.AccountName == name)
                    return item;
            }
            return null;
        }
        public List<Account> Find(String key)
        {
            List<Account> list = GetAll();
            List<Account> result = new List<Account>();

            foreach (var item in list)
            {
                if (item.AccountName.ToString().Contains(key)
                    || item.Password.Contains(key)
                    || item.FullName.Contains(key)
                    || item.Email.Contains(key)
                    || item.Tell.Contains(key)
                    || item.DateCreate.ToString().Contains(key))
                    result.Add(item);
            }
            return result;
        }

        public int Insert(Account acc)
        {
            return accountDA.Insert_Update_Delete(acc, 0);
        }
        public int Update(Account acc)
        {
            return accountDA.Insert_Update_Delete(acc, 1);
        }
        public int Delete(Account acc)
        {
            return accountDA.Insert_Update_Delete(acc, 2);
        }
    }
}
