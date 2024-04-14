using ConfigurationExample;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("weatherapi"));
var app = builder.Build();

builder.Configuration.AddJsonFile("custom.json", optional: true, reloadOnChange: true);

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.Map("/config", async context =>
    {
        await context.Response.WriteAsync(app.Configuration["MyKey1"] ?? "MyKey not found");

        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey") ?? "MyKey not found");
    });
});

app.MapControllers();


app.Run();
