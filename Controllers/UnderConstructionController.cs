using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alwi_Laptop_Mart.Controllers
{
    [AllowAnonymous]
    public class UnderConstructionController : Controller
    {
        // GET: UnderConstruction
        public ActionResult Index()
        {
            return View();
        }
    }
}