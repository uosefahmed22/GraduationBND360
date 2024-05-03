using Account.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Account
{
    public class Register
    {
        public string DisplayName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [MinLength(8, ErrorMessage = "Minimum allowed length is 8 characters")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        public UserRoleEnum UserRole { get; set; }
    }

}
