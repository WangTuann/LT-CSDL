using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TypeDA
    {
        // Lấy hết dữ liệu đồ chơi theo thủ thục Type_GetAll
        public List<TypeToy> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Type_GetAll;

            // đọc dữ liệu
            SqlDataReader reader = command.ExecuteReader();
            List<TypeToy> list = new List<TypeToy>();
            while (reader.Read())
            {
                TypeToy type = new TypeToy();
                type.Id = Convert.ToInt32(reader["ID"]);
                type.TenLoai = reader["TenLoai"].ToString();
                type.GhiChu = reader["MoTa"].ToString();
                type.IdParent = Convert.ToInt32(reader["ID_Cha"].ToString() == "NULL" ? " " : reader["ID_Cha"].ToString());

                list.Add(type);
            }
            sqlConn.Close();
            return list;
        }
        public List<TypeToy> GetIDCha()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Loai_GetIDCha;

            // đọc dữ liệu
            SqlDataReader reader = command.ExecuteReader();
            List<TypeToy> list = new List<TypeToy>();
            while (reader.Read())
            {
                TypeToy type = new TypeToy();
                type.Id = Convert.ToInt32(reader["ID"]);
                type.TenLoai = reader["TenLoai"].ToString();
                type.GhiChu = reader["MoTa"].ToString();
                type.IdParent = Convert.ToInt32(reader["ID_Cha"].ToString() == "NULL" ? " " : reader["ID_Cha"].ToString());

                list.Add(type);
            }
            sqlConn.Close();
            return list;
        }
        public List<TypeToy> GetIDCon()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Loai_GetIDCon;

            // đọc dữ liệu
            SqlDataReader reader = command.ExecuteReader();
            List<TypeToy> list = new List<TypeToy>();
            while (reader.Read())
            {
                TypeToy type = new TypeToy();
                type.Id = Convert.ToInt32(reader["ID"]);
                type.TenLoai = reader["TenLoai"].ToString();
                type.GhiChu = reader["MoTa"].ToString();
                type.IdParent = Convert.ToInt32(reader["ID_Cha"].ToString() == "NULL" ? " " : reader["ID_Cha"].ToString());

                list.Add(type);
            }
            sqlConn.Close();
            return list;
        }


        public int Insert_Update_Delete(TypeToy type, int action)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Type_InsertUpdateDelete;

            //Thêm tham số
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput;
            command.Parameters.Add(IDPara).Value = type.Id;
            command.Parameters.Add("@TenLoai", SqlDbType.NVarChar, 1000).Value = type.TenLoai;
            command.Parameters.Add("@ID_Cha", SqlDbType.Int).Value = type.IdParent;
            command.Parameters.Add("@MoTa", SqlDbType.NVarChar, 1000).Value = type.GhiChu;
            command.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = command.ExecuteNonQuery();
            if (result > 0)
                return (int)command.Parameters["@ID"].Value;
            return 0;
        }
        
    }
}
