using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;

namespace DAO
{
    public class Dataproviderr
    {
        public static string connectionString = "Data Source=101-4;Initial Catalog=QLHOCSINH;Integrated Security=True";
        public static SqlConnection conn;
        private SqlDataAdapter adapter;
        private SqlCommand command;
        public void connect()
        {
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                conn.Close();
            }
            catch
            {
                
            }
        }
      
        public void disconnect()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public DataTable executeQuery(string sqlString)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            adapter = new SqlDataAdapter(sqlString, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            disconnect();
            return ds.Tables[0];
        }
        public void executeNonQuery(string sqlString)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command = new SqlCommand(sqlString, conn);
            command.ExecuteNonQuery();
            disconnect();
        }
        public object executeScalar(string sqlString)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command = new SqlCommand(sqlString, conn);
            disconnect();
            return command.ExecuteScalar();
        }

    }
}
