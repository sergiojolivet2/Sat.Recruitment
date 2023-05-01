using Xunit;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services;

namespace Sat.Recruitment.Test
{
    public class UserFactoryTest
    {
        [Theory]
        [InlineData("John Doe", "john.doe@test.com", "1234567890", "123 Main St", "SuperUser", 1000)]
        [InlineData("Jane Doe", "jane.doe@test.com", "2345678901", "456 Main St", "Premium", 500)]
        [InlineData("Joe Bloggs", "joe.bloggs@test.com", "3456789012", "789 Main St", "Normal", 300)]
        public void CreateUser_ShouldReturnUserWithCorrectTypeAndData(string name, string email, string phone, string address, string userType, decimal money)
        {
            // Act
            var user = UserFactory.CreateUser(name, email, phone, address, userType, money);

            // Assert
            Assert.Equal(userType, user.UserType);
            Assert.Equal(name, user.Name);
            Assert.Equal(email, user.Email);
            Assert.Equal(address, user.Address);
            Assert.Equal(phone, user.Phone);
            Assert.Equal(money, user.Money);
        }

        [Fact]
        public void CreateUser_ShouldReturnNormalUser_WhenUserTypeIsUnknown()
        {
            // Arrange
            var name = "John Doe";
            var email = "john.doe@test.com";
            var phone = "1234567890";
            var address = "123 Main St";
            var userType = "Unknown";
            var money = 1000m;

            // Act
            var user = UserFactory.CreateUser(name, email, phone, address, userType, money);

            // Assert
            Assert.IsType<NormalUser>(user);
            Assert.Equal("Normal", user.UserType);
            Assert.Equal(name, user.Name);
            Assert.Equal(email, user.Email);
            Assert.Equal(address, user.Address);
            Assert.Equal(phone, user.Phone);
            Assert.Equal(money, user.Money);
        }
    }
}