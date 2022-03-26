using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ALLMVC.CustomMiddlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public MyCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var url = httpContext.Request.Path.Value;
            if (url.Contains("/AllView/google"))
            {
                httpContext.Response.Redirect("https://www.google.com");
                
            }
            else if (url.Contains("/AllView/facebook"))
            {
                httpContext.Response.Redirect("https://www.facebook.com");
            }
            else if (url.Contains("/AllView/linkedin"))
            {
                httpContext.Response.Redirect("https://in.linkedin.com");
            }
            else if (url.Contains("/AllView/youtube"))
            {
                httpContext.Response.Redirect("https://www.youtube.com");
            }
            else if (url.Contains("/AllView/twitter"))
            {
                httpContext.Response.Redirect("https://twitter.com");
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
