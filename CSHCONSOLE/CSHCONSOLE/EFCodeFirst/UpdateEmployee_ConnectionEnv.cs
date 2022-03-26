using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.EFCodeFirst
{
    public class UpdateEmployee_ConnectionEnv
    {
        public bool UpdateEmployee(int employeeId, string empName, decimal salary)
        {
            try
            {
                using (var context = new CompanyContext())
                {
                    var emp = context.Employees.Find(employeeId);
                    emp.EmpName = empName;
                    emp.Salary = salary;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error occurred. Here is the message\n{ex.Message}");
                return false;
            }
        }

        public void Execute()
        {
            Console.WriteLine("Please enter Employee id, name, salary to update details:");
            var empId = Convert.ToInt32(Console.ReadLine());
            var name = Console.ReadLine();
            var salary = Convert.ToDecimal(Console.ReadLine());
            var updateStatus = UpdateEmployee(empId, name, salary);
            if(updateStatus)
            {
                Console.WriteLine("Employee details updated successfully");
            }
            else
            {
                Console.WriteLine("There's some problem while trying to update employee details");
            }
        }
    }
}
