using Xunit;
using Sat.Recruitment.Api.Data;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services;

namespace Sat.Recruitment.Test
{
    public class UserValidatorTest
    {
        private readonly IUserValidator _userValidator;

        public UserValidatorTest()
        {
            _userValidator = new UserValidator();
        }

        [Fact]
        public void Validate_ShouldReturnValidResult_WhenAllFieldsAreValid()
        {
            // Arrange
            var name = "John Doe";
            var email = "john.doe@test.com";
            var address = "123 Main St";
            var phone = "1234567890";

            // Act
            var validationResult = _userValidator.Validate(name, email, address, phone);

            // Assert
            Assert.True(validationResult.IsValid);
            Assert.Null(validationResult.Errors);
        }

        [Fact]
        public void Validate_ShouldReturnInvalidResult_WhenFieldsAreMissing()
        {
            // Arrange
            var name = "";
            var email = "";
            var address = "";
            var phone = "";

            // Act
            var validationResult = _userValidator.Validate(name, email, address, phone);

            // Assert
            Assert.False(validationResult.IsValid);
            Assert.Contains("The name is required", validationResult.Errors);
            Assert.Contains("The email is required", validationResult.Errors);
            Assert.Contains("The address is required", validationResult.Errors);
            Assert.Contains("The phone is required", validationResult.Errors);
        }

        // Puedes agregar más pruebas con diferentes combinaciones de campos faltantes o inválidos.
    }
}
