using System.Linq.Expressions;

namespace SwaggerHeroes.Core.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Create(T model);
        T Single(Expression<Func<T, bool>> predicate);
        IEnumerable<T> All();
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
        void Delete(int id);
    }
}