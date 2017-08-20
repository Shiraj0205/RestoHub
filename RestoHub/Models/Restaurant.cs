using RestoHub.Enums;

namespace RestoHub.Models
{

    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Cuisines Cuisine { get; set; }
    }
}
