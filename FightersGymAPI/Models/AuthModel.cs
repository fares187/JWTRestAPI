namespace FightersGymAPI.Models
{
    public class AuthModel
    {
        public string Massage { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } 
        public string token { get; set; }   
        public DateTime ExpiresOn { get; set; }  
    }
}
