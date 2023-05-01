using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Data
{
    public interface IUserValidator
    {
        ValidationResult Validate(string name, string email, string address, string phone);
    }
}
