using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        // virtual will send a second query when retrieving restaurants and will obtain reviews although its not the best optimized solution it is fastest.
        public virtual ICollection<RestaurantReview> Reviews { get; set; }
    }
}