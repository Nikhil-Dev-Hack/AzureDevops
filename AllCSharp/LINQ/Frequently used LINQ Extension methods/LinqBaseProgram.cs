using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LINQ
{
    public class LinqBaseProgram
    {
        public string _connStr = string.Empty;
        

        public IList<EmployeeDataModel> SQLMethod()
        {
            _connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            System.Data.DataTable table = new System.Data.DataTable();

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                var Sql = "  SELECT * FROM EmployeeData";


                using (SqlCommand cmd = new SqlCommand(Sql, connection))
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(table);        
                    }
                }
            }

            IList<EmployeeDataModel> Employees = new List<EmployeeDataModel>();

            foreach (DataRow row in table.Rows)
            {
                var Employee = new EmployeeDataModel()
                {
                    AutoID = int.Parse(row["AutoID"].ToString()),
                    DepartmentID = row["DepartmentID"].ToString(),
                    EmployeeID = row["EmployeeID"].ToString(),
                    EmployeeName = row["EmployeeName"].ToString(),
                };

                if (row["Email"] != DBNull.Value)
                {
                    Employee.Email = row["Email"].ToString();
                }
                if (row["MobileNumber"] != DBNull.Value)
                {
                    Employee.MobileNumber = int.Parse(row["MobileNumber"].ToString());
                }
                if (row["Salary"] != DBNull.Value)
                {
                    Employee.Salary = decimal.Parse(row["Salary"].ToString());
                }
               


                Employees.Add(Employee);
            }

            return Employees;
        }

    }
}
