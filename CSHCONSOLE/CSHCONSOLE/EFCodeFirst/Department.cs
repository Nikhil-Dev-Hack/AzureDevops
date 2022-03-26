using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.EFCodeFirst
{
    public class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public string Loc { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
