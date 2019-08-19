using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chefs.Models;
using Microsoft.EntityFrameworkCore;

namespace Chefs.Controllers
{
    public class HomeController : Controller
    {
        private ChefsContext dbContext;
        public HomeController(ChefsContext context){
            dbContext = context;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            // Get all Users
            List<Chef>AllChefs = dbContext.MyChefs.Include(d => d.CreatedDishes).ToList();
    
    		// Get the 5 most recently added Users
            List<Chef> MostRecent = dbContext.MyChefs
    			.OrderByDescending(u => u.CreatedAt)
    			.Take(5)
    			.ToList();
			return View("Index", AllChefs);
     	}

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.MyDishes.ToList();

            List<Dish> MostRecent = dbContext.MyDishes
    			.OrderByDescending(u => u.CreatedAt)
    			.Take(5)
    			.ToList();
            return View("dishes", AllDishes);
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            List<Chef> AllChefs = dbContext.MyChefs.Include(Dish => Dish.CreatedDishes).ToList();
            ViewBag.cooks = AllChefs;
           return View("newDish");
        }

        [HttpGet("add")]
        public IActionResult AddChef()
        {
            return View("new");
        }

        [HttpPost("new")]
        public IActionResult NewDish(Dish newDish)
        {
            if (ModelState.IsValid) {
                newDish.CreatedAt = DateTime.Now;
                newDish.UpdatedAt = DateTime.Now;
                dbContext.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("dishes");
            }
            else
            {
                return View ("newDish");
            }
        }
        
        [HttpPost("create")]
        public IActionResult Create(Chef newChef)
        {
            if (ModelState.IsValid) {
                newChef.CreatedAt = DateTime.Now;
                newChef.UpdatedAt = DateTime.Now;
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("newChef");
            }
        }
    }
}
