using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ADONETEntityFramework.SQL_MODELS
{
    public class EmployeeData
    {
        

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoID { get; set; }

        public string DepartmentID { get; set; }

        [Key]
        public string EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public string Email { get; set; }

        public int? MobileNumber { get; set; }

        public decimal Salary { get; set; }
    }
}
