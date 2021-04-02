using System;
using System.Collections.Generic;
using Heroes.Api.Contracts.Models;

namespace Heroes.Api.Core
{
    public static class DataContext
    {
        public static List<Hero> Heroes = new List<Hero>()
        {
            new Hero {
                Id = 1,
                Category = Category.Anime,
                Name = "Sakata Gintoki",
                Powers = new string [] { "samurai", "eat", "sleep" },
                IsAlive = true,
                HasCape = false,
                Created = DateTime.UtcNow
            }
        };
    }

    public interface IRepository<T>
    {
        T Create(T model);
        T Single(Predicate<T> predicate);
        IEnumerable<T> All();
        IEnumerable<T> Search(Predicate<T> predicate);
        void Delete(int id);
    }

    public interface IHeroesRepository : IRepository<Hero>
    {
    }
}