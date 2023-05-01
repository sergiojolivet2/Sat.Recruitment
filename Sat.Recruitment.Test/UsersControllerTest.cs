using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services;
using Sat.Recruitment.Api.Controllers;
using System.Threading.Tasks;

namespace Sat.Recruitment.Test
{
    public class UsersControllerTest
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UsersController _usersController;

        public UsersControllerTest()
        {
            _userServiceMock = new Mock<IUserService>();
            _usersController = new UsersController(_userServiceMock.Object);
        }

        [Fact]
        public async Task CreateUser_ShouldCallUserService_CreateUserAsync()
        {
            // Arrange
            _userServiceMock.Setup(service => service.CreateUserAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new Result { IsSuccess = true, Errors = "User Created" });

            // Act
            var result = await _usersController.CreateUser("Name", "Email", "Address", "Phone", "UserType", "100");

            // Assert
            _userServiceMock.Verify(service => service.CreateUserAsync("Name", "Email", "Address", "Phone", "UserType", "100"), Times.Once);

            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        // Puedes agregar más pruebas para otros casos según sea necesario.
    }
}
