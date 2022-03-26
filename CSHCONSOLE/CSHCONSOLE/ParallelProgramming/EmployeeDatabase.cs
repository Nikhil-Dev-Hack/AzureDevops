using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CSHCONSOLE.ParallelProgramming
{
    public class EmployeeDatabase
    {
        public List<Employee> GetAllEmployees()
        {
            #region Initializing List<Employee> with some records
            //var employees = new List<Employee>()
            //{
            //    new Employee
            //    {
            //        EmpId = 1001,
            //        EmpName = "Chalapathi",
            //        Salary = 100000
            //    },
            //    new Employee
            //    {
            //        EmpId = 1002,
            //        EmpName = "Ramesh",
            //        Salary = 90000
            //    }
            //};
            #endregion Initializing List<Employee> with some records
            var employees = new List<Employee>();
            Random rnd = new Random();
            for (int i = 1; i <= 100000; i++)
            {
                //Create employee record for each iteration
                var randomNumber = rnd.Next(1000, 10_000);
                var emp = new Employee
                {
                    EmpId = randomNumber,
                    EmpName = $"Employee {randomNumber}",
                    Salary = 1_00_000
                };
                employees.Add(emp);
            }
            return employees;
        }

        public void ShowAllEmployees()
        {
            var employees = GetAllEmployees();
            Console.WriteLine("Printing all employee details using foreach loop");
            var timer = new Stopwatch();
            timer.Start();
            foreach (var emp in employees)
            {
                Console.WriteLine($"Emp id: {emp.EmpId}\tEmp name: {emp.EmpName}\tSalary: {emp.Salary}");
            }
            timer.Stop();
            Console.WriteLine($"simple foreach loop took {timer.ElapsedMilliseconds} milliseconds");
            Console.WriteLine("Printing all employee details using for loop");
            for (int i = 0; i < employees.Count; i++)
            {
                var emp = employees[i];
                Console.WriteLine($"Emp id: {emp.EmpId}\tEmp name: {emp.EmpName}\tSalary: {emp.Salary}");
            }
            Console.WriteLine("Printing all employee details using Parallel.ForEach loop");
            timer.Reset();
            timer.Start();
            Parallel.ForEach(employees, (emp) => {
                Console.WriteLine($"Emp id: {emp.EmpId}\tEmp name: {emp.EmpName}\tSalary: {emp.Salary}");
            });
            timer.Stop();
            Console.WriteLine($"Parallel.ForEach took {timer.ElapsedMilliseconds} milliseconds");
            Console.WriteLine("Print all employee details using Parallel.For loop");
            Parallel.For(0, employees.Count, (indexCount) =>
            {
                var emp = employees[indexCount];
                Console.WriteLine($"Emp id: {emp.EmpId}\tEmp name: {emp.EmpName}\tSalary: {emp.Salary}");
            });
        }
    }
}
