using Account.Apis.Errors;
using Account.Core.Dtos.FavoirteDto;
using Account.Core.IServices.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesCraftsmenController : ControllerBase
    {
        private readonly IFavoriteForCraftsmenService _favoriteForCraftsmenService;

        public FavoritesCraftsmenController(IFavoriteForCraftsmenService favoriteForCraftsmenService)
        {
            _favoriteForCraftsmenService = favoriteForCraftsmenService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFavoriteCraftsman(FavoriteModelForCraftsmenDto savedModel)
        {
            var result = await _favoriteForCraftsmenService.AddAsync(savedModel);
            return StatusCode(result.StatusCode, result.Message);
        }

        [HttpGet("GetCraftsmanFavorites/{userId}")]
        public async Task<IActionResult> GetCraftsmanFavorites(string userId)
        {
            try
            {
                var favorites = await _favoriteForCraftsmenService.GetCraftsmanFavorites(userId);
                if (favorites == null || !favorites.Any())
                {
                    return NotFound(new ApiResponse(404, "No favorite craftsmen found."));
                }
                return Ok(favorites);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFavoriteCraftsman(int CraftsmanId, string userId)
        {
            var result = await _favoriteForCraftsmenService.RemoveAsync(CraftsmanId, userId);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
