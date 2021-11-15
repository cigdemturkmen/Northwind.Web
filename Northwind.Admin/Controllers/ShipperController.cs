using Northwind.Admin.Filters;
using Northwind.Admin.Models.ViewModel;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Admin.Controllers
{
    [Auth]
    public class ShipperController : Controller
    {
        User currentUser = null;
        private readonly NorthwindDbContext _db;

        public ShipperController()
        {
            _db = new NorthwindDbContext();
        }
        public ActionResult List()
        {
            var shippers = _db.Shippers.Where(x => x.IsActive == true).Select(x => new ShipperViewModel() {
                ShipperId = x.Id,
                CompanyName = x.CompanyName,
                Phone = x.Phone,
            }).ToList();
            return View(shippers);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Add(ShipperViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            if (model != null)
            {
                if (Session["LoginBilgileri"] != null)
                {
                    currentUser = (User)Session["LoginBilgileri"];
                }

                var shipper = new Shipper()
                {
                    CompanyName = model.CompanyName,
                    Phone = model.Phone,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    CreatedById = currentUser.Id,
                };
            }

            TempData["Message"] = "Employee added!";
            return RedirectToAction("List", "Employee");
        }

        //public ActionResult Edit()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Edit()
        //{
        //    return View();
        //}

        //public ActionResult Delete()
        //{
        //    return View();
        //}
    }
}