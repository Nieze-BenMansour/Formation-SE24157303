using Formation.SE24157303.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
builder.Services
    .AddDbContext<SalesContext>(
    c => c
    .UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SalesDb;Data Source=LAPTOP-UR7S8C4K;Encrypt=False;"));


var app = builder.Build();

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
