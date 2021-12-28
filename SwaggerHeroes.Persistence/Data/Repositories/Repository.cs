using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using SwaggerHeroes.Core.Data.Repositories;

namespace SwaggerHeroes.Persistence.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HeroesContext _context;
        private readonly DbSet<T> _entities;

        public Repository(HeroesContext context)
        {
            this._context = context;
            _entities = _context.Set<T>();
        }

        public IEnumerable<T> All()
        {
            return _entities.AsQueryable();
        }

        public T Create(T model)
        {
            _entities.Add(model);
            return model;
        }

        public void Delete(int id)
        {
            _entities.Remove(_entities.Find(id));
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _entities.Single(predicate);
        }
    }
}
