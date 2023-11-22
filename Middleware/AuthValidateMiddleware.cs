using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthValidateMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthValidateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/Admin")
                || httpContext.Request.Path.StartsWithSegments("/Category")
                || httpContext.Request.Path.StartsWithSegments("/Article")
            )
            {
                if (httpContext.User.HasClaim("Is_Admin", "false"))
                {
                    httpContext.Response.Redirect("/Auth/Login");
                }
            }
            _next(httpContext).GetAwaiter().GetResult();
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthValidateMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthValidateMiddleware>();
        }
    }
}
