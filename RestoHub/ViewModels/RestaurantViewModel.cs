using RestoHub.Enums;
using System.ComponentModel.DataAnnotations;

namespace RestoHub.ViewModels
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        public Cousines Cousine { get; set; }
    }
}
