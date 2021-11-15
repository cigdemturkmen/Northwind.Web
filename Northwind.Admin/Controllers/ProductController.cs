using Northwind.Admin.Filters;
using Northwind.Admin.Models.ViewModel;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Northwind.Admin.Controllers
{
    // [Auth]
    public class ProductController : Controller
    {
        User currentUser = null;
        private readonly NorthwindDbContext _db;

        public ProductController()
        {
            _db = new NorthwindDbContext();
        }

        public ActionResult List()
        {
            var products = _db.Products.Include(x => x.Category)
                .Include(x => x.Category)
                .Where(x => x.IsActive == true).Select(x => new ProductViewModel
                {
                    ProductId = x.Id,
                    ProductName = x.ProductName,
                    QuantityPerUnit = x.QuantityPerUnit,
                    UnitPrice = x.UnitPrice,
                    CategoryName = x.Category.CategoryName,
                    SupplierName = x.Supplier.CompanyName,
                    Discontinued = x.Discontinued,
                });
           
            return View(products);
        }

        public ActionResult Add()
        {
            ViewBag.Categories = _db.Categories
                .Select(x => new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = x.Id.ToString(),
                })
                .ToList();

            ViewBag.Suppliers = _db.Suppliers
                .Select(x => new SelectListItem()
                {
                    Text = x.CompanyName,
                    Value = x.Id.ToString()
                })
                .ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (Session["LoginBilgileri"]!= null)
            {
                currentUser = (User)Session["LoginBilgileri"];
            }

            if (model != null)
            {
                var product = new Product()
                {
                    CategoryId = model.CategoryId,
                    SupplierId = model.SupplierId,
                    ProductName = model.ProductName,
                    UnitPrice = model.UnitPrice,
                    Discontinued = false,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    CreatedById = (int)currentUser?.Id,
                    
                };
                _db.Products.Add(product);

                var sonuc = _db.SaveChanges();

                if (sonuc > 0)
                {
                    TempData["Message"] = "Product added!";
                    return RedirectToAction("List", "Product");
                }
            }
            return View();
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