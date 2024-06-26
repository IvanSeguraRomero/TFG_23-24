using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashGamingHub.Models
{
    public class LibraryGameUser
    {
        [Key]
        [Column(Order = 1)]
        public int LibraryGameUserId { get; set; }

        public DateTime AddedDate { get; set; }

        public int Rating { get; set; }

        public int HoursPlayed { get; set; }

        public DateTime LastPlayed { get; set; }

        [ForeignKey("UserID")]
        public int? UserID { get; set; }
        public User? User { get; set; }
        public List<Game>? Games { get; set; }
    }
}
