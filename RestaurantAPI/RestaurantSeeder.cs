﻿using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext; 
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }

        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name="KFC",
                    Category="Fast Food",
                    Description="blablabla",
                    ContactEmail="contact@kfc.com",
                    HasDelivery=true,
                    Dishes=new List<Dish>()
                    {
                        new Dish()
                        {
                            Name ="Strips",
                            Price=10.30M,
                        },
                        new Dish()
                        {
                            Name="Chicken Nuggets",
                            Price=5.30M,
                        },
                    
                    
                    },
                    Address=new Address()
                    {
                        City="Gliwice",
                        Street="Wrocławska",
                        PostalCode="30-300"
                    }
                }
               

            };
            return restaurants;

        }
    }
}
