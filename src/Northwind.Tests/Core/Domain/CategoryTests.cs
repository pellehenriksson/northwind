using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Domain
{
    public class CategoryTests
    {
        [Fact]
        public void Should_create_category()
        {
            var category = Category.Create("some category", "some description of the category");

            Assert.Equal("some category", category.Name);
            Assert.Equal("some description of the category", category.Description);
        }

        [Fact]
        public void Should_not_allow_empty_name()
        {
            var result = Assert.Throws<DomainRuleException>(() => Category.Create(null, null));
           
            Assert.Equal("Invalid name", result.Message);
        }

        [Fact]
        public void Should_change_name()
        {
            var category = Category.Create("some category", "some description of the category");

            category.ChangeName("new name");
            
            Assert.Equal("new name", category.Name);
        }

        [Fact]
        public void Should_change_description()
        {
            var category = Category.Create("some category", "some description of the category");

           category.ChangeDescription("new description");
            
            Assert.Equal("new description", category.Description);
        }
    }
}
