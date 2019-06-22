using Microsoft.Extensions.DependencyInjection;
using FootballRankings.Business.Interfaces;
using FootballRankings.Business.Services;

namespace FootballRankings.Api.Configurations
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
