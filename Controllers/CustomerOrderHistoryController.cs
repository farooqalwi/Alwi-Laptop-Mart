using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alwi_Laptop_Mart.Controllers
{
    public class CustomerOrderHistoryController : Controller
    {
        // GET: CustomerOrderHistory
        public ActionResult OrderHistory()
        {
            dbALMContext db = new dbALMContext();
            var products = db.tbl_OrderHistory.Where(x => x.Email == User.Identity.Name).ToList();

            return View(products);
        }
    }
}