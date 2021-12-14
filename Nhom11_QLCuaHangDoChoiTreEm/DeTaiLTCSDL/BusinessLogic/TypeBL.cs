using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TypeBL
    {
        TypeDA typeDA = new TypeDA();
        public List<TypeToy> GetAll()
        {
            return typeDA.GetAll();
        }
        public List<TypeToy> GetIDCha()
        {
            return typeDA.GetIDCha();
        }
        public List<TypeToy> GetIDCon()
        {
            return typeDA.GetIDCon();
        }

        public TypeToy GetByID(int ID)
        {
            List<TypeToy> list = GetAll();
            foreach (var item in list)
            {
                if (item.Id == ID)
                    return item;
            }
            return null;
        }

        public int Insert(TypeToy type)
        {
            return typeDA.Insert_Update_Delete(type, 0);
        }
        public int Update(TypeToy type)
        {
            return typeDA.Insert_Update_Delete(type, 1);
        }
        public int Delete(TypeToy type)
        {
            return typeDA.Insert_Update_Delete(type, 2);
        }
    }
}
