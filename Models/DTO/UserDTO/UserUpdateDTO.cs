using System.ComponentModel.DataAnnotations;
namespace FlashGamingHub.Models;

public class UserUpdateDTO{

    [StringLength(20, ErrorMessage = "El nombre debe ser mas corto")]
    public string? Name { get; set; }

    [StringLength(30, ErrorMessage = "Los apellidos deben ser mas cortos")]
    public string? Surname { get; set; }

    [StringLength(15, ErrorMessage = "La contraseña debe ser mas corta")]
    public string? Password { get; set; }

    public int? Age { get; set; }

    [StringLength(20, ErrorMessage = "El email debe ser mas corto")]
    public string? Email { get; set; }

    public DateTime? RegisterDate { get; set; }

    public bool? Active { get; set; }

    public string? Role { get; set; }

    public int? LibraryGameUserID { get; set; }

    public int? MessageID { get; set; }
}