using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alwi_Laptop_Mart.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        // GET: Cart

        public ActionResult CartList(int cartId = 0)
        {
            dbALMContext db = new dbALMContext();

            if (cartId > 0)
            {
                //to add product into order hisotry and remove from cart list
                Alwi_Laptop_Mart.Classes.OrderHistory.pay(db, cartId: cartId, email: User.Identity.Name);

                Discart(cartId);
            }

            var products = db.tbl_Cart.ToList();

            return View(products);
        }


        public ActionResult Discart(int cartId)
        {
            dbALMContext db = new dbALMContext();
            var product = db.tbl_Cart.Where(x => x.CartId == cartId).FirstOrDefault();
            db.tbl_Cart.Remove(product);
            db.SaveChanges();

            var products = db.tbl_Cart.ToList();

            return RedirectToAction("CartList", products);
        }

        public ActionResult Pay(int cartId = 0)
        {
            dbALMContext db = new dbALMContext();

            if (cartId > 0)
            {
                //to add product into order hisotry and remove from cart list
                Alwi_Laptop_Mart.Classes.OrderHistory.pay(db, cartId: cartId, email: User.Identity.Name);

                Discart(cartId);
            }

            var products = db.tbl_Cart.ToList();

            return RedirectToAction("CartList", products);
        }

        public ActionResult PayAll()
        {
            dbALMContext db = new dbALMContext();
            var items = db.tbl_Cart.ToList();

            foreach (var item in items)
            {
                Alwi_Laptop_Mart.Classes.OrderHistory.pay(db, cartId: item.CartId, email: User.Identity.Name);
                db.tbl_Cart.Remove(item);
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}