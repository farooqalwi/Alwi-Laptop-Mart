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
    public class LoginAccountController : Controller
    {
        // GET: LoginAccount
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(LoginAccount account)
        {
            if (ModelState.IsValid)
            {
                dbALMContext db = new dbALMContext();
                var user = db.tbl_User.Where(x => x.Email == account.Email && x.Password == account.Password).FirstOrDefault();

                if (user != null)
                {
                    string returnUrl = Request.QueryString["ReturnUrl"];

                    if (returnUrl == null)
                    {
                        FormsAuthentication.SetAuthCookie(user.Email, false);

                        return RedirectToAction("Index", "Home", user);
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(user.Email, false);
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
    }
}