using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CSHCONSOLE.ADONET
{
    public class DataSetDemo
    {
        private string connectionString;
        private SqlConnection objConn;
        private DataSet objDS;
        private SqlDataAdapter dataAdapter;
        public DataSetDemo()
        {
            connectionString = "Data Source=192.168.50.95;Initial Catalog=ASHOK;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            objDS = new DataSet();
        }

        public void Execute()
        {
            dataAdapter = new SqlDataAdapter("SELECT DEPTNO, DeptName, Loc from Department", connectionString);
            dataAdapter.Fill(objDS, "MyDept");
            dataAdapter = new SqlDataAdapter("select EmpNo, EmpName, Salary, DeptNo from Employee", connectionString);
            dataAdapter.Fill(objDS, "MyEmp");
            var myDeptTable = objDS.Tables["MyDept"];
            /*
             TASK: Print MyDept, and MyEmp details on the console
             */
        }
    }
}
