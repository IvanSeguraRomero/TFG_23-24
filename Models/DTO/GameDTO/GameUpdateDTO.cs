using System.ComponentModel.DataAnnotations;
namespace FlashGamingHub.Models;

public class GameUpdateDTO{

    [StringLength(20, ErrorMessage = "El nombre debe ser mas corto")]
    public string? Name { get; set; }

    [StringLength(1000, ErrorMessage = "La descripción debe ser mas corta")]
    public string? Description { get; set; }

    [StringLength(300, ErrorMessage = "La sinopsis debe ser mas corta")]
    public string? Synopsis { get; set; }

    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio debe tener hasta dos decimales.")]
    public decimal? Price { get; set; }

    public int? Discount { get; set; }

    public DateTime? ReleaseDate { get; set; }

    [StringLength(300, ErrorMessage = "Tiene que haber menos categorías")]
    public string? Categories { get; set; }

    [StringLength(100, ErrorMessage = "El comentario debe ser mas corto")]
    public List<Community>? messages{ get; set; }
}