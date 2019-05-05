using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace dotnetNsr.PlayBall.GroupManagement.Web.Demo.Filters
{
    public class DemoActionFilter : IActionFilter
    {
        private readonly ILogger<DemoActionFilter> _logger;

        public DemoActionFilter(ILogger<DemoActionFilter> logger)
        {
            _logger = logger;
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"Before executing action {context.ActionDescriptor.DisplayName} with arguments {context.ActionArguments}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"After executing action {context.ActionDescriptor.DisplayName}");
        }
    }
}