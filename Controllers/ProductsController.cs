using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alwi_Laptop_Mart.Controllers
{
    [AllowAnonymous]
    public class ProductsController : Controller
    {
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddProduct(tbl_Product product, HttpPostedFileBase imgfile)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                {
                    dbALMContext db = new dbALMContext();

                    if (imgfile != null)
                    {
                        product.Image = new byte[imgfile.ContentLength];
                        imgfile.InputStream.Read(product.Image, 0, imgfile.ContentLength);
                    }

                    db.tbl_Product.Add(product);
                    db.SaveChanges();

                    ViewBag.Message = "Product added successfully.";

                    ModelState.Clear();
                }
                else
                {
                    return RedirectToAction("Login", "Admin");
                }
            }


            return View();
        }

        [HttpPost]
        public ActionResult SearchProduct(string searchterm)
        {
            dbALMContext db = new dbALMContext();
            dynamic products;

            if (searchterm != "")
            {
                products = db.tbl_Product.Where(x => x.Brand.Equals(searchterm)).ToList();
                products.Reverse();
                if (products.Count <= 0)
                {
                    ViewBag.Search = "No matching product found.";
                }

                return View(products);
            }
            else
            {
                products = db.tbl_Product.ToList();
                products.Reverse();
                return RedirectToAction("Index", "Home", products);
            }
        }

        public ActionResult HP(int productId = 0)
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

            var hp = db.tbl_Product.Where(x => x.Brand == "HP").ToList();
            hp.Reverse();

            return View(hp);
        }

        //to display Dell products
        [HttpGet]
        public ActionResult Dell(int productId = 0)
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

            var dell = db.tbl_Product.Where(x => x.Brand == "Dell").ToList();
            dell.Reverse();

            return View(dell);
        }

        //to display Lenovo products
        [HttpGet]
        public ActionResult Lenovo(int productId = 0)
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

            var lenovo = db.tbl_Product.Where(x => x.Brand == "Lenovo").ToList();
            lenovo.Reverse();

            return View(lenovo);
        }

        //to display Mac products
        [HttpGet]
        public ActionResult Mac(int productId = 0)
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

            var mac = db.tbl_Product.Where(x => x.Brand == "Apple").ToList();
            mac.Reverse();

            return View(mac);
        }

        //to display Sony products
        [HttpGet]
        public ActionResult Sony(int productId = 0)
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

            var sony = db.tbl_Product.Where(x => x.Brand == "Sony").ToList();
            sony.Reverse();

            return View(sony);
        }

    }
}