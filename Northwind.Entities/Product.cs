using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public class Product: Base
    {
       
        public int ProductId { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Required]
        public bool Discontinued { get; set; }

        #region Relations
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        #endregion




    }
}
