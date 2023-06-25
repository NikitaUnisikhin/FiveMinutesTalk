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

    public IActionResult Index(Guid token)
    {
        ViewBag.QuizId = token;
        var quizAnswerIds = ((EFQuizAnswerRepository)dataManager.QuizAnswers)
            .GetQuizAnswerIdByQuizId(token);
        ViewBag.QuizTitle = dataManager.Quizzes.GetItemById(token).Title;
        ViewBag.DataManager = dataManager;
        return View(quizAnswerIds);
    }
}