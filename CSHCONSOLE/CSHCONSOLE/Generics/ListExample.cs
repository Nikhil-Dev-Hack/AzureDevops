using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.Generics
{
    public class ListExample
    {
        public void Execute()
        {
            List<int> integers = new List<int>();
            //integers.Add(10);
            //integers.Add(20);
            //integers.Add(30);
            //foreach (var item in integers)
            //{
            //    Console.WriteLine(item);
            //}
            while (true)
            {
                Console.Write("Add element into list (0 to stop):");
                int someValue = Convert.ToInt32(Console.ReadLine());
                if (someValue == 0)
                    break;
                integers.Add(someValue);
            }
            foreach (var item in integers)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
