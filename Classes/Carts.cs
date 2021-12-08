using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alwi_Laptop_Mart.Classes
{
    public class Carts
    {
        //to add products into cart
        public static void addCart(dbALMContext db, int productId)
        {
            if (productId != 0)
            {
                var product = db.tbl_Product.Where(x => x.ProductID == productId).FirstOrDefault();
                tbl_Cart cart = new tbl_Cart();
                cart.ProductIcon = product.Image;
                cart.Brand = product.Brand;
                cart.Model = product.Model;
                cart.Price = product.Price;
                cart.ProductID = product.ProductID;

                db.tbl_Cart.Add(cart);
                db.SaveChanges();

                
            }
        }
    }
}