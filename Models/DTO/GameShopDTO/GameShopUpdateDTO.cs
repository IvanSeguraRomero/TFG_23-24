using System.ComponentModel.DataAnnotations;
namespace FlashGamingHub.Models;

public class GameShopUpdateDTO{

    [StringLength(80, ErrorMessage = "El evento debe ser mas corta")]
    public string? Event { get; set; }
    
    public int? AnnualSales { get; set; }

    public DateTime? LastUpdated { get; set; }

    [StringLength(20, ErrorMessage = "El origen debe ser más corto")]
    public string? Origin { get; set; }

    [StringLength(100, ErrorMessage = "La ubicación debe ser más corta")]
    public string? Location { get; set; }

    [StringLength(20, ErrorMessage = "El teléfono debe ser mas corto")]
    public string? ContactNumber { get; set; }

    [StringLength(50, ErrorMessage = "El correo debe ser mas corto")]
    public string? Email { get; set; }
}