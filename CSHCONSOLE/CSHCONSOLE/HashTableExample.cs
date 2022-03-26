using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE
{
    public class HashTableExample
    {
        public void Run()
        {
            Hashtable hashtable = new Hashtable();
            for (int i = 1; i <= 10; i++)
            {
                hashtable.Add(i, "T+" + i);
            }
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
            Console.ReadKey();
        }
    }
}
