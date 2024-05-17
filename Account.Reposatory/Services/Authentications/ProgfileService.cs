using Account.Apis.Errors;
using Account.Core.Dtos.Account;
using Account.Core.Models.Account;
using Account.Core.Services.Content;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Services.Authentications
{
    public class ProgfileService : IProgfileService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public ProgfileService(UserManager<AppUser> userManager , IFileService fileService,IMapper mapper)
        {
            _userManager = userManager;
            _fileService = fileService;
            _mapper = mapper;
        }
        public async Task<ApiResponse> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ApiResponse(404, "User not found.");
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return new ApiResponse(200, "User deleted successfully.");
            }
            else
            {
                return new ApiResponse(400, "Failed to delete user.");
            }
        }
        public async Task<AppUserDto> GetProfileAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }
            var userDto = _mapper.Map<AppUserDto>(user);
            return userDto;
        }

        public async Task<ApiResponse> UpdateUserImageAsync(UpdateUserImageModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return new ApiResponse(404, "User not found.");
                }

                var saveResult = _fileService.SaveImage(model.image);
                if (saveResult.Item1 == 0)
                {
                    return new ApiResponse(400, saveResult.Item2);
                }

                if (!string.IsNullOrEmpty(user.profileImageName))
                {
                    await _fileService.DeleteImage(user.profileImageName);
                }

                user.profileImageName = saveResult.Item2;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return new ApiResponse(200, "User image updated successfully.");
                }
                else
                {
                    return new ApiResponse(400, "Failed to update user image.");
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"An error occurred: {ex.Message}");
            }
        }

        public async Task<ApiResponse> UpdateUserNameAsync(string userId, string newName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ApiResponse(404, "User not found.");
            }

            user.DisplayName = newName;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiResponse(200, "User name updated successfully.");
            }
            else
            {
                return new ApiResponse(400, "Failed to update user name.");
            }
        }
    }
}
