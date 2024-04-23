using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashGamingHub.Models
{
    public class LibraryGameUser
    {
        [Key]
        [Column(Order = 1)]
        public int UserID { get; set; }

        public int GameID { get; set; }

        public DateTime AddedDate { get; set; }

        public int Rating { get; set; }

        public int HoursPlayed { get; set; }

        public DateTime LastPlayed { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("GameID")]
        public Game Game { get; set; }

        public List<Game> Games { get; set; }
    }
}
