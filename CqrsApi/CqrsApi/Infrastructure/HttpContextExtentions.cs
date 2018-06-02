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
    }
}