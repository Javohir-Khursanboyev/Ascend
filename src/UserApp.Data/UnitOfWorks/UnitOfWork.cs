using UserApp.Data.Contexts;
using UserApp.Data.Repositories;
using UserApp.Domain.Enitites.Users;
using UserApp.Domain.Enitites.Commons;

namespace UserApp.Data.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    public IRepository<User> Users { get; }

    public IRepository<Asset> Assets { get; }

    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
        Users = new Repository<User>(context);
        Assets = new Repository<Asset>(context);
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}