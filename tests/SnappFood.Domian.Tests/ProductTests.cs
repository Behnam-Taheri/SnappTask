using FluentAssertions;
using SnappFood.Domain.Orders;
using SnappFood.Domain.Products;
using SnappFood.Domain.Products.Arguments;
using SnappFood.Domain.Products.Contracts;
using SnappFood.Domain.Products.Exceptions;

namespace SnappFood.Domian.Tests
{
    public class ProductTests : IProductTitleDuplicateChecker
    {
        private bool isExist = false;
        private CreateProductArgument argument;

        public ProductTests()
        {
            argument = new CreateProductArgument()
            {
                Price = 10000,
                Discount = 20,
                InventoryCount = 2,
                Title = "Pizza"
            };
        }

        [Fact]
        public void Create_Long_Title_Test_Should_Be_ThrowsException()
        {
            argument.Title = new String('B', 41);
            var ex = Assert.Throws<LongTitleException>(() => _ = new Product(argument, this));
            Assert.IsType<LongTitleException>(ex);
        }

        [Fact]
        public void Create_Duplicate_Title_Test_Should_Be_ThrowsException()
        {
            isExist = true;
            var ex = Assert.Throws<DuplicateTitleException>(() => _ = new Product(argument, this));
            Assert.IsType<DuplicateTitleException>(ex);
        }

        [Fact]
        public void Create_Valid_Object_Product_Should_Be_Create()
        {
            var product = new Product(argument, this);
            product.Price.Should().Be(10000);
            product.Discount.Should().Be(20);
            product.InventoryCount.Should().Be(2);
            product.Title.Value.Should().Be("Pizza");
        }
        public bool IsExist(string title) => isExist;

    }
}