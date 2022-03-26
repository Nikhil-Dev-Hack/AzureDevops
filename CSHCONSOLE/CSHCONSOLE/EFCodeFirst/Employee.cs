using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.EFCodeFirst
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
