namespace FlashGamingHub.Models;
using System.ComponentModel.DataAnnotations;

public class StudioCreateDTO{

    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime Fundation { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string EmailContact { get; set; }

    [Required]
    public string Website { get; set; }

    [Required]
    public bool Active { get; set; }
}