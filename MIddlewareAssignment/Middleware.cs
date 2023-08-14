using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MiddlewareAssignment
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var isGet = httpContext.Request.Method == "GET";
            var isPassword = httpContext.Request.Query.ContainsKey("password");
            var isUsername = httpContext.Request.Query.ContainsKey("username");
            
            if (isGet && isPassword && isUsername)
            {
                httpContext.Response.StatusCode = 202;
                await httpContext.Response.WriteAsync("Yes you did!\n");
              
            }else
            {
                await httpContext.Response.WriteAsync("Did you send password and username?\n");

            }

           await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
