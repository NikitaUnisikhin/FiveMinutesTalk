using System.ComponentModel.DataAnnotations;

namespace FiveMinutesTalk.Domain.Entities.QuestionsTypes;

public enum QuestionTypeEnum
{
    OpenQuestion,
    Code,
    MultipleAnswersQuestion,
    Radio
}