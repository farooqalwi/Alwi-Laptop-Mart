using Alwi_Laptop_Mart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alwi_Laptop_Mart.Classes
{
    public class UserDetails
    {
       
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }


        public static UserDetails UserInfo(string email)
        {
            dbALMContext db = new dbALMContext();
            var user = db.tbl_User.Where(x => x.Email == email).FirstOrDefault();
            UserDetails userDetails = new UserDetails();
            userDetails.UserName = user.UserName;
            userDetails.Email = user.Email;
            userDetails.Mobile = user.Mobile;
            userDetails.City = user.City;
            userDetails.State = user.State;
            userDetails.Address = user.Address;

            return userDetails;
        }
    }
}