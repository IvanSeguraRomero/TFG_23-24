namespace FlashGamingHub.Models;
using System.ComponentModel.DataAnnotations;

public class GameShopCreateDTO{

    [Required]
    public decimal Price { get; set; }

    [Required]
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