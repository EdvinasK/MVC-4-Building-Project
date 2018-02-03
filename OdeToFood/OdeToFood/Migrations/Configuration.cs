namespace OdeToFood.Migrations
{
    using OdeToFood.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Soya", City = "Vilnius", Country = "Lithuania" },
                new Restaurant { Name = "Agave", City = "Kaunas", Country = "Lithuania" },
                new Restaurant
                {
                    Name = "Province",
                    City = "Riga",
                    Country = "Latvia",
                    Reviews =
                        new List<RestaurantReview>
                        {
                            new RestaurantReview { Rating=9, Body="Great food!" }
                        }
                });

            for(int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                    new Restaurant { Name = i.ToString(), City = "Sample", Country = "Lithuania" });
            }
        }
    }
}
