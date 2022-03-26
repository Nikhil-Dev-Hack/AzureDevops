using System;
using System.Linq;

namespace ADONETEntityFramework.CRUID_Operations.ProductFolder
{
    public class DeleteInfoFromProducts
    {
        public void Delete()
        {
            using (CompanyContext context = new CompanyContext())
            {
                Console.WriteLine("Enter the ProductId");
                int productID = int.Parse(Console.ReadLine());

                var products = context.Product.Where(Id => Id.ProductID == productID).FirstOrDefault();

                if (products != null)
                {
                    context.Product.Remove(products);
                    context.SaveChanges();
                }
            }
        }

    }
}
