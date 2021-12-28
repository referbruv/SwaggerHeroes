using SwaggerHeroes.Core.Data.Repositories;
using SwaggerHeroes.Core.Data.Services;
using SwaggerHeroes.Persistence.Data.Repositories;

namespace SwaggerHeroes.Persistence.Data.Services
{
    public class DataService : IDataService
    {
        private readonly HeroesContext _context;

        public DataService(HeroesContext context)
        {
            this._context = context;
        }

        public IHeroesRepository Heroes => new HeroesRepository(_context);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
