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
        var quiz = dataManager.Quizzes.GetItemById(token);
        ViewBag.QuizTitle = quiz.Title;
        ViewBag.QuidId = quiz.Id;
        var questionsIds = ((EFQuizQuestionsRepository)dataManager.QuizQuestions)
            .GetQuestionsIdByQuizId(token);
        return View(questionsIds);
    }

    [HttpPost]
    public IActionResult SaveResult(QuestionAnswerModel[] answers)
    {
        foreach (var answer in answers)
            dataManager.QuestionAnswers.SaveItem(answer);
        return View("GetResult");
    }
}