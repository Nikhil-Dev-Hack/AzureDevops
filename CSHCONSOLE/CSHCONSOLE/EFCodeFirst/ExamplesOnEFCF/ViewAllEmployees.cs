using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.EFCodeFirst.ExamplesOnEFCF
{
    public class ViewAllEmployees
    {
        public void Execute()
        {
            using (var context = new CompanyContext())
            {
                var employees = context.Employees;
                foreach (var emp in employees)
                {
                    Console.WriteLine(emp.EmployeeId + "\t" + emp.EmpName + "\t" + emp.Salary);
                }
            }
        }
    }
}
