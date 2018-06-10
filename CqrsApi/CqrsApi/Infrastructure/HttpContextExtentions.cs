using Microsoft.AspNetCore.Http;

namespace CqrsApi.Infrastructure
{
    public static class HttpContextExtentions
    {
        public static string RequestedUrl(this HttpContext context)
        {
            var request = context.Request;
            return $"{request.Scheme}://{request.Host}{request.PathBase}{request.Path}{request.QueryString}";
        }

        public static string GetHref(this HttpContext context, int id)
        {
            var request = context.Request;
            return $"{request.Scheme}://{request.Host}{request.PathBase}{request.Path}/{id}";
        }

        public static string GetHrefSelf(this HttpContext context)
        {
            var request = context.Request;
            return $"{request.Scheme}://{request.Host}{request.PathBase}{request.Path}";
        }
    }
}