using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alwi_Laptop_Mart.Classes
{
    public class OrderHistory
    {
        public static void pay(dbALMContext db, int productId = 0, int cartId = 0, string email = "")
        {
            var user = UserDetails.UserInfo(email);
            string name = user.UserName;

            if (productId > 0)
            {
                var product = db.tbl_Product.Where(x => x.ProductID == productId).FirstOrDefault();
                tbl_OrderHistory orderHistory = new tbl_OrderHistory();
                orderHistory.UserName = name;
                orderHistory.Email = email;
                orderHistory.Brand = product.Brand;
                orderHistory.Model = product.Model;
                orderHistory.Price = product.Price;
                orderHistory.Date = DateTime.Now;
                orderHistory.ProductID = product.ProductID;

                db.tbl_OrderHistory.Add(orderHistory);
                db.SaveChanges();
            }

            if (cartId > 0)
            {
                var product = db.tbl_Cart.Where(x => x.CartId == cartId).FirstOrDefault();
                tbl_OrderHistory orderHistory = new tbl_OrderHistory();
                orderHistory.UserName = name;
                orderHistory.Email = email;
                orderHistory.Brand = product.Brand;
                orderHistory.Model = product.Model;
                orderHistory.Price = product.Price;
                orderHistory.Date = DateTime.Now;
                orderHistory.ProductID = product.ProductID;
                orderHistory.CartId = product.CartId;
                orderHistory.UserId = product.UserId;

                db.tbl_OrderHistory.Add(orderHistory);
                db.SaveChanges();
            }
        }

    }
}