using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Admin.Models.ViewModel
{
    public class SupplierViewModel
    {
        public int SupplierId { get; set; }
        [Required(ErrorMessage ="This field is required!")]
        [StringLength(40, ErrorMessage = "Use maximum 40 characters!")]
        public string CompanyName { get; set; }

        [StringLength(30, ErrorMessage = "Use maximum 30 characters!")]
        public string ContactName { get; set; }

        [StringLength(30, ErrorMessage = "Use maximum 30 characters!")]
        public string ContactTitle { get; set; }

        [StringLength(60, ErrorMessage = "Use maximum 60 characters!")]
        public string Address { get; set; }

        [StringLength(24, ErrorMessage = "Use maximum 24 characters!")]
        public string Phone { get; set; }

        #region Relations
        public List<Product> Products { get; set; }
        #endregion
    }
}