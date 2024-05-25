namespace FlashGamingHub.Models
{
    public class CommunityDTO
    {
        public int MessageID { get; set; }

        public int? UserID { get; set; }

        public int? GameID  { get; set; }

        public string Message { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool ActiveMember { get; set; }

        public int LikesCount { get; set; }
    }
}