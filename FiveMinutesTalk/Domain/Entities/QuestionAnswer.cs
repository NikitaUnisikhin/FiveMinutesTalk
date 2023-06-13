using FiveMinutesTalk.Domain.Entities.QuestionsTypes;

namespace FiveMinutesTalk.Domain.Entities;

public class QuestionAnswer
{
    public Guid Id { get; set; }
    public Guid QuizId { get; set; }
    public Guid QuestionId { get; set; }
    public QuestionTypeEnum QuestionType { get; set; }
    public string[] Answers { get; set; } = Array.Empty<string>();
}