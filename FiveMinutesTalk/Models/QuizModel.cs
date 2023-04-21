namespace FiveMinutesTalk.Models;

public class QuizModel
{
    public int Id { get; set; }
    // public DateTime LastModified { get; set; }
    // public TimeOnly Duration { get; set; }
    public required string Name { get; set; }

    public required List<QuestionModel> Questions { get; set; } = new List<QuestionModel>()
    {
        new QuestionModel(){Id = 1, Text = "sss"},
        new QuestionModel(){Id = 2, Text = "ssss"}
    };
    // public required string Description { get; set; }
    // public int AuthorId { get; set; }
}