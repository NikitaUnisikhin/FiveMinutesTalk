using FiveMinutesTalk.Domain.Entities.QuestionsTypes;
using Microsoft.Build.Framework;

namespace FiveMinutesTalk.Models;

public class QuestionAnswerModel
{
    public string[] Answers { get; set; } = Array.Empty<string>();
}