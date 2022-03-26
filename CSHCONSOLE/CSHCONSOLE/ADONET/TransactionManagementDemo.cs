using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSHCONSOLE.ADONET
{
    public class TransactionManagementDemo
    {
        private string connectionString = "";
        private SqlConnection objConn;
        private SqlTransaction objTran;

        public TransactionManagementDemo()
        {
            connectionString = "Data Source=192.168.50.95;Initial Catalog=ASHOK;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            objConn = new SqlConnection(connectionString);
        }
        public void Execute()
        {
            try
            {
                SqlCommand objCmdA = new SqlCommand("Update AccountFunds set Amount = Amount - 100 where AccountNumber = 'AccountA'", objConn, objTran);
                SqlCommand objCmdB = new SqlCommand("Update AccountFunds set Amount = Amount + 100 where AccountNumber = 'AccountB'", objConn, objTran);
                objConn.Open();
                objTran = objConn.BeginTransaction();
                objCmdA.ExecuteNonQuery();
                throw new Exception("Unexpected failed occurred");
                objCmdB.ExecuteNonQuery();
                objConn.Close();
                Console.WriteLine("Funds transferred successfully");
                objTran.Commit();
            }
            catch (Exception)
            {
                objTran.Rollback();
                Console.WriteLine("Error occurred while transferring funds");
            }
        }
    }
}
