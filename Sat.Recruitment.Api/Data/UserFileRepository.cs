using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Data
{
    public class UserFileRepository : IUserRepository
    {
        private readonly string _filePath;

        public UserFileRepository()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "Users.txt");
        }
        public UserFileRepository(string filePath)
        {
            _filePath = filePath;
        }
        public async Task<List<User>> GetUsersAsync()
        {
            var users = new List<User>();

            using (var fileStream = new FileStream(_filePath, FileMode.Open))
            using (var reader = new StreamReader(fileStream))
            {
                while (reader.Peek() >= 0)
                {
                    var line = await reader.ReadLineAsync();
                    var userData = line.Split(',');

                    var user = UserFactory.CreateUser(
                        userData[0],
                        userData[1],
                        userData[2],
                        userData[3],
                        userData[4],
                        decimal.Parse(userData[5]));

                    users.Add(user);
                }
            }

            return users;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            using (var fileStream = new FileStream(_filePath, FileMode.Append))
            using (var writer = new StreamWriter(fileStream))
            {

                await writer.WriteLineAsync(
                    $"{user.Name},{user.Email},{user.Phone},{user.Address},{user.UserType},{user.Money}");
            }

            return true;
        }
    }
}
