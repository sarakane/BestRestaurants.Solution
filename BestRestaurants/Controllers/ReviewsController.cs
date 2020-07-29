using BestRestaurants.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BestRestaurants.Controllers
{
  public class ReviewsController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public ReviewsController(BestRestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Create(int id)
    {
      //Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      //ViewBag.Restaurant = thisRestaurant;
      Review model = new Review();
      model.RestaurantId = id;
      return View(model);
    }

    [HttpPost]
    public ActionResult Create(Review review)
    {
      _db.Reviews.Add(review);
      _db.SaveChanges();
      return RedirectToAction("Index", "Restaurants");
    }

    public ActionResult Details(int id)
    {
      Review thisReview = _db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
      return View(thisReview);
    }

    public ActionResult Edit(int id)
    {
      Review thisReview = _db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
      return View(thisReview);
    }

    [HttpPost]
    public ActionResult Edit(Review review)
    {
      _db.Entry(review).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index", "Restaurants");
    }

    public ActionResult Delete(int id)
    {
      Review thisReview = _db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
      return View(thisReview);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Review thisReview = _db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
      _db.Reviews.Remove(thisReview);
      _db.SaveChanges();
      return RedirectToAction("Index", "Restaurants");
    }
  }
}