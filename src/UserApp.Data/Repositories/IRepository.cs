using UserApp.Domain.Commons;

namespace UserApp.Data.Repositories;

public interface IRepository<T> where T : Auditable
{
    Task<T> InsertAcync(T entity);
    Task<T> UpdateAcync(T entity);
    Task<T> DeleteAcync(T entity);
    Task<T> DropAcync(T entity);
    Task<T> SelectAcync(long id);
    Task<IEnumerable<T>> SelectAllAsEnumerableAsync(T entity);
    Task<IQueryable<T>> SelectAllAsQueryable(T entity);
}