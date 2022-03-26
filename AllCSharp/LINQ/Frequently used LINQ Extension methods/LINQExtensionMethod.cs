using System;
using System.Linq;

namespace LINQ
{
    public class LINQExtensionMethod : LinqBaseProgram
    {
        public void ExtensionsMethods()
        {
            var employees = SQLMethod();

            var employ = SQLMethod();

            #region StartsWith
            //var data1 = employees.Where(d => d.EmployeeName.StartsWith("VAMSHI"));
            #endregion

            #region Average
            //var data = employees.Average(d => d.Salary);
            //Console.WriteLine(data);
            #endregion

            #region Contains
            //var data = from employee in employees
            // where employee.EmployeeName.Contains("NIKHIL")
            // select employee;

            #endregion

            #region Concat
            //var QueryCon = employees.Concat(employ);
            #endregion

            #region Distinct
            //var data = QueryCon.Distinct();
            #endregion

            #region ElementAt
            //var Element = employees.ElementAt(0);
            //Console.WriteLine(Element.EmployeeName);
            #endregion

            #region ElementAtOrDefault
            //var EleDef = employ.ElementAtOrDefault(6);
            //Console.WriteLine(EleDef.EmployeeName);
            #endregion

            #region Except
            //var data3 = data1.Except(data);
            #endregion

            #region First
            //var first = employees.First();
            //Console.WriteLine(first.DepartmentID + "||" + first.EmployeeID);
            #endregion

            #region FirstOrDefault
            //var FirstOrDefaul = employ.FirstOrDefault();
            //Console.WriteLine(first.DepartmentID + "||" + first.EmployeeID);
            #endregion


            #region GroupBy
            //var group = employees.GroupBy(s => s.EmployeeID);
            //foreach (var item in group)
            //{
            //    Console.WriteLine(item.Count() + "|" + item.Key);
            //}
            #endregion

            #region Intersect
            //var intersect = employ.Intersect(employees);
            //foreach (var item in intersect)
            //{
            //    Console.WriteLine(item.EmployeeName);
            //}
            #endregion

            #region Last
            //var last = employ.Last();
            //Console.WriteLine(last.EmployeeName);
            #endregion

            #region LastOrDefault
            //var last = employ.LastOrDefault();
            //Console.WriteLine(last.Email);
            #endregion

            #region Count 
            //var kolCount = employ.Count(s => s.EmployeeName == "VAMSHI");
            //Console.WriteLine(kolCount);
            #endregion

            #region Max
            //var max = employ.Max(s => s.EmployeeID);
            //Console.WriteLine(max);
            #endregion

            #region Min
            //var min = employ.Min(s => s.EmployeeID);
            //Console.WriteLine(min);
            #endregion

            #region OrderBy
            //var order = employ.OrderBy(sample => sample.EmployeeName);
            //foreach (var item in order)
            //{
            //    Console.WriteLine(item.EmployeeName);
            //}
            #endregion

            #region OrderByDescending
            //var order = employ.OrderByDescending(sample => sample.EmployeeName);
            //foreach (var item in order)
            //{
            //    Console.WriteLine(item.EmployeeName);
            //}
            #endregion

            #region ThenBy
            //var then = employ.OrderBy(smaple => smaple.EmployeeName).ThenBy(s => s.EmployeeID);
            //foreach (var item in then)
            //{
            //    Console.WriteLine(item.DepartmentID+item.EmployeeName);
            //}
            #endregion

            #region Reverse
            //var reverse = employ.Reverse();
            //foreach (var item in reverse)
            //{
            //    Console.WriteLine(item.DepartmentID + item.EmployeeName);
            //}
            #endregion

            #region SequenceEqual
            //var Sequence = employ.SequenceEqual(reverse);
            //Console.WriteLine(Sequence);
            #endregion

            #region Skip
            //var skip = employ.Skip(2);
            //foreach (var item in skip)
            //{
            //    Console.WriteLine(item.DepartmentID + item.EmployeeName);
            //}
            #endregion
        }
    }
}
