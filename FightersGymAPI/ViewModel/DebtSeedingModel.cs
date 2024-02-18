namespace FightersGymAPI.ViewModel
{
    public class DebtSeedingModel
    {
        public int DebtId { get; set; }
        public int MemberID { get; set; }

        public DateTime DebtDate { get; set; }
        public int Amount { get; set; }
        public string description{get;set;}
    }
}
