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
    public class OrderDetailController : Controller
    {
        private readonly NorthwindDbContext _db;

        public OrderDetailController()
        {
            _db = new NorthwindDbContext();
        }
        
        public ActionResult List(int id)
        {
            //var order = _db.Orders.FirstOrDefault(x => x.OrderId == id);
            var orderDetail = _db.OrderDetails.FirstOrDefault(x => x.OrderID == id);
            return View(orderDetail);
        }
    }
}