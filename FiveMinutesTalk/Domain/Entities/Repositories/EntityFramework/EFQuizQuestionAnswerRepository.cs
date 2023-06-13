using FiveMinutesTalk.Domain.Entities.Repositories.Abstract;

namespace FiveMinutesTalk.Domain.Entities.Repositories.EntityFramework;

public class EFQuizQuestionAnswerRepository : IRepository<QuizQuestionAnswer>
{
    private readonly AppDbContext context;

    public EFQuizQuestionAnswerRepository(AppDbContext context)
    {
        this.context = context;
    }
    
    public IQueryable<QuizQuestionAnswer> GetItems()
    {
        return context.QuizQuestionAnswers;
    }

    public QuizQuestionAnswer GetItemById(Guid id)
    {
        return context.QuizQuestionAnswers
            .FirstOrDefault(x => x.Id == id);
    }
    
    public Guid[] GetQuestionAnswerIdsByQuizAnswerId(Guid id)
    {
        return context.QuizQuestionAnswers
            .Where(x => x.QuizAnswerId == id)
            .Select(x => x.QuestionAnswerId)
            .ToArray();
    }

    public void SaveItem(QuizQuestionAnswer entity)
    {
        context.Add(entity);
        context.SaveChanges();
    }

    public void DeleteItem(Guid id)
    {
        context.QuizQuestionAnswers.Remove(new QuizQuestionAnswer()
        {
            Id = id
        });
        context.SaveChanges();
    }
   
}