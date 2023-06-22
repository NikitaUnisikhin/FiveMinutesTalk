using FiveMinutesTalk.Domain;
using FiveMinutesTalk.Domain.Entities;
using FiveMinutesTalk.Domain.Entities.Repositories.EntityFramework;
using FiveMinutesTalk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

[Authorize]
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

        if (quiz.Start > DateTime.Now || DateTime.Now > quiz.End)
            return Empty;
        
        ViewBag.End = quiz.End;
        ViewBag.QuizTitle = quiz.Title;
        ViewBag.QuidId = quiz.Id;
        var questionsIds = ((EFQuizQuestionsRepository)dataManager.QuizQuestions)
            .GetQuestionsIdByQuizId(token);
        return View(questionsIds);
    }

    [HttpPost]
    public IActionResult SaveResult(QuestionAnswerModel[] answers)
    {
        if (answers.Length == 0)
            View("GetResult");
        
        var quizAnswerId = Guid.NewGuid();
        dataManager.QuizAnswers.SaveItem(new QuizAnswer()
        {
            Id = quizAnswerId,
            QuizId = answers[0].QuizId
        });

        foreach (var answer in answers)
        {
            dataManager.QuestionAnswers.SaveItem(answer);
            dataManager.QuizQuestionAnswers.SaveItem(new QuizQuestionAnswer()
            {
                Id = Guid.NewGuid(),
                QuestionAnswerId = answer.Id,
                QuizAnswerId = quizAnswerId
            });
        }

        return View("GetResult");
    }
}