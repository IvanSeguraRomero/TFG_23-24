using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashGamingHub.Models
{
    public class Community
    {
        [Key]
        public int MessageID { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Message { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool Edited { get; set; }

        public int LikesCount { get; set; }

        [ForeignKey("UserID")]
        public int? UserID { get; set; }
        public User? User { get; set; }

        [ForeignKey("GameID")]
        public int? GameID { get; set; }
        public Game? Game { get; set; }


    }
}
