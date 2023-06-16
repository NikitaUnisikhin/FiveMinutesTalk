using FiveMinutesTalk.Domain;
using FiveMinutesTalk.Domain.Entities.Repositories.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

[Authorize]
public class SeparateStatisticsController : Controller
{
    private readonly DataManager dataManager;
    
    public SeparateStatisticsController(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }
    
    // 4043b854-c29f-4dca-900c-0387de52d250
    public IActionResult Index(Guid quizId)
    {
        var quizAnswerIds = ((EFQuizAnswerRepository)dataManager.QuizAnswers)
            .GetQuizAnswerIdByQuizId(quizId);
        ViewBag.QuizTitle = dataManager.Quizzes.GetItemById(quizId).Title;
        ViewBag.DataManager = dataManager;
        return View(quizAnswerIds);
    }
}