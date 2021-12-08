using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alwi_Laptop_Mart.Models
{
    public class tbl_UserValidation
    {
        [Required(ErrorMessage = "User Name is Required.")]
        [Display(Name = "User Name: ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password: ")]
        [DataType(DataType.Password)]
        [Compare(otherProperty: "Password", ErrorMessage = "Password does not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile No is Required.")]
        [Display(Name = "Mobile No: ")]
        public string Mobile { get; set; }

        [Display(Name = "City: ")]
        public string City { get; set; }

        [Display(Name = "State: ")]
        public string State { get; set; }

        [Display(Name = "Address: ")]
        public string Address { get; set; }
    }

    [MetadataType(typeof(tbl_UserValidation))]

    public partial class tbl_User
    {

    }
}