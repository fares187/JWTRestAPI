using System.ComponentModel.DataAnnotations;

namespace FightersGymAPI.Models.added
{
    public class Debt
    {
        [Key]
        public int DebtId { get; set; }
        [MaxLength(100)]    
        public string MemeberId { get; set; }  
        public Member Member { get; set; }  
        public DateTime DebtDate { get; set; }
        public double Amount { get;set; }
        [MaxLength(300)]
        public string? Description { get; set; }
    }
}
