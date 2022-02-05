using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieInputContext daContext {get; set;}

        public HomeController(ILogger<HomeController> logger, MovieInputContext someName)
        {
            _logger = logger;
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = daContext.Category.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Movies(MovieInput ar)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();
                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = daContext.Category.ToList();
                return View(ar);
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
        //table for movies
        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = daContext.responses
                .Include(x=> x.Category)
                .ToList();
            return View(movies);
           //ViewBag.Categories = daContext.responses.ToList();
            //return View();
        }

        //edit
        [HttpGet]
        public IActionResult Edit(int MovieID)
        {
            ViewBag.Categories = daContext.Category.ToList();
            var movies = daContext.responses.Single(x => x.MovieID == MovieID);
            
            return View("MovieList", movies);
        }

        //delete 
        [HttpGet]
        public IActionResult Delete(int MovieID)
        {
            var Movies = daContext.responses.Single(x => x.MovieID == MovieID);
            return View(Movies);
           
        }
        [HttpPost]
        public IActionResult Delete(MovieInput ar)
        {
            daContext.responses.Remove(ar);
            daContext.SaveChanges();
            return RedirectToAction("MovieList"); 
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
