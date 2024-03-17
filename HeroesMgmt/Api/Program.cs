using Api.Database;
using Heros.Database;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Query
    {
        [UseFiltering]
        public IQueryable<Hero> GetHeroes(HeroDbContext dbContext)
        {
            return dbContext.Heroes;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddDatabase(builder.Configuration);

            builder.Services.AddControllers();
            builder.Services.AddGraphQLServer()
                .RegisterDbContext<HeroDbContext>(DbContextKind.Pooled)
                .AddFiltering()
                .AddQueryType<Query>();

            var app = builder.Build();
            var dbFactory = app.Services.GetRequiredService<IDbContextFactory<HeroDbContext>>();
            var db = dbFactory.CreateDbContext();

            app.MapGraphQL();
            app.Run();
        }
    }


}
