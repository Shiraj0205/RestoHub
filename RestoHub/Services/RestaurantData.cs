using RestoHub.Models;
using RestoHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestoHub.Services
{
    public interface IRestaurantData
    {
        HomePageDataViewModel GetAll();
        RestaurantViewModel Get(int id);
        Restaurant Add(Restaurant newRestaurant);
    }

    public class RestaurantData : IRestaurantData
    {
        List<RestaurantViewModel> restaurants = new List<RestaurantViewModel>();
        private RestoHubDbContext _context;

        public RestaurantData(RestoHubDbContext context)
        {
            _context = context;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Restaurants.Add(newRestaurant);
            _context.SaveChanges();
            return newRestaurant;
        }

        public RestaurantViewModel Get(int id)
        {
            return (from r in _context.Restaurants
                    where r.Id == id
                    select new RestaurantViewModel()
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Cousine = r.Cousine
                    }).FirstOrDefault();
        }

        public HomePageDataViewModel GetAll()
        {
            var model = new HomePageDataViewModel();
            var restaurants = (from r in _context.Restaurants
                         select new RestaurantViewModel()
                         {
                             Id = r.Id,
                             Name = r.Name,
                             Cousine = r.Cousine
                         }).ToList();

            model.Restaurants = restaurants;

            return model;
        }
    }

    //public class RestaurantData : IRestaurantData
    //{
    //    List<RestaurantViewModel> restaurants = new List<RestaurantViewModel>();
    //    public RestaurantData()
    //    {
    //        restaurants = new List<RestaurantViewModel>()
    //        {
    //            new RestaurantViewModel()
    //            {
    //                Id = 1,
    //                Name = "Chipotale",
    //                Cousine = Enums.Cousines.Japanese
    //            },
    //            new RestaurantViewModel()
    //            {
    //                Id = 2,
    //                Name = "La Quinta",
    //                Cousine = Enums.Cousines.American
    //            },
    //            new RestaurantViewModel()
    //            {
    //                Id = 3,
    //                Name = "Olice Garden",
    //                Cousine = Enums.Cousines.Italian
    //            }
    //        };
    //    }
    //    public RestaurantViewModel Get(int id)
    //    {
    //        return restaurants.Where(r => r.Id == id).FirstOrDefault();
    //    }

    //    public HomePageDataViewModel GetAll()
    //    {
    //        var model = new HomePageDataViewModel();

    //        model.Restaurants = restaurants;

    //        return model;
    //    }
    //}
}
