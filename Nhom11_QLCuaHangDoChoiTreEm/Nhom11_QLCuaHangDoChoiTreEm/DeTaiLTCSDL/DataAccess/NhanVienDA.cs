using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class NhanVienDA
    {
        public List<NhanVien> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Account_GetAll;

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<NhanVien> list = new List<NhanVien>();
            while (reader.Read())
            {
                NhanVien nv = new NhanVien();
                nv.ID = Convert.ToInt32(reader["ID"]);
                nv.HoTen = reader["HoTen"].ToString();
                nv.DiaChi = reader["DiaChi"].ToString();
                nv.Sdt = reader["SDT"].ToString();
                nv.TaiKhoan = reader["TaiKhoan"].ToString();
                nv.MatKhau = reader["MatKhau"].ToString();
                nv.TrangThai = bool.Parse(reader["TrangThai"].ToString());

                list.Add(nv);
            }

            return list;
        }
    }
}
