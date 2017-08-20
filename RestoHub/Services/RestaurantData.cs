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
        void Update(RestaurantViewModel newRestaurant);
        void Commit();
        void Delete(int id);
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

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == id);
            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
        }

        public RestaurantViewModel Get(int id)
        {
            return (from r in _context.Restaurants
                    where r.Id == id
                    select new RestaurantViewModel()
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Cuisine = r.Cuisine
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
                             Cuisine = r.Cuisine
                         }).ToList();

            model.Restaurants = restaurants;

            return model;
        }

        public void Update(RestaurantViewModel restaurant)
        {
            var model = _context.Restaurants.Where(r => r.Id == restaurant.Id).FirstOrDefault();
            model.Name = restaurant.Name;
            model.Cuisine = restaurant.Cuisine;
            _context.Restaurants.Update(model);
            _context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
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
    //                Cuisine = Enums.Cuisines.Japanese
    //            },
    //            new RestaurantViewModel()
    //            {
    //                Id = 2,
    //                Name = "La Quinta",
    //                Cuisine = Enums.Cuisines.American
    //            },
    //            new RestaurantViewModel()
    //            {
    //                Id = 3,
    //                Name = "Olice Garden",
    //                Cuisine = Enums.Cuisines.Italian
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
