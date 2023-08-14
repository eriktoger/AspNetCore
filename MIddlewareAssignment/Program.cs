using MiddlewareAssignment;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.UseMiddleware();
app.Run(async context =>
{
  
});
app.Run();
