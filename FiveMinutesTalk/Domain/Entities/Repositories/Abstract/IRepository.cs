namespace FiveMinutesTalk.Domain.Entities.Repositories.Abstract;

public interface IRepository<T>
{
    IQueryable<T> GetItems();
    T GetItemById(Guid id);
    void SaveItem(T entity);
    void DeleteItem(Guid id);
}