namespace FlashGamingHub.Models;
using System.ComponentModel.DataAnnotations;

public class StudioCreateDTO{

    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime Fundation { get; set; }

    [Required]
    public string Country { get; set; }

    public string? EmailContact { get; set; }

    [Required]
    public string EmailLogin { get; set; }

    [Required]
    public string Password { get; set; }

    public string? Website { get; set; }
}