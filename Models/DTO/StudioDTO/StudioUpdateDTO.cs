using System.ComponentModel.DataAnnotations;
namespace FlashGamingHub.Models;

public class StudioUpdateDTO{

    [StringLength(100, ErrorMessage = "El nombre debe ser mas largo")]
    public string? Name { get; set; }

    public DateTime? Fundation { get; set; }

    [StringLength(50, ErrorMessage = "El nombre del país debe ser mas largo")]
    public string? Country { get; set; }

    [StringLength(100, ErrorMessage = "Email demasiado largo")]
    public string? EmailContact { get; set; }

    [StringLength(100, ErrorMessage = "Email demasiado largo")]
    public string? EmailLogin { get; set; }

    [StringLength(20, ErrorMessage = "Contraseña demasiada larga")]
    public string? Password { get; set; }

    [StringLength(100, ErrorMessage = "Website demasiado corta")]
    public string? Website { get; set; }
}
