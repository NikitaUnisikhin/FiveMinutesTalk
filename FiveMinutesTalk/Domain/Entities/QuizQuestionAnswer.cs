using Microsoft.Build.Framework;

namespace FiveMinutesTalk.Domain.Entities;

public class QuizQuestionAnswer : EntityBase
{
    [Required] public Guid QuizAnswerId { get; set; }

    [Required] public Guid QuestionAnswerId { get; set; }
}