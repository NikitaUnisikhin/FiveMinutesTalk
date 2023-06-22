using FiveMinutesTalk.Domain.Entities.Repositories.Abstract;

namespace FiveMinutesTalk.Domain.Entities.Repositories.EntityFramework;

public class EFQuizzesRepository : IRepository<Quiz>
{
    private readonly AppDbContext context;

    public EFQuizzesRepository(AppDbContext context)
    {
        this.context = context;
    }
    
    public IQueryable<Quiz> GetItems()
    {
        return context.Quizzes;
    }

    public Quiz GetItemById(Guid id)
    {
        return context.Quizzes
            .FirstOrDefault(x => x.Id == id);
    }
    
    public Quiz[] GetItemsByOwnerId(Guid id)
    {
        return context.Quizzes
            .Where(x => x.OwnerId == id)
            .ToArray();
    }

    public void SaveItem(Quiz entity)
    {
        context.Add(entity);
        context.SaveChanges();
    }

    public void DeleteItem(Guid id)
    {
        context.Quizzes.Remove(new Quiz()
        {
            Id = id
        });
        context.SaveChanges();
    }
}