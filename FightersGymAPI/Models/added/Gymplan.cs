using System.ComponentModel.DataAnnotations;

namespace FightersGymAPI.Models.added
{
    public class Gymplan
    {
        [Key]
        public int PlanId { get; set; }
        [MaxLength(250)]
        public string PlanName { get; set; }

        [MaxLength(500)]
        public string Description { get; set;}

        public double Price { get; set; }   
        public int DurationInDays { get; set; }   
        public double Discount { get; set; }    
        public int AttendanceDays { get; set; }
        public List<Membership>? Membership { get; set; }  

    }
}
