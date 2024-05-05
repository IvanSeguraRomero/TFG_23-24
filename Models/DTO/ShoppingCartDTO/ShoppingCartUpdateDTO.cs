namespace FlashGamingHub.Models;

public class ShoppingCartUpdateDTO
    {

        public List<GameDTO>? Games { get; set; }
        public decimal? Total { get; set; }
        public DateTime? FechaCreacion { get; set; }

    }