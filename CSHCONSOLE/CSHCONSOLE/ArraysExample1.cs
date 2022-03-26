using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE
{
    public class ArraysExample1
    {
        public static void Execute()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            PrintArray(array);
        }

        private static void PrintArray(int[] arrayParam)
        {
            foreach (var item in arrayParam)
            {
                Console.WriteLine(item);
            }
        }
    }
}
