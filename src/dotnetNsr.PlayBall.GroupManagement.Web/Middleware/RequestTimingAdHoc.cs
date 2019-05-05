using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace dotnetNsr.PlayBall.GroupManagement.Web.Middleware
{
    public class RequestTimingAdHoc
    {
        private readonly RequestDelegate _next;

        public RequestTimingAdHoc(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger<RequestTimingAdHoc> logger)
        {
            var watch = Stopwatch.StartNew();
            await _next(context);
            watch.Stop();
            logger.LogTrace($"Request took {watch.ElapsedMilliseconds} ms");
        }
        
    }
}