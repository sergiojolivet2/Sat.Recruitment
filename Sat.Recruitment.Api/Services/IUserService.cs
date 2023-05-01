using Sat.Recruitment.Api.Models;
using System.Threading.Tasks;

public interface IUserService
{
    Task<Result> CreateUserAsync(string name, string email, string address, string phone, string userType, string money);
}
