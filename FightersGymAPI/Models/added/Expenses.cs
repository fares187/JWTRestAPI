using System.ComponentModel.DataAnnotations;

namespace FightersGymAPI.Models.added
{
    public class Expenses
    {
        [Key]
        public int ExpenseId { get; set; }   
        public DateTime ExpenseDate { get; set; }
        [MaxLength(500)] 
        public string Description { get;set; }
        public double Amount { get; set; } 
        public string CreatedBy { get;set; }
        public ApplicationUser ApplicationUser { get; set; } 
    }
}
