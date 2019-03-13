using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood_home.Services;

namespace OdeToFood_home
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            IGreeter greeter, 
            ILogger<Startup> logger
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc(r=> r.MapRoute("Default","{controller=Home}/{action=Restaurants}/{id?}"));
            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        logger.LogInformation("Request incoming");
            //        if (context.Request.Path.StartsWithSegments("/mymiddleware"))
            //        {
            //            await context.Response.WriteAsync("Handeld before middle ware in the pipeline");
            //            logger.LogInformation("Request handeld");
            //        }
            //        else
            //        {
            //            await next(context);
            //            logger.LogInformation("Request forward");

            //        }
            //    };
            //});

            app.UseWelcomePage(new WelcomePageOptions()
            {
                Path = "/welcome"
            });

            app.Run(async (context) =>
            { 
                //greeter = null; //Uncommend if you want to see the development error page!
                var greeting = greeter.GetMessageOfTheDay();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not found!");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routerBuilder)
        {
            // /Home/Index
            //routerBuilder.MapRoute("Default", "{controller=Home}/{action=RestaurantGreeterView}");
           routerBuilder.MapRoute("Default", "{controller=Home}/{action=Restaurants}/{id?}");
        }
    }
}
