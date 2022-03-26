using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ALLMVC.Models
{
    public class EmpDep
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
    }
}
