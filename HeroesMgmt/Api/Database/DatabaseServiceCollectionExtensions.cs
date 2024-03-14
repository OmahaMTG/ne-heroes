using Heros.Database;
using Microsoft.EntityFrameworkCore;

namespace Api.Database
{
    internal static class DatabaseServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPooledDbContextFactory<HeroDbContext>(opt =>
            {
                var connectionString = configuration["ConnectionString"];
                opt.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}
