using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.EFCodeFirst.ExamplesOnEFCF
{
    public class InsertRecordIntoDepartmentsTable
    {
        public void Execute()
        {
            try
            {
                using (var context = new CompanyContext())
                {
                    var dept = new Department
                    {
                        DeptName = "Accounting",
                        Loc = "New York"
                    };
                    context.Departments.Add(dept);
                    context.SaveChanges();
                    Console.WriteLine("Record inserted successfully");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Some unexpected error occurred while trying to insert the record");
            }
        }
    }
}
