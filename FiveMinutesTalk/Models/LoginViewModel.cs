using System.ComponentModel.DataAnnotations;

namespace FiveMinutesTalk.Models;

public class LoginViewModel
{
    [Microsoft.Build.Framework.Required]
    [Display(Name = "Email")]
    public string UserName { get; set; }

    [Required] 
    [UIHint("password")]
    [Display(Name = "Пароль")]
    public string Password { get; set; }
    
    [Display(Name = "Запомнить меня?")]
    public bool RememberMe { get; set; }
}