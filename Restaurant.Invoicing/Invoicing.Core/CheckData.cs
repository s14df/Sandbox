using Restaurant.Invoicing.Domains.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Core
{
    public class CheckData
    {
        public IEnumerable<InvoiceProduct> Items { get; set; }
        public double SubTotal => Items != null ? Math.Round(Items.Sum(x => x.DiscountedPrice),2) : 0d;

        public double Tax { get;  }
        public double Total => Math.Round(SubTotal + Tax,2);

        public double TotalSavings => Math.Round(Items.Sum(x => x.ActualPrice - x.DiscountedPrice),2);
    }
}
