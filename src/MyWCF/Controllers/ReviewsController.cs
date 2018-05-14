using MyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVC.Controllers
{
    public class ReviewsController : Controller
    {
        public static List<RestaurantReviewViewModel> _reviews { get; set; } = new List<RestaurantReviewViewModel>
        {
            new RestaurantReviewViewModel
            {
                Id = 0, Name = $"Restaurant_{Guid.NewGuid().ToString()}", City = "City XXX", Country = "Country YYY", Rating = new Random().Next(0,6)
            },
            new RestaurantReviewViewModel
            {
                Id = 1, Name = $"Restaurant_{Guid.NewGuid().ToString()}", City = "City XXX", Country = "Country YYY", Rating = new Random().Next(0,6)
            },
            new RestaurantReviewViewModel
            {
                Id = 3, Name = $"Restaurant_{Guid.NewGuid().ToString()}", City = "City XXX", Country = "Country YYY", Rating = new Random().Next(0,6)
            },
            new RestaurantReviewViewModel
            {
                Id = 4, Name = $"Restaurant_{Guid.NewGuid().ToString()}", City = "City XXX", Country = "Country YYY", Rating = new Random().Next(0,6)
            }
        };
        
        // GET: Reviews
        public ActionResult Index()
        {
            var model =
                from r in _reviews
                orderby r.Name
                select r;

            return View(model);
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int id)
        {
            var review = _reviews.Single(r => r.Id == id);
            return View(review);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var review = _reviews.Single(r => r.Id == id);
            if (TryUpdateModel(review))
            {
                // ..
                return RedirectToAction("Index");
            }

            return View(review);
        }

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

        public ActionResult GetBestReview()
        {
            var bestReview = from r in _reviews
                             orderby r.Rating descending
                             select r;

            return PartialView("_Review", bestReview.First());
        }
    }
}
