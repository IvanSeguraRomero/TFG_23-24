using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashGamingHub.Models
{
    public class GameShop
    {
        [Key]
        public int StoreID { get; set; }


        [Column(TypeName = "nvarchar(80)")]
        public string Event { get; set; }

        public int AnnualSales { get; set; }

        public DateTime LastUpdated { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string Origin { get; set; }

        public List<Game> Games { get; set; }

        
        [Column(TypeName = "nvarchar(100)")]
        public string Location { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string ContactNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
    }
}
