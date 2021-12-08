using Alwi_Laptop_Mart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alwi_Laptop_Mart.Controllers
{
    [AllowAnonymous]
    public class AccountSettingsController : Controller
    {
        // GET: AccountSettings
        [Authorize(Roles = "Customer")]
        [HttpGet]
        public ActionResult UpdateAccount()
        {
            tbl_User user = new tbl_User();
            using (dbALMContext db = new dbALMContext())
            {
                user = db.tbl_User.Where(x => x.Email == User.Identity.Name).FirstOrDefault();
            }

            return View(user);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UpdateAccount(tbl_User user)
        {
            using (dbALMContext db = new dbALMContext())
            {
                var dbUser = db.tbl_User.Where(x => x.Email == User.Identity.Name).FirstOrDefault();

                if (ModelState.IsValid)
                {
                    dbUser.Mobile = user.Mobile;
                    dbUser.City = user.City;
                    dbUser.State = user.State;
                    dbUser.Address = user.Address;

                    db.Entry(dbUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();


                    ViewBag.Message = "Customer Info Updated Successfully.";
                }

                return View(dbUser);
            }
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel passwordModel)
        {
            if (ModelState.IsValid)
            {
                using (dbALMContext db = new dbALMContext())
                {
                    var user = db.tbl_User.Where(x => x.Email == passwordModel.Email).FirstOrDefault();
                    if (user != null)
                    {
                        user.Password = passwordModel.ConfirmNewPassword;
                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        ViewBag.Message = "Password Changed Successfully.";
                    }
                    else
                    {
                        ViewBag.Message = "Invalid Email or Old Password.";
                    }

                }

                ModelState.Clear();
            }

            return View();

        }
    }
}