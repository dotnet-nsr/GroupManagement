using dotnetNsr.PlayBall.GroupManagement.Web.Model;
using Microsoft.AspNetCore.Mvc.Filters;

namespace dotnetNsr.PlayBall.GroupManagement.Web.Demo.Filters
{
    public class DemoActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("model", out var model) 
                && model is GroupViewModel group 
                && group.Id == 1)
            {
                group.Name += $"Added on {nameof(DemoActionFilterAttribute)}";
            }
        }
    }
}