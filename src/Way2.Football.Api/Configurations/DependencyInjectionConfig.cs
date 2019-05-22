using Microsoft.Extensions.DependencyInjection;
using Way2.FootballRankings.Business.Interfaces;
using Way2.FootballRankings.Business.Services;

namespace Way2.FootballRankings.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IFootballDataService, FootballDataService>();
            return services;
        }
    }
}
