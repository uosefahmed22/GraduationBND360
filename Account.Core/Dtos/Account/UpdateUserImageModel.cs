using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Account
{
    public class UpdateUserImageModel
    {
        public string Id { get; set; }
        public string? ProfileImagename { get; set; }
        public IFormFile image { get; set; }
    }
}
