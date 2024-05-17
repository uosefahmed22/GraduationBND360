using Account.Core.Dtos;
using Account.Core.IServices.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedPropertyController : ControllerBase
    {
        private readonly ISavedServiceForProperty _savedServiceForProperty;
        public SavedPropertyController(ISavedServiceForProperty savedServiceForProperty)
        {
            _savedServiceForProperty = savedServiceForProperty;

        }

        [HttpPost]
        public async Task<IActionResult> AddProperty(SavedModelForPropertyDto savedModel)
        {
            var result = await _savedServiceForProperty.AddAsync(savedModel);
            return StatusCode(result.StatusCode, result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetProperty(string userId)
        {
            var properties = await _savedServiceForProperty.GetProperty(userId);
            return Ok(properties);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProperty(int id)
        {
            var result = await _savedServiceForProperty.RemoveAsync(id);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
