using Invoicing.Core.Contracts;
using Restaurant.Invoicing.Domains;
using Restaurant.Invoicing.Domains.Contracts;
using Restaurant.Invoicing.Domains.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Core
{
    public class Check : ICheck
    {
        private readonly List<IProduct> _products;
        private ICategoryDiscount _categoryDiscount;
        private ICalculator _invoiceItemDiscountCalculator; //Since this is a dependency, we could potentially inject it.
        public Check()
        {
            _products = new List<IProduct>();
            _invoiceItemDiscountCalculator = new InvoiceItemDiscountCalculator();
        }

        #region ICheck Implementaion
        public void AddDiscount(ICategoryDiscount categoryDiscount)
        {
            if(categoryDiscount == null)
                throw new ArgumentNullException("categoryDiscount cannot be null.");

            _categoryDiscount = categoryDiscount;
        }

        public void AddItem(IProduct product)
        {
            if (product == null)
                throw new ArgumentNullException("Product cannot be null.");
            _products.Add(product);
        }

        public CheckData Calculate()
        {
            var result = new CheckData();
            //Do all discount calculation only when category discount is not null.
            //Applying discount to Check is optional.
            if (_categoryDiscount != null)
            {
                var invoiceProducts = new List<InvoiceProduct>();
                _products.ForEach(product =>
                {
                    if (IsValidForDiscount(product))
                    {
                        var calculationData = new CalculationData(product.Price, _categoryDiscount);
                        CalculateDiscountedPrice(calculationData);
                        invoiceProducts.Add(new InvoiceProduct(product.Name, Math.Round(product.Price,2), Math.Round(calculationData.OutputAmount,2), product.Category));
                    }
                    else
                    {
                        invoiceProducts.Add(new InvoiceProduct(product.Name, product.Price, product.Price, product.Category));
                    }
                    
                });
                result.Items = invoiceProducts;
            }
            else
            {
                result.Items = _products.Select(_ => new InvoiceProduct(_.Name, _.Price, _.Price, _.Category)).ToList();
            }
            return result;
        }

        internal bool IsValidForDiscount(IProduct product)
        {
            return (product.Category.Equals(_categoryDiscount.Category) &&
            _categoryDiscount.BeginDate < DateTime.UtcNow
            && (!_categoryDiscount.EndDate.HasValue || _categoryDiscount.EndDate.Value > DateTime.UtcNow));            
        }
        #endregion
        private void CalculateDiscountedPrice(CalculationData calculationData)
        {
            _invoiceItemDiscountCalculator.Calculate(calculationData);
        }
    }
}
