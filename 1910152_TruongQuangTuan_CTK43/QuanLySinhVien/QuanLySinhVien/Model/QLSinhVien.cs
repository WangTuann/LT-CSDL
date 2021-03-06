using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLySinhVien.Model
{
    
   
    public class QLSinhVien

    {
        Context context;
        public delegate int SoSanh(object sv1, object sv2);
        public List<SinhVien> DanhSach;

        public QLSinhVien(Context context)
        {
            this.context = context;
            DanhSach = context.GetSV();
        }
        public void Them(SinhVien sv)
        {
            this.DanhSach.Add(sv);
        }
        public void Xoa(object obj, SoSanh ss)
        {
            int i = DanhSach.Count - 1;
            for (; i >= 0; i--)
                if (ss(obj, this[i]) == 0)
                {
                    this.DanhSach.RemoveAt(i);
                }
        }
        public SinhVien this[int index]
        {
            get { return DanhSach[index]; }
            set { DanhSach[index] = value; }
        }
        public SinhVien Tim(object obj, SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien sv in DanhSach)
            {
                if (ss(obj, sv) == 0)
                {
                    svresult = sv;
                    break;
                }
            }
            return svresult;
        }
        public bool Sua(SinhVien svSua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = DanhSach.Count - 1;
            for (i = 0; i < count; i++)
            {
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = svSua;
                    kq = true;
                    break;
                }
            }
            return kq;
        }

    }
}
