namespace FlashGamingHub.Models
{
    public class GameDTO
    {
        public int GameID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Synopsis { get; set; }

        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Categories { get; set; }

        public int? StudioID { get; set; }


    }
}