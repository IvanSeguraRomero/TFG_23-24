using System.ComponentModel.DataAnnotations;

namespace FlashGamingHub.Models;

public class ShoppingCartCreateDTO
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }

    }