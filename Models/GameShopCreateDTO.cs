namespace FlashGamingHub.Models;
using System.ComponentModel.DataAnnotations;

public class GameShopCreateDTO{

    [Required]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio debe tener hasta dos decimales.")]
    public decimal Price { get; set; }

    [Required]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El descuento debe tener hasta dos decimales.")]
    public decimal Discount { get; set; }

    [Required]
    public int Stock { get; set; }

    [Required]
    public int AnnualSales { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public string Categories { get; set; }

    [Required]
    public string Origin { get; set; }
}