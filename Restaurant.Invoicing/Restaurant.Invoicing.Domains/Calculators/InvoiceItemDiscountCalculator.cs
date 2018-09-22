using Restaurant.Invoicing.Domains.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Invoicing.Domains
{
    public class InvoiceItemDiscountCalculator : ICalculator
    {
        public void Calculate(ICalculationData calculationData)
        {
            if (calculationData == null)
                throw new ArgumentNullException("Calculation data cannot be null.");

            if (calculationData.InputAmount == 0)
                return;

            if (calculationData.Markup.MarkupType == MarkupType.Percent)
            {
                calculationData.OutputAmount = calculationData.InputAmount - (calculationData.InputAmount * calculationData.Markup.Value);
            }
            else if (calculationData.Markup.MarkupType == MarkupType.Absolute)
            {
                calculationData.OutputAmount = calculationData.InputAmount - calculationData.Markup.Value;
            }
        }
    }
}
