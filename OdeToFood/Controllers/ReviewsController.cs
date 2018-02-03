using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        [ChildActionOnly]
        public ActionResult BestReview()
        {
            var bestReview = from r in _db.Reviews
                             orderby r.Rating descending
                             select r;

            return PartialView("_Review", bestReview.First());
        }

        // GET: Reviews
        [ActionName("Index")]
        [HttpGet]
        public ActionResult Index([Bind(Prefix="id")] int restaurantId)
        {
            var restaurant = _db.Restaurants.Find(restaurantId);

            if(restaurant != null)
            {
                return View(restaurant);
            }

            return HttpNotFound();
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reviews/Create
        [HttpGet]
        public ActionResult Create(int restaurantId)
        {
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        public ActionResult Create(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }

            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Reviews.Find(id);
            return View(model);
        }

        // public ActionResult Edit([Bind(Exclude = "ReviewerName")] RestaurantReview review)
        [HttpPost]
        public ActionResult Edit(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = review.RestaurantId });
            }

            return View(review);
        }

        //// GET: Reviews/Edit/5
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    var review = _reviews.Single(r => r.Id == id);

        //    return View(review);
        //}

        //// POST: Reviews/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    var review = _reviews.Single(r => r.Id == id);

        //    if (TryUpdateModel(review))
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View(review);
        //}

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //static List<RestaurantReview> _reviews = new List<RestaurantReview>
        //{
        //    new RestaurantReview
        //    {
        //        Id = 1,
        //        Name = "Soya",
        //        City = "Vilnius",
        //        Country = "Lithuania",
        //        Rating = 10
        //    },
        //    new RestaurantReview
        //    {
        //        Id = 2,
        //        Name = "Agave",
        //        City = "Kaunas",
        //        Country = "Lithuania",
        //        Rating = 10
        //    },
        //    new RestaurantReview
        //    {
        //        Id = 3,
        //        Name = "Province",
        //        City = "Riga",
        //        Country = "Latvia",
        //        Rating = 10
        //    }
        //};

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
