using System.Collections.Generic;

using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        private readonly ICollection<T> repository;

        protected Repository()
        {
            repository = new List<T>();
        }
        
        public void Add(T model)
        {
            repository.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection<T>)repository;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return repository.Remove(model);
        }
    }
}
