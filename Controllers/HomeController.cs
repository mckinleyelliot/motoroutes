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
    public class HomeController : Controller
    {

        private HomeContext dbContext;
        public HomeController(HomeContext context)
        {
            dbContext = context;

        }
        public IActionResult Index()
        {
            return RedirectToAction("Dashboard", "ride");
        }



        [HttpGet("signin")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User register)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == register.Email))
                {
                    ModelState.AddModelError("Email", "That email is already in use!");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    register.Password = Hasher.HashPassword(register, register.Password);
                    dbContext.Users.Add(register);
                    dbContext.SaveChanges();
                    HttpContext.Session.SetString("UserEmail", register.Email);
                    return RedirectToAction("Dashboard", "ride");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult LogIn(LoginUser login)
        {
            if(ModelState.IsValid)
            {
                User userInDb = dbContext.Users.FirstOrDefault( u => u.Email == login.LoginEmail);
                if (userInDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Email / Password");
                    return View("SignIn");
                }
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(login, userInDb.Password, login.LoginPassword);
                if (result == 0)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Email / Password");
                    return View("SignIn");
                }
                HttpContext.Session.SetString("UserEmail", login.LoginEmail);
                return RedirectToAction("Dashboard", "ride");
            }
            else
            {
                return View("SignIn");
            }
        }

        [HttpGet("logout")]
        public IActionResult LogOut ()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


//THIS IS ADRIEN'S CODE ALONG VERSION. THIS COPY WAS SHARED FOR EDUCATIONAL PURPOSES ONLY