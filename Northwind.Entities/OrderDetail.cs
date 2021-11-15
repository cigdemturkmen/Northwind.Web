using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    [Table("Order Details")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public short Quantity { get; set; } //smallint

        [Required]
        public float Discount { get; set; } //real
    }
}
