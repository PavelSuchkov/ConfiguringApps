
using ConfiguringApps.Infrastructure;

namespace PartyInvites
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IRepository, EFRepository>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddSingleton<UptimeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.UseDeveloperExceptionPage();
            // app.UseStatusCodePages();
            // app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMiddleware<ErrorMiddleware>();
            app.UseMiddleware<BrowserTypeMiddleware>();
            app.UseMiddleware<ShortCircuitMiddleware>();
            app.UseMiddleware<ContentMiddleware>();
        }
    }
}