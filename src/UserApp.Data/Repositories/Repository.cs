using UserApp.Data.Contexts;
using UserApp.Domain.Commons;

namespace UserApp.Data.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly AppDbContext context;

    public Repository(AppDbContext context)
    {
        this.context = context;
    }
    public Task<T> DeleteAcync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> DropAcync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> InsertAcync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> SelectAcync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> SelectAllAsEnumerableAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<T>> SelectAllAsQueryable(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAcync(T entity)
    {
        throw new NotImplementedException();
    }
}