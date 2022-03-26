using ADONETEntityFramework.SQL_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADONETEntityFramework.CRUID_Operations.ProductFolder
{
    public class ProductTableInsertion
    {
        public void InsertProductWayOne(string productName, decimal unitPrice, int unitStock, string catagoryName)
        {


            using (CompanyContext context = new CompanyContext())
            {
                Product product = new Product()
                {
                    ProductName = productName,
                    UnitPrice = unitPrice,
                    UnitsInStock = unitStock,
                    CatagoryName = catagoryName

                };

                context.Product.Add(product);
                context.SaveChanges();
            }
        }

        public void InsertProductWayTwo()
        {
            using (CompanyContext context = new CompanyContext())
            {
                Console.WriteLine("How many Products Do you want to enter");
                int User = int.Parse(Console.ReadLine());
                for (int i = 0; i < User; i++)
                {
                    var product = new Product();
                    try
                    {
                        Console.WriteLine("Enter The ProductName");
                        product.ProductName = Console.ReadLine();

                        Console.WriteLine("Enter The UnitPrice");
                        product.UnitPrice = decimal.Parse(Console.ReadLine());

                        Console.WriteLine("Enter  UnitsInStock");
                        product.UnitsInStock = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter CatagoryName ");
                        product.CatagoryName = Console.ReadLine();

                        context.Product.Add(product);
                        context.SaveChanges();

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Error Occured",ex.ToString());
                    }
                    
                }
            }
        }
    }
}
