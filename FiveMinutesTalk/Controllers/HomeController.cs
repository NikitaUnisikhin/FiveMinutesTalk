using System.Diagnostics;
using System.Security.Claims;
using FiveMinutesTalk.Domain;
using FiveMinutesTalk.Domain.Entities.Repositories.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using FiveMinutesTalk.Models;
using Microsoft.AspNetCore.Authorization;

namespace FiveMinutesTalk.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataManager _dataManager;

    public HomeController(ILogger<HomeController> logger, DataManager dataManager)
    {
        _logger = logger;
        _dataManager = dataManager;
    }

    public IActionResult Index()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
        var quizzesIds = ((EFQuizzesRepository)_dataManager.Quizzes).GetItemsByOwnerId(userId);
        return View(quizzesIds);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}