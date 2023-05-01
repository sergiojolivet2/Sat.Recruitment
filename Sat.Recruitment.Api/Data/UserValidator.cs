using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Data
{
    public class UserValidator : IUserValidator
    {
        public ValidationResult Validate(string name, string email, string address, string phone)
        {
            var validationResult = new ValidationResult { IsValid = true };

            if (string.IsNullOrEmpty(name))
            {
                validationResult.IsValid = false;
                validationResult.Errors += " The name is required";
            }
            if (string.IsNullOrEmpty(email))
            {
                validationResult.IsValid = false;
                validationResult.Errors += " The email is required";
            }

            if (string.IsNullOrEmpty(address))
            {
                validationResult.IsValid = false;
                validationResult.Errors += " The address is required";
            }

            if (string.IsNullOrEmpty(phone))
            {
                validationResult.IsValid = false;
                validationResult.Errors += " The phone is required";
            }

            return validationResult;
        }
    }
}
