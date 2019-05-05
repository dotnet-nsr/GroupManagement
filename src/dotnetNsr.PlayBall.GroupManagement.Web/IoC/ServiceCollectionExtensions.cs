using dotnetNsr.PlayBall.GroupManagement.Business.Implementation.Services;
using dotnetNsr.PlayBall.GroupManagement.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Remotion.Linq.Clauses.ResultOperators;

namespace dotnetNsr.PlayBall.GroupManagement.Web.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddSingleton<IGroupsService, InMemoryGroupsService>();
            
            return services;
        }
    }
}