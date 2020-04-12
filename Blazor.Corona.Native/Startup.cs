using Blazor.Corona.Configuration;
using Blazor.Corona.DAL.Infrastructure;
using Blazor.Corona.View;
using Blazor.Corona.View.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using System.IO;
using WebWindows.Blazor;

namespace Blazor.Corona.Native
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            services.AddDbContext<CoronaContext>(options =>
                    options.UseSqlServer
                    (
                       configuration.GetConnectionString("DefaultConnection")
                        //"Server=localhost;Database=corona;Trusted_Connection=True;MultipleActiveResultSets=true"
                    ).EnableSensitiveDataLogging()
                , ServiceLifetime.Transient);

            services.AddHttpContextAccessor();

            //Corona 서비스 초기 설정
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

        public void Configure(DesktopApplicationBuilder app)
        {
            app.AddComponent<CoronaView>("app");
        }
    }
}
