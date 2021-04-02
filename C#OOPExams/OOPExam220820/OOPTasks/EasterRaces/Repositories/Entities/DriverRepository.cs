using System.Linq;

using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Repositories.Entities
{
    class DriverRepository:Repository<IDriver>
    {
        public override IDriver GetByName(string name)
        {
            return base.GetAll()
                 .FirstOrDefault(x => x.Name == name);
        }
    }
}
