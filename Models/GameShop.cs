using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashGamingHub.Models
{
    public class GameShop
    {
        [Key]
        public int StoreID { get; set; }

        public int GameID { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string Event { get; set; }

        public int Stock { get; set; }

        public int AnnualSales { get; set; }

        public DateTime LastUpdated { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string Origin { get; set; }

        [ForeignKey("GameID")]

        public List<Game> Games { get; set; }
    }
}
