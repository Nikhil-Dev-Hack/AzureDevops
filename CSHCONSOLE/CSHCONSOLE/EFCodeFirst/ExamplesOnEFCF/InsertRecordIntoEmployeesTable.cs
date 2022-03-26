using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.EFCodeFirst.ExamplesOnEFCF
{
    public class InsertRecordIntoEmployeesTable
    {
        public void Execute()
        {
            try
            {
                using (var context = new CompanyContext())
                {
                    var emp = new Employee();
                    Console.Write("Enter employee name: ");
                    emp.EmpName = Console.ReadLine();
                    Console.Write("Enter salary:");
                    emp.Salary = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Enter the department id:");
                    emp.DepartmentId = Convert.ToInt32(Console.ReadLine());
                    context.Employees.Add(emp);
                    context.SaveChanges();
                    Console.WriteLine("Employee record inserted successfully.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There was some problem while inserting record into Employees table");
            }
        }
    }
}
