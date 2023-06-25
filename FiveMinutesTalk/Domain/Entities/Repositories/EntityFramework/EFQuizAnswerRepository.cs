using FiveMinutesTalk.Domain.Entities.Repositories.Abstract;

namespace FiveMinutesTalk.Domain.Entities.Repositories.EntityFramework;

public class EFQuizAnswerRepository : IRepository<QuizAnswer>
{
    private readonly AppDbContext context;

    public EFQuizAnswerRepository(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<QuizAnswer> GetItems()
    {
        return context.QuizAnswers;
    }

    public QuizAnswer GetItemById(Guid id)
    {
        return context.QuizAnswers
            .FirstOrDefault(x => x.Id == id);
    }

    public Guid[] GetQuizAnswerIdByQuizId(Guid id)
    {
        return context.QuizAnswers
            .Where(x => x.QuizId == id)
            .Select(x => x.Id)
            .ToArray();
    }

    public void SaveItem(QuizAnswer entity)
    {
        context.Add(entity);
        context.SaveChanges();
    }

    public void DeleteItem(Guid id)
    {
        context.QuizAnswers.Remove(new QuizAnswer()
        {
            Id = id
        });
        context.SaveChanges();
    }
}