using lab6_op.Models;
using System.ComponentModel.DataAnnotations;

public class UserReg : BaseEntity
{
    [Required(ErrorMessage = "Ім'я користувача обов'язкове")]
    [StringLength(30)]
    public string Username { get; set; }

    [Required(ErrorMessage = "Пароль обов'язковий")]
    public string PasswordHash { get; set; }

    [Required]
    public string Role { get; set; }

    public UserReg(int id, string username, string passwordHash, string role)
        : base(id)
    {
        Username = username;
        PasswordHash = passwordHash;
        Role = role;
    }
}
