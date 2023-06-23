using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

public class StatisticsController : Controller
{
    [HttpPost]
    public IActionResult Index(IFormCollection form, Guid quizId)
    {
        var statisticsType = ((FormCollection)form).Keys.FirstOrDefault();
        if (statisticsType == "1")
            return RedirectToAction("Index", "GeneralStatistics", new { token = quizId });
        if (statisticsType == "2")
            return RedirectToAction("Index", "SeparateStatistics", new { token = quizId });
        return Empty;
    }
}