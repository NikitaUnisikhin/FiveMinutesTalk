using FiveMinutesTalk.Domain.Entities.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

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

    public void SaveItem(Quiz entity)
    {
        context.Entry(entity).State = entity.Id == default ? 
            EntityState.Added : EntityState.Modified;
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