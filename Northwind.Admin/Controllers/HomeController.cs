using Northwind.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Admin.Controllers
{
    [Auth]
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }
    }
}