namespace Sat.Recruitment.Api.Models
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; protected set; }
        public decimal Money { get; set; }

        public abstract void CalculateMoney(decimal initialMoney);
    }
}
