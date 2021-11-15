using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Admin.Models.ViewModel
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(15, ErrorMessage = "Category name must be no longer than 15 characters and shorter than 2 characters.", MinimumLength = 2)]
        public string CategoryName { get; set; }


        [StringLength(500, ErrorMessage = "Description must be no longer than 500 characters.")]
        public string Description { get; set; }
    }
}