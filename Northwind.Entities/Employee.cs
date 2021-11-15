using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public class Employee : Base
    {
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        #region Relations
        public List<Order> Orders { get; set; } 
        #endregion
    }
}
