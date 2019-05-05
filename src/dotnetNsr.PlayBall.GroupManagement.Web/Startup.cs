using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using dotnetNsr.PlayBall.GroupManagement.Business.Implementation.Services;
using dotnetNsr.PlayBall.GroupManagement.Business.Services;
using dotnetNsr.PlayBall.GroupManagement.Web.Demo.Filters;
using dotnetNsr.PlayBall.GroupManagement.Web.IoC;
using dotnetNsr.PlayBall.GroupManagement.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dotnetNsr.PlayBall.GroupManagement.Web
{
    public class Startup
    {
        private readonly IConfiguration _config;
        
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add<DemoActionFilter>();
            });
            
            services.AddTransient<DemoExceptionFilter>();
            services.AddBusiness();
        }
  
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMiddleware<RequestTimingAdHoc>();
            
            app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("X-Powered-By", "dotnet-nsr");
                    return Task.CompletedTask;
                });
                
                await next.Invoke();
            });
            
            
            app.UseMvc();
        }
    }
}
