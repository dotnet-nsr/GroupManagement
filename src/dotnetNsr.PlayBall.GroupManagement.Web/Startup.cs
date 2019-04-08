using System.Threading.Tasks;
using dotnetNsr.PlayBall.GroupManagement.Business.Implementation.Services;
using dotnetNsr.PlayBall.GroupManagement.Business.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace dotnetNsr.PlayBall.GroupManagement.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IGroupsService, InMemoryGroupsService>();
        }
  
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            
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
