var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseRouting();

var countries = new List<String> { "United States", "Canada", "United Kingdom", "India", "Japan" };

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/countries", async (context) =>
    {
        for (int i = 0; i < countries.Count; i++)
        {
            await context.Response.WriteAsync($"{i+1}, {countries[i]}\n");
        }
       
    });

    endpoints.MapGet("/countries/{id:int}", async (context) =>
    { 
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);


        if (id < 1 || id > 100)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("The CountryID should be between 1 and 100");
          
            return;
        }

        if(id >= countries.Count)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("[No Country]");

            return;

        }
        var country = countries[id - 1];

        if (country != null)
        {
            await context.Response.WriteAsync($"{id}, {country}\n");
        }

    });


    endpoints.Map("/", async (context) =>
    {
        await context.Response.WriteAsync("Use the /countries route");
    });
});



app.Run();
