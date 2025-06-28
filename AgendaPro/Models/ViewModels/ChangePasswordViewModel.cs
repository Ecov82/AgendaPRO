using System.ComponentModel.DataAnnotations;

public class ChangePasswordViewModel
{
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Senha atual é obrigatória.")]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; } = null!;

    [Required(ErrorMessage = "Nova senha é obrigatória.")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = null!;

    [Required(ErrorMessage = "Confirmação da nova senha é obrigatória.")]
    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "As senhas não coincidem.")]
    public string ConfirmNewPassword { get; set; } = null!;
}
