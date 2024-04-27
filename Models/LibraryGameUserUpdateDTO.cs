using System.ComponentModel.DataAnnotations;
namespace FlashGamingHub.Models;

public class LibraryGameUserUpdateDTO{

    public DateTime? AddedDate { get; set; }

    public int? Rating { get; set; }

    public int? HoursPlayed { get; set; }

    public DateTime? LastPlayed { get; set; }
}