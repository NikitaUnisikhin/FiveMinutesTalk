using FiveMinutesTalk.Controllers;
using FiveMinutesTalk.Models;

namespace FiveMinutesTalk.Quizes;

public static class Storage
{
    public static List<Quiz> Quizzes = new();

    public static void AddQuiz(IEnumerable<QuestionModel> questions)
    {
        Quizzes.Add(new Quiz(questions));
    }
    
    public static void AddQuiz(QuestionModel question)
    {
        Quizzes.Add(new Quiz(question));
    }
}