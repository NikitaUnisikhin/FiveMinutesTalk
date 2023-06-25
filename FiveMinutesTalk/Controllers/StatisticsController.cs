using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

public class StatisticsController : Controller
{
    [HttpPost]
    public IActionResult Index(IFormCollection form, Guid quizId)
    {
        var statisticsType = ((FormCollection)form).Keys.FirstOrDefault();
        return statisticsType switch
        {
            "1" => RedirectToAction("Index", "GeneralStatistics", new { token = quizId }),
            "2" => RedirectToAction("Index", "SeparateStatistics", new { token = quizId }),
            _ => Empty
        };
    }
}