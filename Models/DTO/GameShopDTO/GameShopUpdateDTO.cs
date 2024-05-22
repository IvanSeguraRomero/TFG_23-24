using System.ComponentModel.DataAnnotations;
namespace FlashGamingHub.Models;

public class GameShopUpdateDTO{

    [StringLength(80, ErrorMessage = "El evento debe ser mas corta")]
    public string? Event { get; set; }

    public int? Stock { get; set; }

    public int? AnnualSales { get; set; }

    public DateTime? LastUpdated { get; set; }

    [StringLength(20, ErrorMessage = "El origen debe ser más corto")]
    public string? Origin { get; set; }
}