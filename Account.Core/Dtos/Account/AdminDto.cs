using Account.Apis.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Account
{
    public class AdminDto : ApiResponse
    {
        public string id { get; set; }
        public string Token { get; set; }
    }
}
