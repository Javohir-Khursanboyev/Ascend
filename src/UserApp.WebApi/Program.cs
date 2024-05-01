using Microsoft.EntityFrameworkCore;
using UserApp.Data.Contexts;
using UserApp.Service.Mappers;
using UserApp.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDbConnection")));

builder.Services.AddExceptionHandlers();
builder.Services.AddProblemDetails();

builder.Services.ConfigureSwagger();
builder.Services.AddJwtService(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddServices();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.InjectEnvironmentItems();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

app.Run();