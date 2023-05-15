using System.ComponentModel.DataAnnotations;

namespace FiveMinutesTalk.Domain.Entities.QuestionsTypes;

public enum QuestionTypeEnum
{
    [Display(Name = "Текст")]
    OpenQuestion,
    [Display(Name = "Несколько из списка")]
    MultipleAnswersQuestion
}