using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashGamingHub.Models
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public bool Available { get; set; }

        [ForeignKey("StudioID")]
        public int StudioID { get; set; }

        public Studio Studio { get; set; }

         [ForeignKey("StoreID")]
         public int StoreID { get; set; }
        public List<GameShop>  StoresAvailableAt { get; set; }
    }
}
