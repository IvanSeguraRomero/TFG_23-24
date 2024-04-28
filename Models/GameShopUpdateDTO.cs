using System.ComponentModel.DataAnnotations;
namespace FlashGamingHub.Models;

public class GameShopUpdateDTO{

    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio debe tener hasta dos decimales.")]
    public decimal? Price { get; set; }

    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El descuento debe tener hasta dos decimales.")]
    public decimal? Discount { get; set; }

    public int? Stock { get; set; }

    public int? AnnualSales { get; set; }

    public DateTime? LastUpdated { get; set; }

    [StringLength(20, ErrorMessage = "La categoría debe ser mas corta")]
    public string? Categories { get; set; }

    [StringLength(20, ErrorMessage = "El origen debe ser más corto")]
    public string? Origin { get; set; }
}