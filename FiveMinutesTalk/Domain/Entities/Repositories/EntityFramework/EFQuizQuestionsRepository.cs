using FiveMinutesTalk.Domain.Entities.QuestionsTypes;
using FiveMinutesTalk.Domain.Entities.Repositories.Abstract;
using Microsoft.Build.Experimental.ProjectCache;

namespace FiveMinutesTalk.Domain.Entities.Repositories.EntityFramework;

public class EFQuizQuestionsRepository : IRepository<QuizQuestion>
{
    private readonly AppDbContext context;

    public EFQuizQuestionsRepository(AppDbContext context)
    {
        this.context = context;
    }
    
    public IQueryable<QuizQuestion> GetItems()
    {
        return context.QuizQuestions;
    }

    public Guid[] GetQuestionsIdByQuizId(Guid id)
    {
        return context.QuizQuestions
            .Where(x => x.QuizId == id)
            .Select(x => x.QuestionId)
            .ToArray();
    }
    
    public QuizQuestion GetItemById(Guid id)
    {
        return context.QuizQuestions
            .FirstOrDefault(x => x.Id == id);
    }

    public void SaveItem(QuizQuestion entity)
    {
        context.Add(entity);
        context.SaveChanges();
    }

    public void DeleteItem(Guid id)
    {
        context.QuizQuestions.Remove(new QuizQuestion()
        {
            Id = id
        });
        context.SaveChanges();
    }
   
}