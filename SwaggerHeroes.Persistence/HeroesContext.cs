using Microsoft.EntityFrameworkCore;
using SwaggerHeroes.Core.Data.Entities;

namespace SwaggerHeroes.Persistence
{
    public class HeroesContext : DbContext
    {
        public HeroesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hero> Heroes { get; set; }
    }
}
