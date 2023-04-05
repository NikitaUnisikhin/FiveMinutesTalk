namespace FiveMinutesTalk.Models;

public class Question
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int Type { get; set; }
    public int SurveyId { get; set; }
    public required string Text { get; set; }
    public List<string>? Answers { get; set; }
    public List<string>? CorrectAnswers { get; set; }
}