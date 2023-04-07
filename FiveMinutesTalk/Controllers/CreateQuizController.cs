using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

public class CreateQuizController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}