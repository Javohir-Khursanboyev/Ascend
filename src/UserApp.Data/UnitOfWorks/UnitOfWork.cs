using Microsoft.EntityFrameworkCore.Storage;
using UserApp.Data.Contexts;
using UserApp.Data.Repositories;
using UserApp.Domain.Enitites.Commons;
using UserApp.Domain.Enitites.Users;

namespace UserApp.Data.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    private IDbContextTransaction transaction;
    public IRepository<User> Users { get; }

    public IRepository<Asset> Assets { get; }

    public IRepository<Role> Roles {  get; }

    public IRepository<Permission> Permissions {  get; }

    public IRepository<RolePermission> RolePermissions {  get; }

    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
        Users = new Repository<User>(context);
        Assets = new Repository<Asset>(context);
        Roles = new Repository<Role>(context);
        Permissions = new Repository<Permission>(context);
        RolePermissions = new Repository<RolePermission>(context);
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
    public async Task BeginTransactionAsync()
    {
        transaction = await context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await transaction.CommitAsync();
    }
}