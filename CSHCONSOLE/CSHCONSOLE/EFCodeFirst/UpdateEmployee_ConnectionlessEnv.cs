using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.EFCodeFirst
{
    public class UpdateEmployee_ConnectionlessEnv
    {
        public bool UpdateEmployee(int employeeId, string empName, decimal salary)
        {
            try
            {
                using (var context = new CompanyContext())
                {
                    var emp = context.Employees.Find(employeeId);
                    context.Entry<Employee>(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Console.WriteLine("Enter employee details Empno, ename, salary to update:");
            var empNo = Convert.ToInt32(Console.ReadLine());
            var empName = Console.ReadLine();
            var salary = Convert.ToDecimal(Console.ReadLine());
            var updateStatus = UpdateEmployee(empNo, empName, salary);
            if(updateStatus)
            {
                Console.WriteLine("Employee details updated successfully.");
            }
            else
            {
                Console.WriteLine("Some error occurred while trying to update employee details");
            }
        }
    }
}
