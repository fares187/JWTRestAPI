using System.ComponentModel.DataAnnotations;

namespace FightersGymAPI.ViewModel
{
    public class SeedingMemebersViewModel
    {
        public int MemberID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public string UserName { get; set; }    
        public string? Email { get; set; }
        //public string Password { get; set; }

        public DateTime? JoinDate { get; set; }
        public DateOnly? BirthDate { get; set; }
        [MaxLength(10)]
        public string Gender { get; set; }
        [MaxLength(500)]
        public string? Address { get; set; }
        [MaxLength(200)]
        public string Barcode { get; set; }

        public DateTime LastAttendanceDate { get; set; }
        public byte[]? ProfilePic { get; set; }
        public int? DaysLeft { get; set; }
        // public int F_notify { get; set; }
        [MaxLength(40)]
        public string Phone { get; set; }
    }
}
