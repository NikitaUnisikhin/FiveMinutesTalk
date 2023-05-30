using System.ComponentModel.DataAnnotations;

namespace FiveMinutesTalk.Models;

public class RegisterViewModel
{
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
 
    [Display(Name = "Пароль")]
    public string Password { get; set; }
 
    [Display(Name = "Подтвердить пароль")]
    public string PasswordConfirm { get; set; }
}