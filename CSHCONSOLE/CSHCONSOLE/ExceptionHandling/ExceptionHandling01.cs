using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.ExceptionHandling
{
    public class ExceptionHandling01
    {
        public void Execute()
        {
            try
            {
                Employee employee = new Employee();
                Console.WriteLine("Enter employee number:");
                employee.EmpNo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter employee name:");
                employee.FirstName = Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
        }
    }
}
