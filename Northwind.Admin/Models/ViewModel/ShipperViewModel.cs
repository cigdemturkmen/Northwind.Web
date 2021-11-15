using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Admin.Models.ViewModel
{
    public class ShipperViewModel
    {
        public int ShipperId { get; set; }

        [Required(ErrorMessage ="This field is required!")]
        [StringLength(40, ErrorMessage = "Shipper company name must be no longer than 40 characters!")]
        public string CompanyName { get; set; }

        [StringLength(24, ErrorMessage = "Phone number must be no longer than 24 characters!")]
        public string Phone { get; set; }

       
    }
}