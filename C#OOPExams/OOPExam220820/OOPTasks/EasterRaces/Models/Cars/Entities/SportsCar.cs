
namespace EasterRaces.Models.Cars.Entities
{
   public  class SportsCar:Car
    {
        private const int DefaultMinHorsePower = 250;
        private const int DefaultMaxHorsePower = 450;
        private const int DefaultCubicCentimeters = 3000;

        public SportsCar(string model, int horsePower)
           : base(model, horsePower, DefaultCubicCentimeters,
                 DefaultMinHorsePower, DefaultMaxHorsePower)
        {
        }
    }
}
