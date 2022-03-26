using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSHCONSOLE
{
    public class ArrayListDemo
    {
        public void Execute()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add("String");
            arrayList.Add(10);
            DateTime d = new DateTime(2020, 11, 6);
            arrayList.Add(d);
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
