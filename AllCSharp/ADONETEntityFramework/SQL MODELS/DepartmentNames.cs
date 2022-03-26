using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ADONETEntityFramework.SQL_MODELS
{
    public class DepartmentNames
    {
       
        public string DepartmentName { get; set; }

        [Key]
        public string DepartmentID { get; set; }
    }
}
