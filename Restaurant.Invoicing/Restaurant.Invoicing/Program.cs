using Invoicing.Core;
using Restaurant.Invoicing.Domains;
using Restaurant.Invoicing.Domains.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Invoicing
{
    class Program
    {
        static void Main(string[] args)
        {
            var check = new Check();
            check.AddItem(new Product("BLT", 9.99d, Domains.ValueObject.ProductCategory.Sandwich));
            check.AddItem(new Product("Burger", 8.99d, Domains.ValueObject.ProductCategory.Sandwich));
            check.AddItem(new Product("Coke - Large", 2.79d, Domains.ValueObject.ProductCategory.Drink));
            check.AddItem(new Product("Coke - Medium", 2.39d, Domains.ValueObject.ProductCategory.Drink));
            check.AddItem(new Product("Cookie", 1.99d, Domains.ValueObject.ProductCategory.Dessert));
            check.AddDiscount(new ProductCategoryDiscount("Labor Day Special", Domains.ValueObject.ProductCategory.Drink, false, new DateTime(2018, 09, 03),
                new DateTime(2018, 11, 30), 0.1d, MarkupType.Percent));
            var result = check.Calculate();
            Console.WriteLine($"SubTotal:{result.SubTotal}");
            foreach(var item in result.Items)
            {
                Console.WriteLine($"Product Name:{item.Name} Actual Price:{item.ActualPrice} Price after Discount:{item.DiscountedPrice}");
            }
            Console.WriteLine($"Total Savings:{result.TotalSavings}");
            Console.ReadLine();

        }
    }
}
