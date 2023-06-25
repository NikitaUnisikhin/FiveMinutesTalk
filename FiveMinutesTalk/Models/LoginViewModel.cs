using System.ComponentModel.DataAnnotations;

namespace FiveMinutesTalk.Models;

public class LoginViewModel
{
    [Display(Name = "Email")] public string UserName { get; set; }

    [Display(Name = "Пароль")] public string Password { get; set; }

    [Display(Name = "Запомнить меня?")] public bool RememberMe { get; set; }
}