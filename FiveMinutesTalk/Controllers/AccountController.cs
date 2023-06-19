using FiveMinutesTalk.Domain;
using FiveMinutesTalk.Domain.Entities.Repositories.EntityFramework;
using FiveMinutesTalk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly DataManager dataManager;
    
    public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signinMgr,
        DataManager dataManager)
    {
        userManager = userMgr;
        signInManager = signinMgr;
        this.dataManager = dataManager;
    }

    [Authorize]
    public IActionResult Quizzes(Guid token)
    {
        try
        {
            ViewBag.Title = dataManager.Quizzes.GetItemById(token).Title;
        }
        catch (Exception e)
        {
            return Redirect("~/CreateQuiz/Index");
        }
        ViewBag.QuizId = token;
        var questionIds = ((EFQuizQuestionsRepository)dataManager.QuizQuestions)
            .GetQuestionsIdByQuizId(token);
        ViewBag.DataManager = dataManager;
        return View("Quiz", questionIds);
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if(ModelState.IsValid)
        {
            var user = new IdentityUser()
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        return View(model);
    }
    
    [HttpGet]
    public IActionResult Login(string returnUrl = null)
    {
        ViewBag.returnUrl = returnUrl;
        return View(new LoginViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
    {
        if (ModelState.IsValid)
        {
            IdentityUser user = await userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                await signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return Redirect(returnUrl ?? "/");
                }
            }
            ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
        }
        return View(model);
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}