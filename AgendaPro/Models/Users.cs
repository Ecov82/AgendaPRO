// Models/User.cs
using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
    public string PasswordHash { get; set; } = string.Empty;

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [Display(Name = "Nome completo")]
    public string Name { get; set; } = string.Empty;

    public bool IsMaster { get; set; } = false;
}
