using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FightersGymAPI.Models.added
{
    public class Attendance
    {
        [Key]
      
        public int AttednaceId { get; set; }
     
        public string MemberId { get; set; }
        
       public Member Member { get; set; }   

       public DateTime Datetime { get; set; }
       public int BarCode { get; set; } 

    }
}
