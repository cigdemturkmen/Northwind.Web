using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Admin.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(3, ErrorMessage = "Password must have at least 3 characters!")]
        [MaxLength(12, ErrorMessage = "Password must not exceed 12 chracters!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be no longer than 50 characters!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be no longer than 100 characters!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Rewrite your password to confirm.")]
        [StringLength(12, ErrorMessage = "Password must have between 3-12 chracters.", MinimumLength = 3)]
        [Compare(nameof(Password), ErrorMessage = "Password confirmation does not match!")]
        [DisplayName("Password Confirm")]
        public string PasswordConfirm { get; set; }
    }
}