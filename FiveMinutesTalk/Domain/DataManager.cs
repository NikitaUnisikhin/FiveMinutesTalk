using FiveMinutesTalk.Domain.Entities;
using FiveMinutesTalk.Domain.Entities.QuestionsTypes;
using FiveMinutesTalk.Domain.Entities.Repositories.Abstract;

namespace FiveMinutesTalk.Domain;

public class DataManager
{
    public IRepository<Question> Questions { get; set; }
    public IRepository<Quiz> Quizzes { get; set; }
    public IRepository<QuizQuestion> QuizQuestions { get; set; }
    public IRepository<QuestionAnswer> QuestionAnswers { get; set; }

    public DataManager(IRepository<Question> questions, IRepository<Quiz> quizzes, 
        IRepository<QuizQuestion> quizQuestions, IRepository<QuestionAnswer> questionAnswers)
    {
        Questions = questions;
        Quizzes = quizzes;
        QuizQuestions = quizQuestions;
        QuestionAnswers = questionAnswers;
    }
}