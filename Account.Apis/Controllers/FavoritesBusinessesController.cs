using Account.Apis.Errors;
using Account.Core.Dtos.FavoirteDto;
using Account.Core.IServices.Content;
using Account.Reposatory.Services.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesBusinessesController : ControllerBase
    {
        private readonly IFavoriteForBusinessService _favoriteForBusinessService;

        public FavoritesBusinessesController(IFavoriteForBusinessService favoriteForBusinessService)
        {
            _favoriteForBusinessService = favoriteForBusinessService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFavoriteBusiness(FavoriteModelForBusinessDto savedModel)
        {
            var result = await _favoriteForBusinessService.AddAsync(savedModel);
            return StatusCode(result.StatusCode, result.Message);
        }

        [HttpGet("GetBusinessReviewSummary/{userId}")]
        public async Task<IActionResult> GetBusinessReviewSummary(string userId)
        {
            try
            {
                var reviewSummary = await _favoriteForBusinessService.GetBusinesses(userId);
                if (reviewSummary == null)
                {
                    return NotFound(new ApiResponse(404, "Business not found."));
                }
                return Ok(reviewSummary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveFavoriteBusiness(int businessId)
        {
            var result = await _favoriteForBusinessService.RemoveAsync(businessId);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
