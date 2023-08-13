var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) => {

    var reader = new StreamReader (context.Request.Body);
    var body = await reader.ReadToEndAsync();
    var obj = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
    if (obj.ContainsKey("firstname"))
    {
        await context.Response.WriteAsync(obj["firstname"]);
    }
    

});

app.Run();
