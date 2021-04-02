using System.Linq;

using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Repositories.Entities
{
    class RaceRepository:Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return base.GetAll()
                 .FirstOrDefault(x => x.Name == name);
        }
    }
}
