using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDA
    {
        public List<Account> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Ultilities.Account_GetAll;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Account> list = new List<Account>();
            while (reader.Read())
            {
                Account acc = new Account(); ;
                acc.AccountName = reader["AccountName"].ToString();
                acc.Password = reader["Password"].ToString();
                acc.FullName = reader["FullName"].ToString();
                acc.Email = reader["Email"].ToString();
                acc.Tell = reader["Tell"].ToString();
              //  acc.DateCreate = Convert.ToDateTime(reader["DateCreate"].ToString());
                list.Add(acc);
            }
            sqlConn.Close();
            return list;
        }

        public int Insert_Update_Delete(Account acc, int action)
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.Open();

            SqlCommand sqlCommand = sqlConn.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = Ultilities.Account_InsertUpdateDelete;

            sqlCommand.Parameters.Add("@AccountName", SqlDbType.NVarChar, 100).Value = acc.AccountName;
            sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 200).Value = acc.Password;
            sqlCommand.Parameters.Add("@FullName", SqlDbType.NVarChar, 1000).Value = acc.FullName;
            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 1000).Value = acc.Email;
            sqlCommand.Parameters.Add("@Tell", SqlDbType.NVarChar, 200).Value = acc.Tell;
            sqlCommand.Parameters.Add("@DateCreate", SqlDbType.SmallDateTime).Value = acc.DateCreate;

            int result = sqlCommand.ExecuteNonQuery();

            if (result > 0)
                return (int)sqlCommand.Parameters["AccountName"].Value;
            return 0;
        }
    }
}
