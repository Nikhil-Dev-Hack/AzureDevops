using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSHCONSOLE.ADONET
{
    public class ConnectToSQLServer
    {
        private string connectionString;
        private SqlConnection objConn;

        public ConnectToSQLServer()
        {
            connectionString = "Data Source=192.168.50.95;Initial Catalog=ASHOK;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            objConn = new SqlConnection(connectionString);
            objConn.Open();
            if(objConn.State == System.Data.ConnectionState.Open)
                Console.WriteLine("Connection established successfullly...");
            objConn.Close();
        }

        public void Execute()
        {
            
        }
    }
}
