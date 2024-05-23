using System.ComponentModel.DataAnnotations;
namespace FlashGamingHub.Models;

public class StudioUpdateDTO{

    [StringLength(20, ErrorMessage = "El nombre debe ser mas corto")]
    public string? Name { get; set; }

    public DateTime? Fundation { get; set; }

    [StringLength(20, ErrorMessage = "El nombre del país debe ser mas corto")]
    public string? Country { get; set; }

    [StringLength(20, ErrorMessage = "Email demasiado corto")]
    public string? EmailContact { get; set; }

    [StringLength(20, ErrorMessage = "Email demasiado corto")]
    public string? EmailLogin { get; set; }

    [StringLength(20, ErrorMessage = "Contraseña demasiada corta")]
    public string? Password { get; set; }

    [StringLength(20, ErrorMessage = "Website demasiado corta")]
    public string? Website { get; set; }
}