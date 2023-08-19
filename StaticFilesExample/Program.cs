var builder = WebApplication.CreateBuilder(new WebApplicationOptions(){WebRootPath ="files"});
var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync("Here is a file!");
    });
});


app.Run();
