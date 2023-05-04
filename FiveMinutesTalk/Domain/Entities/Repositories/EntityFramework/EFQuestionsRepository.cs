using FiveMinutesTalk.Domain.Entities.QuestionsTypes;
using FiveMinutesTalk.Domain.Entities.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FiveMinutesTalk.Domain.Entities.Repositories.EntityFramework;

public class EFQuestionsRepository : IRepository<Question>
{
    private readonly AppDbContext context;

    public EFQuestionsRepository(AppDbContext context)
    {
        this.context = context;
    }
    
    public IQueryable<Question> GetItems()
    {
        return context.Questions;
    }

    public Question GetItemById(Guid id)
    {
        return context.Questions
            .FirstOrDefault(x => x.Id == id);
    }

    public void SaveItem(Question entity)
    {
        context.Entry(entity).State = entity.Id == default ? 
            EntityState.Added : EntityState.Modified;
        context.SaveChanges();
    }

    public void DeleteItem(Guid id)
    {
        context.Questions.Remove(new Question()
        {
            Id = id
        });
        context.SaveChanges();
    }
}