using Northwind.Core.Domain;

using Xunit;

namespace Northwind.Tests.Core.Domain
{
    public class PhonenumberTests
    {
        [Fact]
        public void Shoud_create_phonennumber()
        {
            var number = new Phonenumber("Extension", "123456");
            
            Assert.Equal("Extension", number.Description);
            Assert.Equal("123456", number.Number);
        }
    }
}
