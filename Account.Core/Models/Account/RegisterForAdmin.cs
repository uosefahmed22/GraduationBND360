using Account.Core.Enums.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Account
{
    public class RegisterForAdmin
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public UserRoleEnum UserRole { get; set; } = UserRoleEnum.Admin;
    }
}
