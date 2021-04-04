using LogLibrary.Models.Contracts;

namespace LogLibrary.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
