using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSHCONSOLE.ADONET
{
    public class ReadDeptDetails
    {
        private string connectionString;
        private SqlConnection objConn;
        public ReadDeptDetails()
        {
            connectionString = "Data Source=192.168.50.95;Initial Catalog=ASHOK;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            objConn = new SqlConnection(connectionString);
        }
        public void ReadAll()
        {
            objConn.Open();
            SqlCommand objCmd = new SqlCommand("SELECT DeptNo, DeptName, Loc FROM Department", objConn);
            SqlDataReader objDR = objCmd.ExecuteReader();
            while(objDR.Read())
            {
                Console.WriteLine(objDR["DeptNo"] + "\t" + objDR["DeptName"] + "\t" + objDR["Loc"]);
            }
            objConn.Close();
        }

        public void ReadDeptById(int deptId)
        {
            SqlCommand objCmd = new SqlCommand("SELECT DeptNo, DeptName, Loc FROM Department WHERE DeptNo = @DeptNo", objConn);
            objCmd.Parameters.AddWithValue("@DeptNo", deptId);
            objConn.Open();
            SqlDataReader objDR = objCmd.ExecuteReader();
            if(objDR.Read())
            {
                Console.WriteLine($"Department number: {objDR["DeptNo"]}");
                Console.WriteLine($"Department name: {objDR["DeptName"]}");
                Console.WriteLine($"Location: {objDR["Loc"]}");
            }
            objConn.Close();
        }

        public void FilterDeptsByName(string deptName)
        {
            objConn.Open();
            SqlCommand objcmd = new SqlCommand("select deptno, deptname, loc from  department where deptname like @DeptName", objConn);
            objcmd.Parameters.AddWithValue("@DeptName", '%' + deptName + '%');
            SqlDataReader objDR = objcmd.ExecuteReader();
            while (objDR.Read())
            {
                Console.WriteLine(objDR["DeptNo"] + "\t" + objDR["DeptName"] + "\t" + objDR["Loc"]);
            }
            objConn.Close();
        }

        public string GetDeptNameById(int deptId)
        {
            objConn.Open();
            SqlCommand objCmd = new SqlCommand("SELECT DeptName from department where Deptno = @DeptNo", objConn);
            objCmd.Parameters.AddWithValue("@DeptNo", deptId);
            var deptName = objCmd.ExecuteScalar();
            objConn.Close();
            return Convert.ToString(deptName);
        }
    }
}
