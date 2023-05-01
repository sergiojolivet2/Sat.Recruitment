using Xunit;
using Sat.Recruitment.Api.Data;
using Sat.Recruitment.Api.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Test
{
    public class UserFileRepositoryTest
    {
        private readonly string _testFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "TestUsers.txt");

        public UserFileRepositoryTest()
        {
            // Crear un archivo de texto de prueba con usuarios
            var testUsers = "Name1,Email1@test.com,1111111111,Address1,Normal,100\n" +
                            "Name2,Email2@test.com,2222222222,Address2,Premium,200\n" +
                            "Name3,Email3@test.com,3333333333,Address3,SuperUser,300\n";

            File.WriteAllText(_testFilePath, testUsers);
        }

        [Fact]
        public async Task GetUsersAsync_ShouldReturnUsersFromFile()
        {
            // Arrange
            var userRepository = new UserFileRepository(_testFilePath);

            // Act
            var users = await userRepository.GetUsersAsync();

            // Assert
            Assert.NotNull(users);
            Assert.Equal(3, users.Count);

            Assert.Equal("Name1", users[0].Name);
            Assert.Equal("Email1@test.com", users[0].Email);
            Assert.Equal("1111111111", users[0].Phone);
            Assert.Equal("Address1", users[0].Address);
            Assert.Equal("Normal", users[0].UserType);
            Assert.Equal(100m, users[0].Money);

            // Agregar más verificaciones para los otros usuarios...
        }

        [Fact]
        public async Task AddUserAsync_ShouldAppendUserToFile()
        {
            // Arrange
            var userRepository = new UserFileRepository(_testFilePath);
            var newUser = new NormalUser
            {
                Name = "Name4",
                Email = "Email4@test.com",
                Phone = "4444444444",
                Address = "Address4",
                Money = 400m
            };

            // Act
            var result = await userRepository.AddUserAsync(newUser);

            // Assert
            Assert.True(result);

            var usersAfterAdd = await userRepository.GetUsersAsync();
            Assert.Equal(4, usersAfterAdd.Count);

            var addedUser = usersAfterAdd[3];
            Assert.Equal(newUser.Name, addedUser.Name);
            Assert.Equal(newUser.Email, addedUser.Email);
            Assert.Equal(newUser.Phone, addedUser.Phone);
            Assert.Equal(newUser.Address, addedUser.Address);
            Assert.Equal(newUser.UserType, addedUser.UserType);
            Assert.Equal(newUser.Money, addedUser.Money);
        }
    }
}
