using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository: IRepository<IDecoration>
    {
        private readonly ICollection<IDecoration> models;


        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models
            => (IReadOnlyCollection<IDecoration>)models;

        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration found = models
                 .FirstOrDefault(x => x.GetType().Name == type);
            return found;
        }

        public bool Remove(IDecoration model)
        {
            return models.Remove(model);
        }
    }
}
