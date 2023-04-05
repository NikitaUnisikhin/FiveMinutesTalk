namespace FiveMinutesTalk.Models;

public class QuestionModel
{
    public int Id { get; set; }
    public int Number { get; set; }
    // public int Type { get; set; }
    public int QuizId { get; set; }
    public required string Text { get; set; }
    // public List<string>? Answers { get; set; }
    // public List<string>? CorrectAnswers { get; set; }
}