using FiveMinutesTalk.Models;
using Microsoft.AspNetCore.Mvc;
using FiveMinutesTalk.Quizes;

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
        Storage.AddQuiz(question);
        return Redirect("/");
    }
}