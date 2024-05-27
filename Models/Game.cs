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

        [Column(TypeName = "nvarchar(300)")]
        public string Synopsis {get; set;}

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "int")]
        public int Discount { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string Categories {get; set;}

        [ForeignKey("StudioID")]
        public int StudioID { get; set; }

        public Studio Studio { get; set; }
        //este id fuera, esta en una lista de tiendas
         [ForeignKey("StoreID")]
         public int StoreID { get; set; }
        public List<GameShop>  StoresAvailableAt { get; set; }

        public List<LibraryGameUser>? libraryGameUser { get; set; }

        public List<ShoppingCart>? shoppingCart { get; set; }

        public List<Community> messages{ get; set; }


    }
}
