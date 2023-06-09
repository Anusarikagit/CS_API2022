using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CS_API2022.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private const string apiKeyPropertyName = "ApiKey";


        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (!httpContext.Request.Headers.TryGetValue(apiKeyPropertyName, out var extractedApiKey))
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("api key is not present");
                return;
            }
            var appSetting = httpContext.RequestServices.GetRequiredService<IConfiguration>();
            var key = appSetting.GetValue<string>(apiKeyPropertyName);

            if (!key.Equals(extractedApiKey))
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("api key is not valid");
                return;
            }
            await _next(httpContext);


        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class AuthorizationMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseAuthorizationMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<AuthorizationMiddleware>();
    //    }
    //}
}
