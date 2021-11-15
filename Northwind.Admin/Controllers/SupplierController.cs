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
    public class SupplierController : Controller
    {
       
        private readonly NorthwindDbContext _db;
        public SupplierController()
        {
            _db = new NorthwindDbContext();
        }
        User currentUser = null;

        public ActionResult List()
        {
            var suppliers = _db.Suppliers.Where(x => x.IsActive == true).Select(x => new SupplierViewModel() {
                SupplierId = x.Id,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                ContactTitle = x.ContactTitle,
                Address = x.Address,
                Phone = x.Phone,
                
            }).ToList();
            return View(suppliers);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Add(SupplierViewModel model)
        {
            return View();
        }

        //public ActionResult Edit()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
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