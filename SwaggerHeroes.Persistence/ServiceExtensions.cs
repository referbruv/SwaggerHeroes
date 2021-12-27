using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwaggerHeroes.Core.Data.Services;
using SwaggerHeroes.Persistence.Data.Services;

namespace SwaggerHeroes.Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDataService, DataService>();
            return services.AddSqlite<HeroesContext>(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
