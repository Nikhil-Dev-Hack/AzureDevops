using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.Generics
{
    public class DepartmentDataManipulation
    {
        private List<Department> departments;
        public void Add()
        {
            departments = new List<Department>();
            Department sdDept = new Department
            {
                DeptNo = 1001,
                DeptName = "Software Development",
                Location = "Hyderabad"
            };
            Department researchDept = new Department
            {
                DeptNo = 1002,
                DeptName = "Research",
                Location = "Bangalore"
            };
            departments.Add(sdDept);
            departments.Add(researchDept);
        }
        public void ShowAllDepartments()
        {
            Console.WriteLine("Below are available departments");
            foreach (var department in departments)
            {
                Console.WriteLine($"ID: {department.DeptNo}\t Name: {department.DeptName}\tLocation: {department.Location}");
            }
        }
    }
}
