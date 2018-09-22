using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Invoicing.Domains.Contracts
{
    public interface IMarkup
    {
        double Value { get; set; }
        MarkupType MarkupType { get; set; }
    }

    public enum MarkupType
    {
        Percent, Absolute
    }
}
