﻿using Account.Apis.Errors;
using Account.Core.Dtos.Account;
using Account.Core.Models.Account;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Services.Authentications
{
    public interface IProgfileService
    {
        Task<AppUserDto> GetProfileAsync(string userId);
        Task<ApiResponse> DeleteUserAsync(string userId);
        Task<ApiResponse> UpdateUserNameAsync(string userId, string newName);
        Task<ApiResponse> UpdateUserImageAsync(UpdateUserImageModel model);
    }
}
