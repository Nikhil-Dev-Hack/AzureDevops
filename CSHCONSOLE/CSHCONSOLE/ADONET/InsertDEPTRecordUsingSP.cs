using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSHCONSOLE.ADONET
{
    public class InsertDEPTRecordUsingSP
    {
        private string connectionString;
        private SqlConnection objConn;

        public InsertDEPTRecordUsingSP()
        {
            connectionString = "Data Source=192.168.50.95;Initial Catalog=ASHOK;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            objConn = new SqlConnection(connectionString);
        }

        public void Execute()
        {
            try
            {
                Console.WriteLine("Enter DeptName, Location:");
                string deptName = Console.ReadLine();
                string location = Console.ReadLine();
                objConn.Open();
                throw new Exception("Terrible error occurred");
                SqlCommand objCmd = new SqlCommand("usp_CreateDepartment", objConn);
                objCmd.CommandType = System.Data.CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@DeptName", deptName);
                objCmd.Parameters.AddWithValue("@Location", location);
                objCmd.ExecuteNonQuery();
                objConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred, error message: " + ex.Message);
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                    objConn.Close();
            }
        }
    }
}
