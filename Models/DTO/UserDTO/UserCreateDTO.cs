namespace FlashGamingHub.Models;
using System.ComponentModel.DataAnnotations;

public class UserCreateDTO{

    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public DateTime RegisterDate { get; set; }

    [Required]
    public string Role { get; set; }
}