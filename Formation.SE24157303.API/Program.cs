using Formation.SE24157303.DAL;
using Formation.SE24157303.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
builder.Services.AddScoped<IClientService, ClientService>();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Optionnel, pour voir les logs dans la console
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) // Fichier texte journalier
    .CreateLogger();

builder.Host.UseSerilog();


var salesDbConnectionString = builder.Configuration.GetConnectionString("SalesDbConnection");
builder.Services
    .AddDbContext<SalesContext>(
    c => c
    .UseSqlServer(salesDbConnectionString));


var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();


app.UseAuthorization();

app.MapControllers();

app.Run();
