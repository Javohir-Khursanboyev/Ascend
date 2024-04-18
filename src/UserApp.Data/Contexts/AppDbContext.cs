using UserApp.Domain.Enitites.Users;
using UserApp.Domain.Enitites.Commons;
using Microsoft.EntityFrameworkCore;

namespace UserApp.Data.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options): base(options) {  }

    public DbSet<User> Users { get; set; }
    public DbSet<Asset> Assets { get; set; }
}