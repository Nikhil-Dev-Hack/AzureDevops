using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE
{
    /// <summary>
    /// Pass by value example: WAP to add two numbers uring one method.
    /// </summary>
    public class PassByValueExample
    {
        public void Execute()
        {
            int a = 10, b = 20;
            var result = Sum(a, b);
            Console.WriteLine(result);
        }

        private int Sum(int a, int b)
        {
            return a + b;
        }
    }
}
