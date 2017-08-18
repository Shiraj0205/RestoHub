using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoHub.ViewModels
{
    public class HomePageDataViewModel
    {
        public IEnumerable<RestaurantViewModel> Restaurants { get; set; }
    }
}
