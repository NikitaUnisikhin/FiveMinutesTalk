using FiveMinutesTalk.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

public class CreateQuizController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SaveChanges(QuestionModel question)
    {
        return Redirect("/");
    }
}