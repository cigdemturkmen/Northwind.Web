using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Admin.Models.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="This field is required!")]
        [StringLength(20, ErrorMessage = "Last name must be no longer than 40 characters!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [StringLength(10, ErrorMessage = "First name must be no longer than 10 characters!")]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage = "Use maximum 30 characters!")]
        public string Title { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }

        [StringLength(60, ErrorMessage = "Use maximum 60 characters!")]
        public string Address { get; set; }

        [StringLength(24, ErrorMessage = "Use maximum 24 characters!")]
        public string Phone { get; set; }

    }
}