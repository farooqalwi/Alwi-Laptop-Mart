using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Alwi_Laptop_Mart.Controllers
{
    public class LogoutAccountController : Controller
    {
        // GET: LogoutAccount
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "LoginAccount");
        }
    }
}