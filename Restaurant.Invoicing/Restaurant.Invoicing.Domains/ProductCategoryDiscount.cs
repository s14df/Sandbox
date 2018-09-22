using Restaurant.Invoicing.Domains.Contracts;
using Restaurant.Invoicing.Domains.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Invoicing.Domains
{
    public class ProductCategoryDiscount : ICategoryDiscount
    {
        public ProductCategoryDiscount(string name, ProductCategory category, bool shouldApplyToAll, DateTime beginDate, DateTime? endDate, double markupValue, MarkupType markupType)
        {
            Name = name;
            Category = category;
            ShouldApplyToAll = shouldApplyToAll;
            BeginDate = beginDate;
            EndDate = endDate;
            Value = markupValue;
            MarkupType = markupType;
        }
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
        public bool ShouldApplyToAll { get; set; }

        public DateTime BeginDate { get; }

        public DateTime? EndDate { get ; set ; }
        public double Value { get; set; }
        public MarkupType MarkupType { get; set; }
    }
}
