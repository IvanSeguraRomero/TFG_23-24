namespace FlashGamingHub.Models;
    public class GameShopDTO
    {
        public int StoreID { get; set; }

        public int GameID { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public int Stock { get; set; }

        public int AnnualSales { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Categories { get; set; }

        public string Origin { get; set; }

    }
