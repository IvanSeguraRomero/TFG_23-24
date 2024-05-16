namespace FlashGamingHub.Models;
using System.ComponentModel.DataAnnotations;

public class CommunityCreateDTO{
    [Required]
    public string Message { get; set; }

    [Required]
    public DateTime PublicationDate { get; set; }

    [Required]
    public bool ActiveMember { get; set; }

    [Required]
    public int LikesCount { get; set; }

    public int? UserID {get; set; }
}