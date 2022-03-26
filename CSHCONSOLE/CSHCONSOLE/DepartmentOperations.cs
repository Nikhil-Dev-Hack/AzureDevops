using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE
{
    public partial class Department
    {
        /// <summary>
        /// Adds department details
        /// </summary>
        public void Add(Department department)
        {
            Console.Write("Enter department number: ");
            department.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter department name:");
            department.Name = Console.ReadLine();
            Console.Write("Enter location: ");
            department.Location = Console.ReadLine();
        }

        public void Show(Department department)
        {
            Console.WriteLine($"Department detals:\nDept No: {department.Id}, Dept name: {department.Name}, Location: {department.Location}");
        }
    }
}
