using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE
{
    /// <summary>
    /// WAP to swap two numbers and print the result
    /// </summary>
    public class PassByReferenceExample
    {
        public void Execute()
        {
            int a = 10, b = 20;
            Swap(ref a, ref b);
            Console.WriteLine($"After Swap function executed, a={a}, b={b}");
        }

        private void Swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
            //Console.WriteLine(a);
            //Console.WriteLine(b);
        }
    }
}
