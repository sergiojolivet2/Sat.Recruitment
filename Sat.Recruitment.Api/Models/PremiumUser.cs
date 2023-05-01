namespace Sat.Recruitment.Api.Models
{
    public class PremiumUser : User
    {
        public PremiumUser()
        {
            UserType = "Premium";
        }

        public override void CalculateMoney(decimal initialMoney)
        {
            if (initialMoney > 100)
            {
                var bonus = initialMoney * 2;
                Money = initialMoney + bonus;
            }
        }
    }
}
