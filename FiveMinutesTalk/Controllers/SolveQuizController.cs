using FiveMinutesTalk.Domain;
using FiveMinutesTalk.Domain.Entities.Repositories.EntityFramework;
using FiveMinutesTalk.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

public class SolveQuizController : Controller
{
    private readonly DataManager dataManager;
    
    public SolveQuizController(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }
    
    // 4043b854-c29f-4dca-900c-0387de52d250
    [HttpGet]
    public IActionResult Index(Guid token)
    {
        ViewBag.DataMangager = dataManager;
        ViewBag.QuizTitle = dataManager.Quizzes.GetItemById(token).Title;
        var questionsIds = ((EFQuizQuestionsRepository)dataManager.QuizQuestions)
            .GetQuestionsIdByQuizId(token);
        return View(questionsIds);
    }

    [HttpPost]
    public IActionResult SaveResult(QuestionAnswerModel[] answers)
    {
        return View("GetResult");
    }
}