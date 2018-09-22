using Restaurant.Invoicing.Domains.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Invoicing.Domains
{
    public class InvoiceTaxCalculator : ICalculator
    {
        public void Calculate(ICalculationData calculationData)
        {
            calculationData.OutputAmount = calculationData.InputAmount + (calculationData.InputAmount * calculationData.Markup.Value);
        }
    }
}
