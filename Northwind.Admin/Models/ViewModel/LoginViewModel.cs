using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Admin.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is reired.")]
        [MinLength(3, ErrorMessage = "Check your password!")]
        [MaxLength(12, ErrorMessage = "Check your password!")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}