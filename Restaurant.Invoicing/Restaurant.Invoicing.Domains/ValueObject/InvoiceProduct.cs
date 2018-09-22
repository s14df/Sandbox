using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Invoicing.Domains.ValueObject
{
    public class InvoiceProduct :IEquatable<InvoiceProduct>
    {
        public InvoiceProduct (string name, double actualPrice, double discountedPrice, ProductCategory category)
        {
            Name = name;
            ActualPrice = actualPrice;
            Category = category;
            DiscountedPrice = discountedPrice;
        }
        public string Name { get; private set; }
        public double ActualPrice { get; private set; }
        public double DiscountedPrice { get; private set; }

        public ProductCategory Category { get; private set; }

        public bool Equals(InvoiceProduct other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Name.Equals(Name) && other.ActualPrice.Equals(ActualPrice) && other.DiscountedPrice.Equals(DiscountedPrice) && other.Category.Equals(Category);
        }
    }
}
