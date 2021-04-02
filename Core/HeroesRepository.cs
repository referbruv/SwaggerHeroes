using System;
using System.Collections.Generic;
using Heroes.Api.Contracts.Models;

namespace Heroes.Api.Core
{
    public class HeroesRepository : IHeroesRepository
    {
        public IEnumerable<Hero> All()
        {
            return DataContext.Heroes.ToArray();
        }

        public Hero Create(Hero hero)
        {
            int id = (DataContext.Heroes.Count) + 1;
            
            hero.Id = id;
            hero.Created = DateTime.Now;
            
            DataContext.Heroes.Add(hero);
            return hero;
        }

        public void Delete(int id)
        {
            int index = DataContext.Heroes.FindIndex(0, x => x.Id == id);
            if (index > -1)
            {
                DataContext.Heroes.RemoveAt(index);
            }
        }

        public IEnumerable<Hero> Search(Predicate<Hero> predicate)
        {
            return DataContext.Heroes.FindAll(predicate);
        }

        public Hero Single(Predicate<Hero> predicate)
        {
            return DataContext.Heroes.Find(predicate);
        }
    }
}