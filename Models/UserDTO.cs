namespace FlashGamingHub.Models;
public class UserDTO
{
        public int UserID { get; set; }

        public string Name { get; set; }

        
        public string Surname { get; set; }

        
        public string Password { get; set; }

        public int? Age { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool Active { get; set; }

        public List<CommunityDTO> messages { get; set; } = new List<CommunityDTO>();
    
}