using Restaurant.Invoicing.Domains.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Invoicing.Domains.ValueObject
{
    public class CalculationData : ICalculationData
    {
        public CalculationData(double input, IMarkup markupData)
        {
            InputAmount = input;
            Markup = markupData;
        }
        public double InputAmount { get ; }
        public double OutputAmount { get; set; }
        public IMarkup Markup { get; }
    }
}
