using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADONETEntityFramework.CRUID_Operations.ProductFolder
{
    public class ProductUpdate
    {
        public void Update()
        {
            using (CompanyContext context = new CompanyContext())
            {
                var product = context.Product.Where(pro => pro.ProductID == 4).FirstOrDefault();

                if (product != null)
                {
                    Console.WriteLine("Enter the UnitsInStock updated number");
                    int Stock = int.Parse(Console.ReadLine());

                    product.UnitsInStock = Stock;
                    context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
	
    }
}
