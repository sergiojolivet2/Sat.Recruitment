using Sat.Recruitment.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Data
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<bool> AddUserAsync(User user);
    }
}
