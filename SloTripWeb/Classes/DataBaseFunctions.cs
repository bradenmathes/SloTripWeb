using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace SloTripWeb
{
    public static class DataBaseFunctions
    {
        private static SqlConnection GetConnection()
        {
            //Read a connection string from the app.config file
            string ConnectionString = ConfigurationManager.ConnectionStrings["SloTrip"].ConnectionString;
            return new SqlConnection(ConnectionString);
        }
        private static SqlCommand GetCommand(string commandText, SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();
            return sqlCommand;
        }
        public static DataTable GetDataTable(string commandText)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = GetConnection())
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    sqlDataAdapter.SelectCommand = new SqlCommand(commandText, sqlConnection);
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
                    sqlDataAdapter.Fill(dataTable);
                }
                sqlConnection.Close();
            }
            return dataTable;
        }
        public static void ExecuteNonQuery(string commandText)
        {
            //Non Query means we aren't expecting a result of a set of data
            //Examples are INSERT, UPDATE, and DELETE
            SqlConnection sqlConnection = GetConnection();
            SqlCommand sqlCommand = GetCommand(commandText, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlCommand.Dispose();
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
    }
}
