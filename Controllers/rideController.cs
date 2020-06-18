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
                List<ride> allrides = dbContext.rides.Include( w => w.comments).ToList();
                ViewBag.ApiKey = "https://maps.googleapis.com/maps/api/js?key=AIzaSyDr42YUsPp9WhD8eoNWXJBpS85Epc0F-xw&callback=myMap";
                return View(allrides);
        }

        [HttpGet("newinfo")]
        public IActionResult newinfo()
        {
                return View();
        }



        [HttpPost("create")]
        public IActionResult Create(ride plan)
        {
                if(ModelState.IsValid)
                {
                    dbContext.rides.Add(plan);
                    dbContext.SaveChanges();
                    return Redirect($"show/{plan.rideId}");
                }
                else
                {
                    return View("NewInfo");
                }
        }

        [HttpGet("{rideId}/newcomment")]
        public IActionResult Newcomment(int rideId)
        {
                return View();
        }

        [HttpPost("createcomment")]
        public IActionResult Createcomment(int rideId, comment comment123)
        {

                if(ModelState.IsValid)
                {
                    comment newcomment = new comment ();
                    newcomment.rideId = rideId;
                    dbContext.comments.Add(comment123);
                    dbContext.SaveChanges();
                    return Redirect($"show/{comment123.rideId}");
                }
                else
                {
                    return View("NewComment");
                }
        }



        [HttpGet("show/{rideId}")]
        public IActionResult Show(int rideId)
        {
                ViewBag.ApiKey = "https://maps.googleapis.com/maps/api/js?key=AIzaSyDr42YUsPp9WhD8eoNWXJBpS85Epc0F-xw&callback=myMap";
                ride rideinfo = dbContext.rides.Include( w => w.comments ).FirstOrDefault (w => w.rideId == rideId);
                return View(rideinfo);
        }


        [HttpGet("destroy/{rideId}")]
        public IActionResult Destroy (int rideId)
        {
                ride remove = dbContext.rides.FirstOrDefault(w => w.rideId == rideId);
                dbContext.rides.Remove(remove);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
        }

        [HttpGet("destroycomment/{commentId}")]
        public IActionResult DestroyComment (int commentId)
        {
                comment remove = dbContext.comments.FirstOrDefault(w => w.commentId == commentId);
                dbContext.comments.Remove(remove);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
        }






    }
}