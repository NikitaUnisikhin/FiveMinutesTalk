using FiveMinutesTalk.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

[Authorize]
public class GeneralStatisticsController : Controller
{
    private readonly DataManager dataManager;
    
    public GeneralStatisticsController(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }
    
    // 4043b854-c29f-4dca-900c-0387de52d250
    public IActionResult Index(Guid token)
    {
        ViewBag.QuizId = token;
        try
        {
            ViewBag.QuizTitle = dataManager.Quizzes.GetItemById(token).Title;
        }
        catch (Exception e)
        {
            return Redirect("~/CreateQuiz/Index");
        }
        ViewBag.DataManager = dataManager;
        return View(token);
    }
}