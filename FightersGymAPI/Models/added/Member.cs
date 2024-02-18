using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FightersGymAPI.Models.added
{
    public class Member: ApplicationUser
    {
        public DateTime? JoinDate { get; set; }  
        public DateOnly? BirthDate { get;set; }
        [MaxLength(10)]
        public string Gender { get; set; }
        [MaxLength (500)]
        public string? Address { get; set; }
        [MaxLength(200)] 
        public string Barcode { get; set; }    
        public int F_old { get; set; }  
        public DateTime LastAttendanceDate { get; set; }    
        public byte[]? ProfilePic { get; set; }
        public int? DaysLeft { get; set; }
        public int F_notify { get; set; }
        [MaxLength(40)]
        public string Phone { get;set; }
        public List<Attendance> Attendance { get; set; }      
        public List<Debt>? Debts { get; set; }   
        public Membership Membership { get; set; }
        public List<Notification>? Notification { get; set; }
        public List<Payment>? Payments { get; set; }    

    }
}
