using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using stoktakip.data;
using stoktakip.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace stoktakip
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext,stoktakipDBContext db)
        {
            string role = "0";
            if (httpContext.Session.GetString("role") != null)
            {
                role = httpContext.Session.GetString("role");
            }
            var rd = httpContext.GetRouteData();
            var path = rd.Values["controller"] + "/" + rd.Values["action"];
            var urlList = db.permission.Where(m => m.RoleID == int.Parse(role)).Select(m => m.URLid).ToList();
            var urlVar = db.url.Where(m => urlList.Contains(m.ID) && m.URL.Equals(path)).Any();
            if (!urlVar)
            {
                if (!httpContext.Request.Path.ToString().StartsWith("/errors"))
                    httpContext.Response.Redirect("/errors/403");
            }
            return _next(httpContext);
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
