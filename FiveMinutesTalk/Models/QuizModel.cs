namespace FiveMinutesTalk.Models;

public class QuizModel
{
    public required string Id { get; set; }
    // public DateTime LastModified { get; set; }
    // public TimeOnly Duration { get; set; }
    public required string Name { get; set; }
    public required List<QuestionModel> Questions { get; set; }
    // public required string Description { get; set; }
    // public int AuthorId { get; set; }
}