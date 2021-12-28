using SwaggerHeroes.Core.Data.Entities;
using SwaggerHeroes.Core.Data.Repositories;

namespace SwaggerHeroes.Persistence.Data.Repositories
{
    public class HeroesRepository : Repository<Hero>, IHeroesRepository
    {
        public HeroesRepository(HeroesContext context) : base(context)
        {
        }
    }
}