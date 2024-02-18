using System.ComponentModel.DataAnnotations;

namespace FightersGymAPI.Models.added
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get;set; }
        public string? MemberId { get; set; }    
        public Member? Member { get; set; }  
        public int? ProductId { get; set; }   
        public Product? Product { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string? CreatedById { get;set; }
        public ApplicationUser? CreatedBy { get; set; }

    }
}
