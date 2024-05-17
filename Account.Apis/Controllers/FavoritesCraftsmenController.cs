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

        [HttpGet]
        public async Task<IActionResult> GetCraftsmanFavorites(string userId)
        {
            var favorites = await _favoriteForCraftsmenService.GetCraftsmanFavorites(userId);
            return Ok(favorites);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFavoriteCraftsman(int CraftsmanId)
        {
            var result = await _favoriteForCraftsmenService.RemoveAsync(CraftsmanId);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
