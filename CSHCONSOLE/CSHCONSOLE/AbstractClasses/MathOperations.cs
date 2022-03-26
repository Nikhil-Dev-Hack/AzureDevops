using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.AbstractClasses
{
    public abstract class MathOperations
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }
        public int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }
        public abstract float Division(int num1, int num2);
    }
}
