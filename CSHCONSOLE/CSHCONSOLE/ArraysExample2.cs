using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE
{
    public class ArraysExample2
    {
        public void Execute()
        {
            int[] array = new int[10];
            Console.Write($"Read {array.Length} elements into array: ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"below are {array.Length} elements in Array");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }
    }
}
