using Blazor.Corona.Configuration;
using Blazor.Corona.DAL.Infrastructure;
using Blazor.Corona.View.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prism.Events;

namespace Blazor.Corona.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDbContext<CoronaContext>(options =>
                    options.UseSqlServer
                    (
                       Configuration.GetConnectionString("DefaultConnection")
                    ).EnableSensitiveDataLogging()
                , ServiceLifetime.Transient);

            services.AddHttpContextAccessor();

            //Corona Configuration init
            services.AddCoronaInit();

            services.AddScoped<CurrentStateViewModel>();
            services.AddScoped<LocalStateViewModel>();
            services.AddScoped<AnnounceCoronaInfoViewModel>();
            services.AddScoped<CoronaTermsInfoViewModel>();
            services.AddScoped<IndexViewModel>();
            services.AddScoped<IndexPopupViewModel>();

            //EventAggregator 등록
            services.AddScoped<IEventAggregator, EventAggregator>();
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
