using Northwind.Admin.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.Entities;

namespace Northwind.Admin.Controllers
{
    public class AuthController : Controller
    {
        private readonly NorthwindDbContext _db;

        public AuthController()
        {
            _db = new NorthwindDbContext();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newUser = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                CreatedDate = DateTime.Now,
                CreatedById = -1,
                IsActive = true,
            };

            if (newUser.Password.Contains("1") || newUser.Password.Contains("2")) // özel şifre geliştirmesi yapılacak.
            {

                _db.Users.Add(newUser);

                var sonuc = _db.SaveChanges();

                if (sonuc > 0)
                {
                    TempData["Message"] = "Successful!";
                    return RedirectToAction("Login");
                }
            }
            else
            {
                TempData["Message"] = "Password must include at least a number!";
                return View(model);
            }

            TempData["Message"] = "User could not be added!";
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var user = _db.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password && x.IsActive);

            if (user != null)
            {
                Session.Add("LoginBilgileri", user);
                if (model.RememberMe)
                {
                    var cookie = new HttpCookie("loginCookie");
                    cookie.Expires = DateTime.Now.AddDays(3);
                    cookie.Values.Add("email", user.Email);
                    cookie.Values.Add("password", user.Password);
                    Response.Cookies.Add(cookie);
                }
                TempData["Message"] = "Login successful!";
                return RedirectToAction("Index", "Home");
            }

            TempData["Message"] = "User cannot be found. Please check your email and password!";
            return View(model);
        }


        public ActionResult Logout()
        {
            Session.Remove("LoginBilgileri");

            return RedirectToAction("Login");
        }
    }
}