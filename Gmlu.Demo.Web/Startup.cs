using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Gmlu.Demo.EntityFramework.DataContext;
using Gmlu.Demo.Web.Services;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using Gmlu.Demo.Web.Jobs;

namespace Gmlu.Demo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StatsContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("StatsDb")));

            services.AddHangfire(
                config => config.UseSqlServerStorage(Configuration["ConnectionStrings:HangfireConnection"]));

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            services.AddScoped<IStatsService, StatsServiceDb>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseHangfireServer();
            app.UseHangfireDashboard();

            RecurringJob.AddOrUpdate<RaspberrySyncJob>("RaspberrySyncJob", job => job.Run(), "0 0 */1 * *");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
