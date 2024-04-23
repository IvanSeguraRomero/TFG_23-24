namespace FlashGamingHub.Models
{
    public class LibraryGameUserDTO
    {

        public DateTime AddedDate { get; set; }

        public int Rating { get; set; }

        public int HoursPlayed { get; set; }

        public DateTime LastPlayed { get; set; }

        public UserDTO User { get; set; } = new UserDTO();

        public List<GameDTO> Games { get; set; } = new List<GameDTO>();
    }
}