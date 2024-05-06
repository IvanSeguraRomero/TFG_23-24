using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashGamingHub.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartID { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public User User { get; set; }

        public List<Game> Games { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
