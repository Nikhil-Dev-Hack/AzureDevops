using CSHCONSOLE.Services.Abstract;
using CSHCONSOLE.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE
{
    public static class CalculatorClient
    {
        static ICalculator calculator;

        static CalculatorClient()
        {
            calculator = new Calculator();
        }

        public static int Add(int num1, int num2)
        {
            return calculator.Add(num1, num2);
        }

        public static int Subtract(int num1, int num2)
        {
            return calculator.Subtract(num1, num2);
        }

        public static int Multiply(int num1, int num2)
        {
            return calculator.Multiply(num1, num2);
        }

        public static double Divide(int num1, int num2)
        {
            return calculator.Divide(num1, num2);
        }
    }
}
