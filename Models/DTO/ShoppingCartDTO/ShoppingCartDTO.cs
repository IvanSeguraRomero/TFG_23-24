namespace FlashGamingHub.Models;

public class ShoppingCartDTO
    {
        public int UserID { get; set; }

        public List<GameDTO> Games { get; set; }
        public decimal Total { get; set; }

        public DateTime FechaCreacion { get; set; }

    }