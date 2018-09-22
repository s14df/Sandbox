using Invoicing.Core;
using Invoicing.Core.Contracts;
using Restaurant.Invoicing.Domains.Contracts;
using System;
using Restaurant.Invoicing.Domains;
using Xunit;
using Restaurant.Invoicing.Domains.ValueObject;

namespace Restaurant.Invoicing.Tests.Invoicing.Core
{
    public class CheckTests
    {
		[Fact]
		public void When_Adding_Null_Product_To_Check_Throws_Exception()
        {
            ICheck check = new Check();
            Assert.Throws<ArgumentNullException>( ()=> check.AddItem(default(IProduct)));
        }

		[Fact]
		public void When_Adding_Null_CategoryDiscount_To_Check_Throws_Exception()
        {
            ICheck check = new Check();
            Assert.Throws<ArgumentNullException>(() => check.AddDiscount(default(ICategoryDiscount)));
        }

		[Fact]
		public void When_Category_Is_Invalid_Product_Is_Not_Eligible_For_Discount()
        {
            var check = new Check();
            check.AddDiscount(new ProductCategoryDiscount("Dessert Discount", ProductCategory.Dessert, false, DateTime.UtcNow.AddDays(-10), null, 0.1f, MarkupType.Percent));
            var isValid = check.IsValidForDiscount(new Product("Sandwich", 10f, ProductCategory.Sandwich));
            Assert.False(isValid);
        }

        [Fact]
        public void When_Dates_Are_Expired_Product_Is_InEligible_For_Discount()
        {
            var check = new Check();
            check.AddDiscount(new ProductCategoryDiscount("Sandwich Discount", ProductCategory.Sandwich, false, DateTime.UtcNow.AddDays(-10), DateTime.UtcNow.AddDays(-8), 0.1f, MarkupType.Percent));
            var isValid = check.IsValidForDiscount(new Product("Sandwich", 10f, ProductCategory.Sandwich));
            Assert.False(isValid);
        }

        [Fact]
        public void When_Category_Is_Valid_Product_Is_Eligible_For_Discount()
        {
            var check = new Check();
            check.AddDiscount(new ProductCategoryDiscount("Sandwich Discount", ProductCategory.Sandwich, false, DateTime.UtcNow.AddDays(-10), null, 0.1f, MarkupType.Percent));
            var isValid = check.IsValidForDiscount(new Product("Sandwich", 10f, ProductCategory.Sandwich));
            Assert.True(isValid);
        }
    }
}
