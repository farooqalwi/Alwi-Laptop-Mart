using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alwi_Laptop_Mart.Models
{
    public class tbl_ProductValidation
    {
        [Display(Name = "Brand: ")]
        [Required(ErrorMessage = "Brand is required.")]
        public string Brand { get; set; }

        [Display(Name = "Model: ")]
        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; }

        [Display(Name = "Price: ")]
        [Required(ErrorMessage = "Price is required.")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Display: ")]
        [Required(ErrorMessage = "Display is required.")]
        public string Display { get; set; }

        [Display(Name = "Storage: ")]
        [Required(ErrorMessage = "Storage is required.")]
        public string Storage { get; set; }

        [Display(Name = "Processor: ")]
        [Required(ErrorMessage = "Processor is required.")]
        public string Processor { get; set; }

        [Display(Name = "RAM: ")]
        [Required(ErrorMessage = "RAM is required.")]
        public string RAM { get; set; }

        [Display(Name = "Warranty: ")]
        [Required(ErrorMessage = "Warranty is required.")]
        public string Warranty { get; set; }

        [Display(Name = "Graphic Card: ")]
        [Required(ErrorMessage = "Graphic Card is required.")]
        public string GraphicCard { get; set; }

        [Display(Name = "Description: ")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        [Display(Name = "Image: ")]
        public byte[] Image { get; set; }


    }

    [MetadataType(typeof(tbl_ProductValidation))]
    public partial class tbl_Product
    {
    }
}