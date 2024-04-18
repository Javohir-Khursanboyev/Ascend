using UserApp.Data.Repositories;
using UserApp.Domain.Enitites.Users;
using UserApp.Domain.Enitites.Commons;

namespace UserApp.Data.UnitOfWorks;

public interface IUnitOfWork:IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Asset> Assets { get; }
}