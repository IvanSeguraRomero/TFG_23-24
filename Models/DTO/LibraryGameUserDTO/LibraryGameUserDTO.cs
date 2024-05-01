namespace FlashGamingHub.Models
{
    public class LibraryGameUserDTO
    {
        public int LibraryGameUserId { get; set; }
        
        public DateTime AddedDate { get; set; }

        public int Rating { get; set; }

        public int HoursPlayed { get; set; }

        public DateTime LastPlayed { get; set; }

        public int? UserID { get; set; }

    }
}