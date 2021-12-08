using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alwi_Laptop_Mart.Controllers
{
    [AllowAnonymous]
    public class RegisterAccountController : Controller
    {
        // GET: RegisterAccount
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(tbl_User user)
        {
            if (ModelState.IsValid)
            {
                dbALMContext db = new dbALMContext();
                var admin = db.tbl_Admin.Where(x => x.Email == user.Email).Count();
                var count = db.tbl_User.Where(x => x.Email == user.Email).Count();

                if (admin == 0)
                {
                    if (count == 0)
                    {
                        db.tbl_User.Add(user);
                        db.SaveChanges();

                        ViewBag.Message = "User registered successfully.";

                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = "User already registered. Try a new one.";
                        ModelState.Clear();
                    }
                }
                else
                {
                    ViewBag.Message = "User already registered as an Admin. Try a new one.";
                    ModelState.Clear();
                }
            }



            return View();
        }
    }
}