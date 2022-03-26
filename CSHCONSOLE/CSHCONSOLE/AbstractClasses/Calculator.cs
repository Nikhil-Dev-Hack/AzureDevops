using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.AbstractClasses
{
    public class Calculator : MathOperations
    {
        public override float Division(int num1, int num2)
        {
            return (float)num1 / num2;
        }

        public int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
