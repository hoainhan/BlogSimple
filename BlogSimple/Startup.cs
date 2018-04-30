using Autofac;
using Autofac.Extensions.DependencyInjection;
using BlogSimple.Model;
using BlogSimple.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using BlogSimple.Helpers;

namespace BlogSimple
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);
            //Add Mvc
            services.AddMvc();

           //add connection string
            services.AddDbContext<BlogSimpleContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

           //Load appsetting to blogsimple config
            services.ConfigureStartupConfig<BlogSimpleConfig>(Configuration.GetSection("BlogSimple"));

            //Config DI & IOC
            return new AutofacServiceProvider(RegisterModules.RegisterModule(services));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Admin", action = "Index" });
            });
        }
    }
}
