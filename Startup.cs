
using ConfiguringApps.Infrastructure;

namespace PartyInvites
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<UptimeService>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            // services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseBrowserLink();
                // app.UseMiddleware<ErrorMiddleware>();
                // app.UseMiddleware<BrowserTypeMiddleware>();
                // app.UseMiddleware<ShortCircuitMiddleware>();
                // app.UseMiddleware<ContentMiddleware>();
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
            });
        }
    }
}

// app.UseMiddleware<ErrorMiddleware>();
// app.UseMiddleware<BrowserTypeMiddleware>();
// app.UseMiddleware<ShortCircuitMiddleware>();
// app.UseMiddleware<ContentMiddleware>();