using Blazor.Corona.DAL.Interfaces;
using Blazor.Corona.DAL.Repositories;
using Blazor.Corona.Services.Interfaces;
using Blazor.Corona.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Blazor.Corona.Configuration
{
    public static class LocalCoronaExtension
    {
        public static IServiceCollection AddCoronaInit(this IServiceCollection services)
        {
            //Repository 등록
            services.AddTransient<ICoronaStatusInfoRepository, CoronaStatusInfoRepository>();
            services.AddTransient<ICoronaStatusForLocalRepository, CoronaStatusForLocalRepository>();
            services.AddTransient<IBoard195Repository, Board195Repository>();
            services.AddTransient<IBoard196Repository, Board196Repository>();

            //Service 등록
            services.AddTransient<ICoronaStatusInfoService, CoronaStatusInfoService> ();
            services.AddTransient<ICoronaStatusForLocalService, CoronaStatusForLocalService>();
            services.AddTransient<IBoard195Service, Board195Service>();
            services.AddTransient<IBoard196Service, Board196Service>();

            return services;
        }
    }
}
