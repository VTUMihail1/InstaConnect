using System.Linq.Expressions;

namespace InstaConnect.Data.Abstraction.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> FindEntityAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllFilteredAsync(Expression<Func<T, bool>> expression);
        Task UpdateAsync(T entity);
    }
}