using SwaggerHeroes.Core.Data.Repositories;

namespace SwaggerHeroes.Core.Data.Services
{
    public interface IDataService
    {
        IHeroesRepository Heroes { get; }

        void SaveChanges();
    }
}