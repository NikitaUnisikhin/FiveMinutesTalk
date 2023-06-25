using FiveMinutesTalk.Domain.Entities.Repositories.Abstract;

namespace FiveMinutesTalk.Domain.Entities.Repositories.EntityFramework;

public class EFQuestionAnswersRepository : IRepository<QuestionAnswer>
{
    private readonly AppDbContext context;

    public EFQuestionAnswersRepository(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<QuestionAnswer> GetItems()
    {
        return context.QuestionAnswers;
    }

    public QuestionAnswer GetItemById(Guid id)
    {
        return context.QuestionAnswers
            .FirstOrDefault(x => x.Id == id);
    }

    public Guid[] GetQuestionAnswerIdByQuizId(Guid id)
    {
        return context.QuestionAnswers
            .Where(x => x.QuizId == id)
            .Select(x => x.Id)
            .ToArray();
    }

    public void SaveItem(QuestionAnswer entity)
    {
        context.Add(entity);
        context.SaveChanges();
    }

    public void DeleteItem(Guid id)
    {
        context.QuestionAnswers.Remove(new QuestionAnswer()
        {
            Id = id
        });
        context.SaveChanges();
    }
}