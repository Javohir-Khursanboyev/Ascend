using UserApp.Data.Contexts;
using UserApp.Service.Helpers;
using UserApp.Service.Mappers;
using UserApp.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddServices();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

HttpContextHelper.ContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
EnvironmentHelper.WebRootPath = Path.GetFullPath("wwwroot");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
