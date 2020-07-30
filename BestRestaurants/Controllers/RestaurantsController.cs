using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public RestaurantsController(BestRestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index(string sortOrder)
    {
      ViewBag.RestaurantSort = sortOrder == "restaurant" ? "restaurant_desc" : "restaurant";
      ViewBag.CuisineSort = sortOrder == "cuisine" ? "cuisine_desc" : "cuisine";
      List<Restaurant> model = new List<Restaurant>{};
      switch(sortOrder)
      {
        case "restaurant":
          model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).OrderBy(restaurant => restaurant.Name).ToList();
          break;
        case "restaurant_desc":
          model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).OrderByDescending(restaurant => restaurant.Name).ToList();
          break;
        case "cuisine":
          model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).OrderBy(restaurant => restaurant.Cuisine).ToList();
          break;
        case "cuisine_desc":
          model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).OrderByDescending(restaurant => restaurant.Cuisine).ToList();
          break;
        default:
          model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).ToList();
          break;
      }
      
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View(model);
    }

    [HttpPost]
    public ActionResult Index(int CuisineId)
    {
      int inputId = CuisineId;
      List<Restaurant> model = _db.Restaurants
        .Include(restaurant => restaurant.Cuisine)
        .Where(restaurant => restaurant.CuisineId == inputId)
        .ToList();
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View (thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
      _db.Entry(restaurant).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    public ActionResult Delete(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      _db.Restaurants.Remove(thisRestaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}