using UserApp.Data.Repositories;
using UserApp.Domain.Enitites.Users;
using UserApp.Domain.Enitites.Commons;

namespace UserApp.Data.UnitOfWorks;

public interface IUnitOfWork:IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Asset> Assets { get; }
    IRepository<Role> Roles { get; }
    IRepository<Permission> Permissions { get; }
    Task<bool> SaveAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
}