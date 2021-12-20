using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BillDetailsDA
    {
        public List<BillDetails> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.BillDetails_GetAll;

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<BillDetails> list = new List<BillDetails>();
            while (reader.Read())
            {
                BillDetails billDetails = new BillDetails();
                billDetails.ID = Convert.ToInt32(reader["ID"]);
                billDetails.ID_HoaDon = Convert.ToInt32(reader["ID_HD"]);
                billDetails.ToyID = Convert.ToInt32(reader["ID_DC"]);
                billDetails.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                list.Add(billDetails);
            }
            sqlConnection.Close();
            return list;
        }

        public DataTable GetSearchBillCustom(int Id_HD)
        {
            //connec
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Loai_GetSearchBilCustom;
            
            sqlConnection.Open();
            SqlParameter IDPara = new SqlParameter("@Hd_ID", SqlDbType.Int);
            IDPara.Direction = System.Data.ParameterDirection.InputOutput;
            cmd.Parameters.Add(IDPara).Value = Id_HD;
            SqlDataReader reader = cmd.ExecuteReader();
            //doc du lieu len
            //lay data
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Mã hóa đơn", typeof(int));
            dataTable.Columns.Add("Tên đồ chơi", typeof(string));
            dataTable.Columns.Add("Số lượng", typeof(int));
            dataTable.Columns.Add("Tên khách hàng", typeof(string));
            //doc du lieu tra ve kieu table
            while (reader.Read())
            {
                dataTable.Rows.Add(reader["Id_Hd"], reader["TenSanPham"], reader["SoLuong"], reader["TenKH"]);
            }
            sqlConnection.Close();
            return dataTable;
        }

        public DataTable GetSearchToyCustom(string tenDC)
        {
            //connec
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Loai_GetSearchToyCustom;

            sqlConnection.Open();
            SqlParameter IDPara = new SqlParameter("@tenDC", SqlDbType.NVarChar);
            IDPara.Direction = System.Data.ParameterDirection.InputOutput;
            cmd.Parameters.Add(IDPara).Value = tenDC;
            SqlDataReader reader = cmd.ExecuteReader();
            //doc du lieu len
            //lay data
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên đồ chơi", typeof(string));
            dt.Columns.Add("Mã đồ chơi", typeof(int));
            dt.Columns.Add("Tên khách hàng", typeof(string));
                
            //doc du lieu tra ve kieu table
            while (reader.Read())
            {
                dt.Rows.Add(reader["TenSanPham"], reader["ID"], reader["TenKH"]);
            }
            sqlConnection.Close();
            return dt;
        }

        public DataTable SearchCustomerDetail(string tenKH)
        {
            //connec
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Loai_SearchKhachHang;

            sqlConnection.Open();
            SqlParameter IDPara = new SqlParameter("@tenKH", SqlDbType.NVarChar,1000);
            IDPara.Direction = System.Data.ParameterDirection.InputOutput;
            cmd.Parameters.Add(IDPara).Value = tenKH;
            SqlDataReader reader = cmd.ExecuteReader();
            //doc du lieu len
            //lay data
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên khách hàng", typeof(string));
            dt.Columns.Add("Tên đồ chơi", typeof(string));
            dt.Columns.Add("Mã đồ chơi", typeof(int));
            

            //doc du lieu tra ve kieu table
            while (reader.Read())
            {
                dt.Rows.Add(reader["TenKH"],reader["TenSanPham"], reader["ID"]);
            }
            sqlConnection.Close();
            return dt;
        }

        public int Get_DoanhThu()
        {
            SqlConnection sqlConnection = new SqlConnection(Ultilities.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.DoanhThu;
            SqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = Convert.ToInt32(reader["DoanhThu"].ToString());
            }
            sqlConnection.Close();
            return count;
        }

        public int Insert_Update_Delete(BillDetails billDetails, int action)
        {
            SqlConnection conn = new SqlConnection(Ultilities.ConnectionString);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.BillDetails_InsertUpdateDelete;

            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = System.Data.ParameterDirection.InputOutput;
            cmd.Parameters.Add(IDPara).Value = billDetails.ID;

            cmd.Parameters.Add("@ID_HD", SqlDbType.Int).Value = billDetails.ID_HoaDon;
            cmd.Parameters.Add("@ToyID", SqlDbType.Int).Value = billDetails.ToyID;
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = billDetails.SoLuong;
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
