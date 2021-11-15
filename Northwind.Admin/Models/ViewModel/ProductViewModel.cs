using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Admin.Models.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [StringLength(40, ErrorMessage = "Product name must be no longer than 40 characters!")]
        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        [StringLength(20, ErrorMessage = "Use maximum 20 characters!")]
        public string QuantityPerUnit { get; set; }

        [Required(ErrorMessage ="This field is required")]
        public bool Discontinued { get; set; }

       
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string CategoryName { get; set; }

        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public string SupplierName { get; set; }
    }
}