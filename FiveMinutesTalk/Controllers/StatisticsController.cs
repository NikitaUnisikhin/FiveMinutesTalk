using FiveMinutesTalk.Domain;
using FiveMinutesTalk.Domain.Entities.Repositories.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

public class StatisticsController : Controller
{
    private readonly DataManager dataManager;
    
    public StatisticsController(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }
    
    // 4043b854-c29f-4dca-900c-0387de52d250
    public IActionResult Index(Guid quizId)
    {
        ViewBag.QuizTitle = dataManager.Quizzes.GetItemById(quizId).Title;
        ViewBag.DataManager = dataManager;
        return View(quizId);
    }
}