using MiddlewareExample;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient <MyCustomMiddleware>();
var app = builder.Build();

// middleware 1
app.Use(async ( context, next) =>
{
    await context.Response.WriteAsync("Hello");
    await next(context);

});

// middleware 2a & 2b
app.UseMyCustomMiddleWare();
app.UseMiddleware();



// middleware 3
app.UseWhen(context => context.Request.Method == "POST",
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync(" This is a POST");
            await next(context);
        });
    }
    );
app.Run(async (context) =>
{
    await context.Response.WriteAsync(" 31");
    
});

app.Run();
