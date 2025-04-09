using System.Text.Json.Serialization;
using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}); ;




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionstring = builder.Configuration.GetConnectionString("ConnectionString");

builder.Services.AddDbContext<FootballLeagueDbContext>(options =>
{
    options.UseSqlServer("Server=localhost,1433;Database=efcore;User Id=sa;Password=ragh2404;TrustServerCertificate=True;")
               .UseLazyLoadingProxies()
               // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
               .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors();
});


//builder.Services.AddDbContext<>

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

