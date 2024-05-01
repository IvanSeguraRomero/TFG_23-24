namespace FlashGamingHub.Models;
using System.ComponentModel.DataAnnotations;

public class GameCreateDTO{

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public DateTime ReleaseDate { get; set; }

    [Required]
    public bool Available { get; set; }

    [Required]
    public int StudioID { get; set; }

    [Required]
    public int StoreID { get; set; }

}