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
    public class CategoryController : Controller
    {
        User currentUser = null;

        private readonly NorthwindDbContext _db;

        public CategoryController()
        {
            _db = new NorthwindDbContext();
        }

        public ActionResult List()
        {
            var categories = _db.Categories.Where(x => x.IsActive).Select(x => new CategoryViewModel
            {
                CategoryId = x.Id,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();
            return View(categories);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            if (Session["LoginBilgileri"] != null)
            {
                currentUser = (User)Session["LoginBilgileri"];
            }

            var category = new Category
            {
                CategoryName = model.CategoryName,
                Description = model.Description,
                IsActive = true,
                CreatedDate = DateTime.Now,
                CreatedById = currentUser.Id
            };
            _db.Categories.Add(category);

            var sonuc = _db.SaveChanges();
            if (sonuc > 0)
            {
                TempData["Message"] = "Category added.";
                return RedirectToAction("List", "Category");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);

            if (category != null)
            {
                var categoryViewModel = new CategoryViewModel()
                {
                    CategoryId = category.Id,
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                };

                return View(categoryViewModel);
            }

            TempData["Message"] = "This category could not be found!";
            return RedirectToAction("List", "Category");

        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = _db.Categories.FirstOrDefault(x => x.Id == model.CategoryId);
            if (category != null)
            {
                category.Id = model.CategoryId;
                category.CategoryName = model.CategoryName;
                category.Description = model.Description;
                category.UpdatedDate = DateTime.Now;

                if (Session["LoginBilgileri"] != null)
                {
                    currentUser = (User)Session["LoginBilgileri"];
                }
                currentUser.UpdatedById = currentUser.Id;

                var sonuc = _db.SaveChanges();

                if (sonuc > 0)
                {
                    TempData["Message"] = "Category updated!";
                    return RedirectToAction("List", "Category");
                }
            };

            TempData["Message"] = "Category does not exists and cannot be updated!";
            return RedirectToAction("List", "Category");
        }

        public ActionResult Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);

            if (category != null)
            {
                category.IsActive = false;
                category.UpdatedDate = DateTime.Now;
                if (Session["LoginBilgileri"] != null)
                {
                    currentUser = (User)Session["LoginBilgileri"];
                }
                category.UpdatedById = currentUser.Id;

                var sonuc = _db.SaveChanges();
                if (sonuc > 0)
                {
                    return RedirectToAction("List", "Category");
                }
            }

            TempData["Message"] = "Category could not be deleted.";
            return RedirectToAction("List", "Category");
        }
    }
}
