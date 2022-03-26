using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSHCONSOLE
{
    public class Test
    {
        public void Execute()
        {
            Random rnd = new Random();
            var someNumber = rnd.Next(1000, 2000);
            Console.WriteLine($"Generated random number was: {someNumber}");
        }
    }
}
