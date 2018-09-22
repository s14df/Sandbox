using Restaurant.Invoicing.Domains.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Invoicing.Domains.Contracts
{
    public interface ICategoryDiscount: IMarkup
    {
        ProductCategory Category { get; set; }
        bool ShouldApplyToAll { get; set; }
        DateTime BeginDate { get; }
        DateTime? EndDate { get; set;    }
    }
}
