using System.ComponentModel.DataAnnotations;

namespace FiveMinutesTalk.Domain.Entities;

public class QuizQuestion : EntityBase
{
    [Required]
    public Guid QuizId { get; set; }
    
    [Required]
    public Guid QuestionId { get; set; }
}