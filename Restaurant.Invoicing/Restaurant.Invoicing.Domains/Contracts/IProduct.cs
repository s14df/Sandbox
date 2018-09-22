using Restaurant.Invoicing.Domains.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Invoicing.Domains.Contracts
{
    public interface IProduct
    {
        string Name { get; }
        double Price { get; }
        ProductCategory Category { get; }

        
    }
}
