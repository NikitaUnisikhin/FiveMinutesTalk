using System.ComponentModel.DataAnnotations;

namespace FiveMinutesTalk.Domain.Entities.QuestionsTypes;

public abstract class QuestionBase : EntityBase
{
    [Required] public virtual string Text { get; set; } = "Текст вопроса";

    public virtual string[] CorrectAnswers { get; set; } = Array.Empty<string>();
}