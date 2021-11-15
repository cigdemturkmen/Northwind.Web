using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }

        [Required]
        [StringLength(60)]
        public string ShipAddress { get; set; }


        #region Relations
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Shipper")]
        public int? ShipVia { get; set; }
        public Shipper Shipper { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        #endregion
    }
}
