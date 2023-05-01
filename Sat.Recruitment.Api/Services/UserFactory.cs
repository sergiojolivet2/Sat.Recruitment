using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Services
{
    public static class UserFactory
    {
        public static User CreateUser(string name, string email, string phone, string address, string userType, decimal money)
        {
            User user;

            switch (userType)
            {
                case "SuperUser":
                    user = new SuperUser();
                    break;
                case "Premium":
                    user = new PremiumUser();
                    break;
                default:
                    user = new NormalUser();
                    break;
            }

            user.Name = name;
            user.Email = email;
            user.Address = address;
            user.Phone = phone;
            user.Money = money;

            return user;
        }
    }

}
