using Account.Apis.Errors;
using Account.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Account
{
    public class UserDto :ApiResponse
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public UserRoleEnum Role { get; set; }
        public string Token { get; set; }
    }
}
