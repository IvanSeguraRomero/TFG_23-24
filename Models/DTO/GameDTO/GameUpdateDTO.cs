using System.ComponentModel.DataAnnotations;
namespace FlashGamingHub.Models;

public class GameUpdateDTO{

    [StringLength(20, ErrorMessage = "El nombre debe ser mas corto")]
    public string? Name { get; set; }

    [StringLength(300, ErrorMessage = "La descripción debe ser mas corta")]
    public string? Description { get; set; }

    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio debe tener hasta dos decimales.")]
    public decimal? Price { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public bool? Available { get; set; }
}