namespace FlashGamingHub.Models;
using System.ComponentModel.DataAnnotations;

public class GameShopCreateDTO{

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string Event { get; set; }

    [Required]
    public int AnnualSales { get; set; }

    [Required]
    public DateTime LastUpdated { get; set; }

    [Required]
    public string Origin { get; set; }


    [Required]
    public string Location { get; set; }

    [Required]
    public string ContactNumber { get; set; }

    [Required]
    public string Email { get; set; }
}