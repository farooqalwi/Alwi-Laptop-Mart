using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alwi_Laptop_Mart.Controllers
{
    [AllowAnonymous]
    public class ProductDetailsController : Controller
    {
        //show product details
        public ActionResult ProductDetails(int productId = 0)
        {
            if (productId > 0)
            {
                dbALMContext db = new dbALMContext();
                var productDetails = db.tbl_Product.Where(x => x.ProductID == productId).FirstOrDefault();

                return View(productDetails);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Pay(int productId = 0)
        {
            if (User.Identity.IsAuthenticated)
            {
                dbALMContext db = new dbALMContext();

                if (productId > 0)
                {
                    //to add product into order hisotry
                    Alwi_Laptop_Mart.Classes.OrderHistory.pay(db, productId: productId, email: User.Identity.Name);
                }


                var productDetails = db.tbl_Product.Where(x => x.ProductID == productId).FirstOrDefault();

                return RedirectToAction("ProductDetails", "ProductDetails", productDetails);
            }
            else
            {
                return RedirectToAction("Index", "LoginAccount");
            }

        }
    }
}