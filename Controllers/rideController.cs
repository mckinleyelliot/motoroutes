using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using motoroutes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace motoroutes.Controllers

{
    [Route("rides")]
    public class rideController : Controller
    {
        private HomeContext dbContext;
        public rideController(HomeContext context)
        {
            dbContext = context;

        }
        [HttpGet("")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("UserEmail") == null)
            {
                return RedirectToAction("LogOut", "Home");
            }
            else{
                User userInDb = dbContext.Users.Include( u => u.createdrides).FirstOrDefault( u => u.Email == HttpContext.Session.GetString("UserEmail"));
                ViewBag.User = userInDb;

                List<ride> allrides = dbContext.rides.ToList();

                return View(allrides);
            }
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            if(HttpContext.Session.GetString("UserEmail") == null)
            {
                return RedirectToAction("LogOut", "Home");
            }
            else
            {
                User userInDb = dbContext.Users.Include( u => u.createdrides).FirstOrDefault( u => u.Email == HttpContext.Session.GetString("UserEmail"));
                ViewBag.User = userInDb;
                return View();
            }
        }
        [HttpPost("create")]
        public IActionResult Create(ride plan)
        {
            if(HttpContext.Session.GetString("UserEmail") == null)
            {
                return RedirectToAction("LogOut", "Home");
            }
            else
            {
                if(ModelState.IsValid)
                {
                    dbContext.rides.Add(plan);
                    dbContext.SaveChanges();
                    return Redirect($"show/{plan.rideId}");
                }
                else
                {
                    User userInDb = dbContext.Users.Include( u => u.createdrides).FirstOrDefault( u => u.Email == HttpContext.Session.GetString("UserEmail"));
                    ViewBag.User = userInDb;
                    return View("New" );
                }
            }
        }
        [HttpGet("show/{rideId}")]
        public IActionResult Show(int rideId)
        {
            if(HttpContext.Session.GetString("UserEmail") == null)
            {
                return RedirectToAction("LogOut", "Home");
            }
            else 
            {
                User userInDb = dbContext.Users.Include( u => u.createdrides).FirstOrDefault( u => u.Email == HttpContext.Session.GetString("UserEmail"));
                ViewBag.User = userInDb;
                ViewBag.ApiKey = "https://maps.googleapis.com/maps/api/js?key=AIzaSyDr42YUsPp9WhD8eoNWXJBpS85Epc0F-xw&callback=myMap";
                ride rideinfo = dbContext.rides.FirstOrDefault (w => w.rideId == rideId);
                return View(rideinfo);
            }
        }


        [HttpGet("destroy/{rideId}")]
        public IActionResult Destroy (int rideId)
        {
            if(HttpContext.Session.GetString("UserEmail") == null)
            {
                return RedirectToAction("LogOut", "Home");
            }
            else 
            {
                ride remove = dbContext.rides.FirstOrDefault(w => w.rideId == rideId);
                dbContext.rides.Remove(remove);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }






    }
}