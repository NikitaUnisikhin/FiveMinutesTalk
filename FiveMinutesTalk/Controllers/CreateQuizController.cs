using FiveMinutesTalk.Domain;
using FiveMinutesTalk.Domain.Entities;
using FiveMinutesTalk.Domain.Entities.QuestionsTypes;
using FiveMinutesTalk.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Controllers;

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
            Title = quizTitle
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

            if (newQuestion.Type == QuestionTypeEnum.MultipleAnswersQuestion)
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

        return View("QuizCreate");
    }
}