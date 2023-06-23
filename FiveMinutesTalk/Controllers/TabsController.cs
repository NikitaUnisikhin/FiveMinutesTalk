using FiveMinutesTalk.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

public class TabsController : Controller
{
    private readonly DataManager _dataManager;

    public TabsController(DataManager dataManager)
    {
        _dataManager = dataManager;
    }
    
    [HttpPost]
    public IActionResult Index(IFormCollection form, Guid quizId)
    {
        var statisticsType = ((FormCollection)form).Keys.FirstOrDefault();
        if (statisticsType == "1")
            return RedirectToAction("Quizzes", "Account", new { token = quizId });
        else if (statisticsType == "2")
            return RedirectToAction("Index", "GeneralStatistics", new { token = quizId });
        return Empty;
    }
}