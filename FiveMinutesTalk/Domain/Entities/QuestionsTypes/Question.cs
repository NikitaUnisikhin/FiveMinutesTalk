using System.ComponentModel.DataAnnotations;

namespace FiveMinutesTalk.Domain.Entities.QuestionsTypes;

public class Question : QuestionBase
{
    [Required]
    public QuestionTypeEnum Type { get; set; }
    
    public string[] AnswerOptions { get; set; } = Array.Empty<string>();
}