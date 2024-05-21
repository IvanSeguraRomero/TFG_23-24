namespace FlashGamingHub.Models
{
    public class StudioDTO
    {
        public int StudioID { get; set; }

        public string Name { get; set; }

        public DateTime Fundation { get; set; }

        public string Country { get; set; }

        public string EmailContact { get; set; }

        public string EmailLogin { get; set; }

        public string Website { get; set; }

        public List<GameDTO> games { get; set; } = new List<GameDTO>();
    }
}