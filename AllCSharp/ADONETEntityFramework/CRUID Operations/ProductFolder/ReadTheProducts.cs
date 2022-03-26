using System;
using System.Collections.Generic;
using System.Text;

namespace ADONETEntityFramework.CRUID_Operations.ProductFolder
{
    public class ReadTheProducts
    {
        public void Read()
        {
            using (CompanyContext context = new CompanyContext())
            {
                var products = context.Product;

                foreach (var item in products)
                {
                    Console.WriteLine(item.ProductName + "||" + item.UnitPrice + "||" + item.UnitsInStock + "||" + item.CatagoryName );
                }
            }
        }
    }
}
