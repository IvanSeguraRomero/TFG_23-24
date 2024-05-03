using System.ComponentModel.DataAnnotations;
namespace FlashGamingHub.Models;

public class CommunityUpdateDTO{

    [StringLength(100, ErrorMessage = "El mensaje debe ser mas corto")]
    public string? Message { get; set; }

    public DateTime? PublicationDate { get; set; }

    public bool? ActiveMember { get; set; }

    public int? LikesCount { get; set; }
}