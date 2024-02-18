using FightersGymAPI.Models.added;
using System.ComponentModel.DataAnnotations;

namespace FightersGymAPI.ViewModel
{
    public class NewMemberViewModel
    {
        public DateTime? JoinDate { get; set; }
        public DateOnly? BirthDate { get; set; }
        public bool Gender { get; set; }
  
        public string? Address { get; set; }

        public string Barcode { get; set; }
        public DateTime LastAttendanceDate { get; set; }
        public byte[]? ProfilePic { get; set; }
        public string Phone { get; set; }
        
        public int planId { get; set; }
        public string userId { get; set; }  
        public double price { get; set; }
    }
}
