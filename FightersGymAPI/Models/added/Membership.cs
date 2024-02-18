using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace FightersGymAPI.Models.added
{
    public class Membership
    {
        [Key]
        public int MembershipId { get;set; }
        public string MemberId { get;set; }
        public Member Member { get;set; }   
        public int PlanID { get;set; }
        public Gymplan Plan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
