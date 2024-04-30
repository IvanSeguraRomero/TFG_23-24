namespace FlashGamingHub.Models
{
    public class GameDTO
    {
        public int GameID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public bool Available { get; set; }

        public int StudioID { get; set; }

        public StudioDTO Studio { get; set;}

        public List<GameShopDTO>  StoresAvailableAt { get; set; }

    }
}