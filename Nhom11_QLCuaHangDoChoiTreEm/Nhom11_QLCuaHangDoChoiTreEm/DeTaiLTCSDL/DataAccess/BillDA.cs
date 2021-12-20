using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BillDA
    {
        public List<Bills> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Bill_GetAll;

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Bills> list = new List<Bills>();
            while (reader.Read())
            {
                Bills bill = new Bills();
                bill.ID = Convert.ToInt32(reader["ID"]);
                bill.TenKH = reader["TenKH"].ToString();
                bill.SDT = reader["SDT"].ToString();
                bill.NgayBan = Convert.ToDateTime(reader["NgayBan"]);
                bill.KhuyenMai = Convert.ToDecimal(reader["KhuyenMai"]);
                bill.ID_NV = Convert.ToInt32(reader["ID_NV"]);
                list.Add(bill);
            }
            sqlConnection.Close();
            return list;
        }
        public int countBills()
        {
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.HoaDon_SoLuong;

            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                 count = Convert.ToInt32(reader["SoLuong"].ToString());
            }

            sqlConnection.Close();
            return count;

        }

        public int SumDiscount()
        {
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.TongTienKhuyenMai;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = (int)Convert.ToDecimal(reader["TongKhuyenMai"].ToString());
            }
            sqlConnection.Close();
            return count;
        }

        public int Insert_Update_Delete(Bills bill, int action)
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Bill_InsertUpdateDelete;

            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = System.Data.ParameterDirection.InputOutput;
            cmd.Parameters.Add(IDPara).Value = bill.ID;

            cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar, 1000).Value = bill.TenKH;
            cmd.Parameters.Add("@SDT", SqlDbType.NVarChar, 1000).Value = bill.SDT;
            cmd.Parameters.Add("@NgayBan", SqlDbType.SmallDateTime).Value = bill.NgayBan;
            cmd.Parameters.Add("@KhuyenMai", SqlDbType.Decimal).Value = bill.KhuyenMai;
            cmd.Parameters.Add("ID_NV", SqlDbType.Int).Value = bill.ID_NV;
            cmd.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                return (int)cmd.Parameters["@ID"].Value;
            }
            conn.Close();
            return 0;
        }
    }
}
