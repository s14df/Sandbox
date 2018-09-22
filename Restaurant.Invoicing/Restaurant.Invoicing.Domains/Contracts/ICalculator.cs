using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Invoicing.Domains.Contracts
{
    public interface ICalculator
    {
        void Calculate(ICalculationData calculationData);
    }
}
