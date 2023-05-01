namespace Sat.Recruitment.Api.Models
{
    public class SuperUser : User
    {
        public SuperUser()
        {
            UserType = "SuperUser";
        }

        public override void CalculateMoney(decimal initialMoney)
        {
            if (initialMoney > 100)
            {
                var percentage = 0.20m;
                var bonus = initialMoney * percentage;
                Money = initialMoney + bonus;
            }
        }
    }
}
