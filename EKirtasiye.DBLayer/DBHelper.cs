using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace EKirtasiye.DBLayer
{
    public static class DBHelper
    {
        public static string SqlConnectionStr = string.Empty;
        public static SqlConnection GetOpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(SqlConnectionStr);

            sqlConnection.Open();

            return sqlConnection;
        }

        public static void ExecuteCommand(string procedureName,SqlParameter[] sqlParameters)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = procedureName;
                    sqlCommand.Parameters.AddRange(sqlParameters);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
        public static void ExecuteCommand(string sqlCommandText)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandText = sqlCommandText;
                    
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetQuery(string queryStr)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandText = queryStr;

                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.Fill(dataTable);
                    }

                    return dataTable;
                }
            }
        }
        

    }
}
