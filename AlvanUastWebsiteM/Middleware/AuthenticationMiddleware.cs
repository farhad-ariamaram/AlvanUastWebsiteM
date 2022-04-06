using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AlvanUastWebsiteM.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var scheme = httpContext.Request.Scheme;
            if (scheme.EndsWith("s"))
            {
                httpContext.Response.Redirect("http://new.alvan-uast.ir");
            }


            var path = httpContext.Request.Path;

            if ((path.HasValue) &&
                (path.Value.ToLower().Contains("customize")) &&
                (path.Value.ToLower() != "/customize/") &&
                (path.Value.ToLower() != "/customize/index"))
            {
                if (httpContext.Session.GetString("uid") == null)
                {
                    httpContext.Response.Redirect("/Customize/Index");
                }
            }

            return _next(httpContext);
        }
    }

    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
