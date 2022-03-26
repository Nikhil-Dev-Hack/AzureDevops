using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE
{
    public class DefaultValueDemo
    {
        public void Execute()
        {
            var dateTimeDefaultValue = default(DateTime);
            Console.WriteLine(dateTimeDefaultValue);
            var doubleDefaultValue = default(double);
            Console.WriteLine(doubleDefaultValue);
        }
    }
}
