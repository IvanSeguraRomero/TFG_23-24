using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashGamingHub.Models
{
    public class GameShop
    {
        [Key]
        public int StoreID { get; set; }

        public int GameID { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Discount { get; set; }

        public int Stock { get; set; }

        public int AnnualSales { get; set; }

        public DateTime LastUpdated { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Categories { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string Origin { get; set; }

        [ForeignKey("GameID")]
        public Game Game { get; set; }

        public List<Game> Games { get; set; }
    }
}
