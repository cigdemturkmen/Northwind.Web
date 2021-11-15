using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Admin.Filters
{
    public class AuthAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var currentUser = filterContext.HttpContext.Session["LoginBilgileri"];

            if (currentUser == null)
            {
                filterContext.HttpContext.Response.Redirect("/auth/login");
            }
        }
    }
}