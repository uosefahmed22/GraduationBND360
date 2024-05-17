using Account.Apis.Errors;
using Account.Core.Dtos.Account;
using Account.Reposatory.Services.Authentications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProgfileService _progfileService;

        public ProfileController(IProgfileService progfileService)
        {
            _progfileService = progfileService;
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var response = await _progfileService.DeleteUserAsync(userId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfile(string userId)
        {
            var user = await _progfileService.GetProfileAsync(userId);
            if (user == null)
            {
                return NotFound(new ApiResponse(404, "User not found."));
            }
            return Ok(user);
        }

        [HttpPatch("updateImage")]
        public async Task<IActionResult> UpdateUserImage([FromForm] UpdateUserImageModel model)
        {
            var response = await _progfileService.UpdateUserImageAsync(model);
            return StatusCode(response.StatusCode, response);
        }


        [HttpPatch("{userId}/name")]
        public async Task<IActionResult> UpdateUserName(string userId, [FromBody] string newName)
        {
            var response = await _progfileService.UpdateUserNameAsync(userId, newName);
            return StatusCode(response.StatusCode, response);
        }
    }
}
