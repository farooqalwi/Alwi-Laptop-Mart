using Alwi_Laptop_Mart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Alwi_Laptop_Mart.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(AdminLogin account)
        {
            if (ModelState.IsValid)
            {
                dbALMContext db = new dbALMContext();
                var admin = db.tbl_Admin.Where(x => x.Email == account.Email && x.Password == account.Password).FirstOrDefault();

                if (admin != null)
                {
                    string returnUrl = Request.QueryString["ReturnUrl"];

                    if (returnUrl == null)
                    {
                        FormsAuthentication.SetAuthCookie(admin.Email, false);
                        return RedirectToAction("Index", "Home", admin);
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(admin.Email, false);
                        return Redirect(Url.Content(returnUrl));
                    }
                }
                else
                {
                    ViewBag.Message = "Incorrect login credentials.";
                    ModelState.Clear();
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Admin");
        }

        public ActionResult OrderHistory()
        {
            dbALMContext db = new dbALMContext();
            var products = db.tbl_OrderHistory.ToList();

            return View(products);
        }

    }
}