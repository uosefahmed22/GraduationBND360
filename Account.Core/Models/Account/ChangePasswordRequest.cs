using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Account
{
    public class ChangePasswordRequest
    {
        public Guid UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }


}
