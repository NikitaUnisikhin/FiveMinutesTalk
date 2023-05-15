using FiveMinutesTalk.Domain.Entities.QuestionsTypes;
using FiveMinutesTalk.Domain.Entities.Repositories.Abstract;

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
        context.Add(entity);
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