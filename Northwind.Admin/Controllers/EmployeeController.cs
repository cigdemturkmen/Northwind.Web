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
    public class EmployeeController : Controller
    {
        User currentUser = null;
        private readonly NorthwindDbContext _db;

        public EmployeeController()
        {
            _db = new NorthwindDbContext();
        }

        public ActionResult List()
        {
            var employees = _db.Employees.Where(x => x.IsActive == true).Select(x => new EmployeeViewModel() 
            { 
                EmployeeId =x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Title = x.Title,
                BirthDate = x.BirthDate,
                HireDate = x.HireDate,
                Address = x.Address,
                Phone = x.Phone
            }).ToList();

            return View(employees);
        }

        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Add(EmployeeViewModel model)
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

                var employee = new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Title = model.Title,
                    BirthDate = model.BirthDate,
                    Address = model.Address,
                    HireDate = model.HireDate,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    Phone = model.Phone,
                    CreatedById = currentUser.Id,
                };
            }

            TempData["Message"] = "Employee added!";
            return RedirectToAction("List","Employee");
        }

        public ActionResult Edit(int id)
        {
            var employee = _db.Employees.FirstOrDefault(x => x.Id == id);

            if (employee != null)
            {
                var employeeViewModel = new EmployeeViewModel()
                {
                    EmployeeId = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title,
                    BirthDate = employee.BirthDate,
                    HireDate = employee.HireDate,
                    Address = employee.Address,
                    Phone = employee.Phone,
                    
                   
                };

                return View(employeeViewModel);
            }

            TempData["Message"] = "This category could not be found!";
            return RedirectToAction("List", "Employee");
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var employee = _db.Employees.FirstOrDefault(x => x.Id == model.EmployeeId);
            if (employee != null)
            {
                employee.Id = model.EmployeeId;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Title = model.Title;
                employee.BirthDate = model.BirthDate;
                employee.HireDate = model.HireDate;
                employee.Address = model.Address;
                employee.Phone = model.Phone;
                employee.UpdatedDate = DateTime.Now;

                if (Session["LoginBilgileri"] != null)
                {
                    currentUser = (User)Session["LoginBilgileri"];
                }
                currentUser.UpdatedById = currentUser.Id;

                employee.UpdatedById = currentUser.Id;

                var sonuc = _db.SaveChanges();

                if (sonuc > 0)
                {
                    TempData["Message"] = "Employee updated!";
                    return RedirectToAction("List", "Employee");
                }
            };

            TempData["Message"] = "Employee does not exists and cannot be updated!";
            return RedirectToAction("List", "Employee");
            
        }

        public ActionResult Delete(int id)
        {
            var employee = _db.Employees.FirstOrDefault(x => x.Id == id);

            if (employee != null)
            {
                employee.IsActive = false;
                employee.UpdatedDate = DateTime.Now;
                if (Session["LoginBilgileri"] != null)
                {
                    currentUser = (User)Session["LoginBilgileri"];
                }
                employee.UpdatedById = currentUser.Id;

                var sonuc = _db.SaveChanges();
                if (sonuc > 0)
                {
                    return RedirectToAction("List", "Employee");
                }
            }

            TempData["Message"] = "Employee could not be deleted.";
            return RedirectToAction("List", "Category");
        }
    }
}