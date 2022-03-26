using CSHCONSOLE.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE.Services.Implementations
{
    public class Calculator : ICalculator
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public double Divide(int num1, int num2)
        {
            return num1 / num2;
        }

        public int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        public int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
