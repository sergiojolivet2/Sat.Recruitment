namespace Sat.Recruitment.Api.Models
{
    public class NormalUser : User
    {
        public NormalUser()
        {
            UserType = "Normal";
        }

        public override void CalculateMoney(decimal initialMoney)
        {
            if (initialMoney > 100)
            {
                var percentage = 0.12m;
                var bonus = initialMoney * percentage;
                Money = initialMoney + bonus;
            }
            else if (initialMoney > 10)
            {
                var percentage = 0.8m;
                var bonus = initialMoney * percentage;
                Money = initialMoney + bonus;
            }
        }
    }
}
