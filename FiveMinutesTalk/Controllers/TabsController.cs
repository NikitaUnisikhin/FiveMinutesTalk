using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

public class TabsController : Controller
{
    [HttpPost]
    public IActionResult Index(IFormCollection form, Guid quizId)
    {
        var statisticsType = ((FormCollection)form).Keys.FirstOrDefault();
        return statisticsType switch
        {
            "1" => RedirectToAction("Quizzes", "Account", new { token = quizId }),
            "2" => RedirectToAction("Index", "GeneralStatistics", new { token = quizId }),
            _ => Empty
        };
    }
}