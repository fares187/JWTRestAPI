using System.Security.Policy;

namespace FightersGymAPI.ViewModel
{
    public class SeedingExpensesModel
    {
        public int expense_id { get; set; }
        public DateTime expense_date { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public string CreatedBy { get; set; }
    }
}
