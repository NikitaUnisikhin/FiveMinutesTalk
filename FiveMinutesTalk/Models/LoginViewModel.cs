using System.ComponentModel.DataAnnotations;

namespace FiveMinutesTalk.Models;

public class LoginViewModel
{
    [Display(Name = "Email")]
    public string UserName { get; set; }

    //[UIHint("password")]
    [Display(Name = "Пароль")]
    public string Password { get; set; }
    
    [Display(Name = "Запомнить меня?")]
    public bool RememberMe { get; set; }
}