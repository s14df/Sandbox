using Restaurant.Invoicing.Domains;
using Restaurant.Invoicing.Domains.Contracts;
using Restaurant.Invoicing.Domains.ValueObject;
using System;
using Xunit;
namespace Restaurant.Invoicing.Tests.Domains.Calculators
{
    public class InvoiceItemDiscountCalculatorTests
    {
        [Fact]
        public void When_Calculation_Data_Is_Null_Throws_Exception()
        {
            InvoiceItemDiscountCalculator calculator = new InvoiceItemDiscountCalculator();
            Assert.Throws<ArgumentNullException>(()=> calculator.Calculate(default(ICalculationData)));
        }
        [Fact]
        public void Calculate_Markup_When_Markup_Type_Is_Percent_Successfully()
        {
            InvoiceItemDiscountCalculator calculator = new InvoiceItemDiscountCalculator();
            var calculationData = new CalculationData(10, new MarkupDataStub { MarkupType = MarkupType.Percent, Value = 0.1d });
            calculator.Calculate(calculationData);
            Assert.Equal(9d, calculationData.OutputAmount);
        }

        [Fact]
        public void Calculate_Markup_When_Markup_Type_Is_Absolute_Successfully()
        {
            InvoiceItemDiscountCalculator calculator = new InvoiceItemDiscountCalculator();
            var calculationData = new CalculationData(10, new MarkupDataStub { MarkupType = MarkupType.Absolute, Value = 2d });
            calculator.Calculate(calculationData);
            Assert.Equal(8f, calculationData.OutputAmount);
        }

    }

    public class MarkupDataStub : IMarkup
    {
        public double Value { get; set ; }
        public MarkupType MarkupType { get; set; }
    }
}
