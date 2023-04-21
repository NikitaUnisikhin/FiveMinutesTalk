using FiveMinutesTalk.Models;

namespace FiveMinutesTalk.Quizes;

public class Quiz
{
    public List<QuestionModel> Questions = new();

    public Quiz(IEnumerable<QuestionModel> questions)
    {
        Questions.AddRange(questions);
    }
    
    public Quiz(QuestionModel questions)
    {
        Questions.Add(questions);
    }
}