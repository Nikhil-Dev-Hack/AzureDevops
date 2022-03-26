using System;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE
{
    class PropertiesExample
    {
        int age;
        public int Age
        {
            set
            {
                age = value;
                if (age < 18)
                    throw new Exception("You are not allowed to watch this movie");
            }
            get
            {
                return age;
            }
        }

        public void Execute()
        {
            Console.Write("Enter age: ");
            Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Age);
        }
    }
}
