using FiveMinutesTalk.Domain.Entities.QuestionsTypes;

namespace FiveMinutesTalk.Domain;

public class StatisticsContainer
{
    public QuestionTypeEnum QuestionType { get; set; }
    public List<string> Answers = new();
}