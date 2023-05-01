using Xunit;
using Moq;
using Sat.Recruitment.Api.Data;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services;
using System.Threading.Tasks;

namespace Sat.Recruitment.Test
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IUserValidator> _userValidatorMock;
        private readonly UserService _userService;

        public UserServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userValidatorMock = new Mock<IUserValidator>();
            _userService = new UserService(_userRepositoryMock.Object, _userValidatorMock.Object);
        }

        [Fact]
        public async Task CreateUserAsync_ShouldReturnErrorResult_WhenValidationFails()
        {
            // Arrange
            _userValidatorMock.Setup(validator => validator.Validate(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new ValidationResult { IsValid = false, Errors = "Validation error" });

            // Act
            var result = await _userService.CreateUserAsync("Name", "Email", "Address", "Phone", "UserType", "100");

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Validation error", result.Errors);
        }

        // Puedes agregar más pruebas para otros casos, como cuando el usuario ya existe o cuando la creación del usuario es exitosa.
    }
}
