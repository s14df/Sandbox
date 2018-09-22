using Restaurant.Invoicing.Domains.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Core.Contracts
{
    public interface ICheck
    {
        void AddItem(IProduct product);
        void AddDiscount(ICategoryDiscount categoryDiscount);

        CheckData Calculate();
    }
}
