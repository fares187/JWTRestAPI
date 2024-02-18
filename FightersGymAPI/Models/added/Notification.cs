using System.ComponentModel.DataAnnotations;

namespace FightersGymAPI.Models.added
{
    public class Notification
    {
        [Key] 
        public int NotificationId{ get;set; }
        public string MemberId { get;set; }
        public Member Member { get; set; }
        [MaxLength(500)]
        public string NotificationText { get;set; }
        public DateTime NotificatonDate { get; set; }
        [MaxLength(200)]
        public string FullName { get;set; }
        [MaxLength(40)]
        public string Phone { get;set; }
    }
}
