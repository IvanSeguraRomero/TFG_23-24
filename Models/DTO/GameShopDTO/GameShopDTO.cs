namespace FlashGamingHub.Models;
    public class GameShopDTO
    {
        public int StoreID { get; set; }

        public int GameID { get; set; }

        public string? Event { get; set; }

        public int Stock { get; set; }

        public int AnnualSales { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Origin { get; set; }

    }
