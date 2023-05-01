using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Data;
using Sat.Recruitment.Api.Models;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidator _userValidator;

        public UserService(IUserRepository userRepository, IUserValidator userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public async Task<Result> CreateUserAsync(string name, string email, string address, string phone, string userType, string money)
        {
            var userValidationResult = _userValidator.Validate(name, email, address, phone);

            if (!userValidationResult.IsValid)
            {
                return new Result { IsSuccess = false, Errors = userValidationResult.Errors };
            }

            var users = await _userRepository.GetUsersAsync();
            var newUser = UserFactory.CreateUser(name, email, address, phone, userType, decimal.Parse(money));
            newUser.CalculateMoney(decimal.Parse(money));

            foreach (var user in users)
            {
                if (user.Email == newUser.Email || user.Phone == newUser.Phone || (user.Name == newUser.Name && user.Address == newUser.Address))
                {
                    return new Result { IsSuccess = false, Errors = "The user is duplicated" };
                }
            }

            await _userRepository.AddUserAsync(newUser);
            return new Result { IsSuccess = true, Errors = "User Created" };
        }
    }
}
