using Northwind.Admin.Filters;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Admin.Controllers
{
    [Auth]
    public class OrderController : Controller
    {
        private readonly NorthwindDbContext _db;

        public OrderController()
        {
            _db = new NorthwindDbContext();
        }

        public ActionResult List()
        {
            return View();
        }
    }
}