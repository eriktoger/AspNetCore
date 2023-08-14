namespace MiddlewareExample
{
    public class MyCustomMiddleware : IMiddleware

    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync(" From extended middleware");
            await next(context);
        }
    }

    public static class MyCustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleWare(this IApplicationBuilder app )
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}