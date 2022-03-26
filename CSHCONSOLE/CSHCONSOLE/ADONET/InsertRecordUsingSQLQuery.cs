using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSHCONSOLE.ADONET
{
    public class InsertRecordUsingSQLQuery
    {
        private string connectionString;
        private SqlConnection objConn;

        public InsertRecordUsingSQLQuery()
        {
            connectionString = "Data Source=192.168.50.95;Initial Catalog=ASHOK;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            objConn = new SqlConnection(connectionString);
        }
        public void Execute()
        {
            Console.WriteLine("Enter DeptName, Location:");
            string deptName = Console.ReadLine();
            string location = Console.ReadLine();
            objConn.Open();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Department VALUES(@DeptName, @Loc)", objConn);
            sqlCommand.Parameters.AddWithValue("@DeptName", deptName);
            sqlCommand.Parameters.AddWithValue("@Loc", location);
            sqlCommand.ExecuteNonQuery();
            objConn.Close();
        }
    }
}
