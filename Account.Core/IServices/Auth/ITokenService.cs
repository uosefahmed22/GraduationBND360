using Account.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Services.Auth
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
