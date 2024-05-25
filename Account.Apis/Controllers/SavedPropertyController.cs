using Account.Core.Dtos.Saved;
using Account.Core.IServices.Content;
using Account.Reposatory.Services.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        [HttpDelete]
        public async Task<IActionResult> RemoveSavedProperty(int Propertyid, string userId)
        {
            var result = await _savedServiceForProperty.RemoveAsync(Propertyid, userId);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
