namespace FlashGamingHub.Models;
using System.ComponentModel.DataAnnotations;

public class LibraryGameUserCreateDTO{

    [Required]
    public DateTime AddedDate { get; set; }

    [Required]
    public int Rating { get; set; }

    [Required]
    public int HoursPlayed { get; set; }

    [Required]
    public DateTime LastPlayed { get; set; }
}