var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run(); 

