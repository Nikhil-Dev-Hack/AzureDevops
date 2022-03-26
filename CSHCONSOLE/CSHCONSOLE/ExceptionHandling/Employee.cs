using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.ExceptionHandling
{
    public class Employee
    {
        private int empNo;
        private string firstName;
        public int EmpNo
        {
            get
            {
                return empNo;
            }
            set
            {
                empNo = value;
                if(empNo < 1001)
                {
                    throw new Exception("Employee number should be more than 1001");
                }
            }
        }

        public string FirstName { get; set; }
    }
}
