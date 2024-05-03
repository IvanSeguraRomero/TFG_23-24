using System.ComponentModel.DataAnnotations;

namespace FlashGamingHub.Models;

public class UserDTOOut
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
}

