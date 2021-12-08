using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alwi_Laptop_Mart.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //to display products
        [HttpGet]
        public ActionResult Index(int productId = 0)
        {
            dbALMContext db = new dbALMContext();

            if (productId != 0)
            {
                if (User.Identity.IsAuthenticated && User.IsInRole("Customer"))
                {
                    Alwi_Laptop_Mart.Classes.Carts.addCart(db, productId);
                    ViewBag.Message = "Product added to Cart successfully.";
                }
                else
                {
                    return RedirectToAction("Index", "LoginAccount");
                }
            }

            var products = db.tbl_Product.ToList();
            products.Reverse();

            return View(products);
        }
    }
}