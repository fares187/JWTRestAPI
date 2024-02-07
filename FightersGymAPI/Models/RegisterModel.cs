using System.ComponentModel.DataAnnotations;

namespace FightersGymAPI.Models
{
    public class RegisterModel
    {
        [MaxLength(100)]
        public string FirstName { get;set; }
        [MaxLength(100)]
        public string LastName { get;set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        public string Email { get; set; }
        [MaxLength(200)]
        public string Password { get; set; }
    }
}
