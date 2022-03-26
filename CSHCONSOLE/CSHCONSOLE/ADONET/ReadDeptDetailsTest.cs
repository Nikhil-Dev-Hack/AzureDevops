using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.ADONET
{
    public class ReadDeptDetailsTest
    {
        public void Execute()
        {
            //new ReadDeptDetails().ReadAll();
            //Console.Write("Enter department number to read details:");
            //var deptNo = Convert.ToInt32(Console.ReadLine());
            //new ReadDeptDetails().ReadDeptById(deptNo);
            Console.Write("Enter search criteria to filter Department records: ");
            var deptName = Console.ReadLine();
            new ReadDeptDetails().FilterDeptsByName(deptName);
            //Console.Write("Enter department number to fetch dept name: ");
            //deptNo = Convert.ToInt32(Console.ReadLine());
            //deptName = new ReadDeptDetails().GetDeptNameById(deptNo);
            //Console.WriteLine($"Department name: {deptName}");
        }
    }
}
