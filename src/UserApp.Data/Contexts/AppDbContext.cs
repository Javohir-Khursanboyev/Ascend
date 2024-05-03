using Microsoft.EntityFrameworkCore;
using UserApp.Domain.Enitites.Commons;
using UserApp.Domain.Enitites.Users;

namespace UserApp.Data.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options): base(options) {  }

    public DbSet<User> Users { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
}