using Restaurant.Invoicing.Domains.Contracts;
using Restaurant.Invoicing.Domains.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Invoicing.Domains
{
    public class Product : IProduct
    {

        public Product(string name, double price, ProductCategory category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
        public string Name { get; private set; }
        public double Price { get; private set; }

        public ProductCategory Category { get; private set; }


        #region Domain Behavior
        public void ChangeProductName (string productName)
        {
            this.Name = productName;
        }

        public void ChangePrice(double price)
        {
            //Price check and should be greater than 0
            this.Price = price;
        }

        #endregion
    }
}
