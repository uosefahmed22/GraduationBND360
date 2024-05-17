using Account.Core.Dtos.FavoirteDto;
using Account.Core.IServices.Content;
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

        [HttpGet]
        public async Task<IActionResult> GetFavoriteBusinesses(string userId)
        {
            var businesses = await _favoriteForBusinessService.GetBusinesses(userId);
            return Ok(businesses);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFavoriteBusiness(int businessId)
        {
            var result = await _favoriteForBusinessService.RemoveAsync(businessId);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
