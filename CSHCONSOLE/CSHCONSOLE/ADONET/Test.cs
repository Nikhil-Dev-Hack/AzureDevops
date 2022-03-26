using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSHCONSOLE.ADONET
{
    public class Test
    {
        public void Execute()
        {
            var deptName = "Dev";
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TollPlusLocal;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var objConn = new SqlConnection(connectionString);
            SqlCommand objcmd = new SqlCommand("select deptno, deptname, loc from  department where deptname like @DeptName", objConn);
            objcmd.Parameters.AddWithValue("@DeptName", '%' + deptName + '%');
            objConn.Open();
            SqlDataReader objDR = objcmd.ExecuteReader();
            while (objDR.Read())
            {
                Console.WriteLine(objDR["DeptNo"] + "\t" + objDR["DeptName"] + "\t" + objDR["Loc"]);
            }
            objConn.Close();
        }
    }
}
