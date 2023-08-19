using RoutingExample.CustomConstraint;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
});
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("map1/{id:int}", async (context) =>
    {
        var id = context.Request.RouteValues["id"];
        await context.Response.WriteAsync($"id: {id}");
    });

    endpoints.MapPost("postOnly", async (context) =>
    {
        
        await context.Response.WriteAsync("This a post route only");
    });

    endpoints.MapGet("someMonths/{month:months}", async (context) =>
    {
        var month = context.Request.RouteValues["month"];
        await context.Response.WriteAsync($"This one matches for some months: {month}");
    });
    endpoints.Map("files/{name=default}", async (context) =>
    {
        var name = context.Request.RouteValues["name"];
        await context.Response.WriteAsync($"name:{name}");
    });
    endpoints.Map("/", async (context) =>
    {
        await context.Response.WriteAsync("empty1!!");
    });
});
app.Run(async context =>
{
    await context.Response.WriteAsync("empty2");
});

app.Run();
