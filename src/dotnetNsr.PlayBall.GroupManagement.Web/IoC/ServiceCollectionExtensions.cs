using System;
using dotnetNsr.PlayBall.GroupManagement.Business.Implementation.Services;
using dotnetNsr.PlayBall.GroupManagement.Business.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Remotion.Linq.Clauses.ResultOperators;

namespace dotnetNsr.PlayBall.GroupManagement.Web.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            //services.AddSingleton<IGroupsService, InMemoryGroupsService>();

            services.AddScoped<IGroupsService, GroupsService>();
            
            return services;
        }

        public static TConfig ConfigurePoco<TConfig>(this IServiceCollection services, IConfiguration configuration)
            where TConfig : class, new()
        {
            if (services is null) throw new ArgumentNullException(nameof(services));
            if (configuration is null) throw new ArgumentNullException(nameof(services));

            var config = new TConfig();
            configuration.Bind(config);
            services.AddSingleton(config);
            return config;
        }
    }
}