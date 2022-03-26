using CSHCONSOLE.AbstractClasses;
using CSHCONSOLE.ADONET;
using CSHCONSOLE.EFCodeFirst;
using CSHCONSOLE.EFCodeFirst.ExamplesOnEFCF;
using CSHCONSOLE.ExceptionHandling;
using CSHCONSOLE.Generics;
using CSHCONSOLE.ParallelProgramming;
using CSHCONSOLE.TaskProgramming;
using System;
using System.Collections.Generic;

namespace CSHCONSOLE
{
    class Program
    {
        static void Main(string[] args)
        {
            //PassByValueExample obj = new PassByValueExample();
            //obj.Execute();
            //PassByReferenceExample obj = new PassByReferenceExample();
            //obj.Execute();
            //ArraysExample1.Execute();
            //ArraysExample2 obj = new ArraysExample2();
            //obj.Execute();
            //DefaultValueDemo obj = new DefaultValueDemo();
            //obj.Execute();
            //ClassExample example = new ClassExample();
            //example.Execute();
            //Department department = new Department();
            //Department obj = new Department();
            //department.Add(obj);
            //department.Show(obj);
            //Calculator calculator = new Calculator();
            //int addResult = calculator.Add(10, 20);
            //int multiplicationResult = calculator.Multiply(20, 20);
            //int subtractionResult = calculator.Subtract(20, 10);
            //float divisionResult = calculator.Division(5, 2);
            //Console.WriteLine($"Calculator results: {addResult}, {multiplicationResult}, {subtractionResult}, {divisionResult}");
            //ArrayListDemo obj = new ArrayListDemo();
            //obj.Execute();
            //new TaskExample01().Execute();
            //new TaskExample02().Execute();
            //new TaskExample03().Execute();
            //new TaskExample04().Execute();
            //new ExceptionHandling01().Execute();
            //new Test().Execute();
            //new HashTableExample().Run();
            //new ListExample().Execute();
            //DepartmentDataManipulation obj = new DepartmentDataManipulation();
            //obj.Add();
            //obj.ShowAllDepartments();
            //new EmployeeDatabase().ShowAllEmployees();
            //new ConnectToSQLServer().Execute();
            //new InsertRecordUsingSQLQuery().Execute();
            //new InsertDEPTRecordUsingSP().Execute();
            //new ReadDeptDetailsTest().Execute();
            //new DataSetDemo().Execute();
            //new ReadDeptDetailsTest().Execute();
            //new TransactionManagementDemo().Execute();
            //new InsertRecordIntoDepartmentsTable().Execute();
            //new InsertRecordIntoEmployeesTable().Execute();
            //new ViewAllEmployees().Execute();
            //new UpdateEmployee_ConnectionEnv().Execute();
            new UpdateEmployee_ConnectionlessEnv().Execute();
            Console.ReadKey();
        }
    }
}
