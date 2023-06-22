using System.Security.Claims;
using FiveMinutesTalk.Domain;
using FiveMinutesTalk.Domain.Entities;
using FiveMinutesTalk.Domain.Entities.QuestionsTypes;
using FiveMinutesTalk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

[Authorize]
public class CreateQuizController : Controller
{
    private readonly DataManager dataManager;

    public CreateQuizController(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SaveChanges(QuestionModel[] questions, string quizTitle)
    {
        var quizId = Guid.NewGuid();
        ViewBag.QuizId = quizId;
        
        dataManager.Quizzes.SaveItem(new Quiz()
        {
            Id = quizId,
            Title = quizTitle,
            OwnerId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty)
        });

        foreach (var question in questions)
        {
            var questionId = Guid.NewGuid();
            var newQuestion = new Question()
            {
                Id = questionId,
                Text = question.Text,
                Type = question.Type
            };

            if (newQuestion.Type is QuestionTypeEnum.MultipleAnswersQuestion or QuestionTypeEnum.Radio)
            {
                newQuestion.AnswerOptions = question.AnswerOptions;
                newQuestion.CorrectAnswers = question.CorrectAnswers;
            }
            
            dataManager.Questions.SaveItem(newQuestion);
            
            dataManager.QuizQuestions.SaveItem(new QuizQuestion()
            {
                Id = Guid.NewGuid(),
                QuestionId = questionId,
                QuizId = quizId
            });
        }
        
        return View("PopUp", quizId);
    }
}