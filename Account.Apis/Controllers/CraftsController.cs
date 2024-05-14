using Account.Core.Dtos.CraftsFolder;
using Account.Core.IServices.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CraftsController : ControllerBase
    {
        private readonly ICraftsService _craftsService;

        public CraftsController(ICraftsService craftsService)
        {
            _craftsService = craftsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCraftAsync([FromBody] CraftsModelDto craft)
        {
            var result = await _craftsService.CreateCraftAsync(craft);
            return StatusCode(result.StatusCode, result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCraftAsync(int id)
        {
            var result = await _craftsService.DeleteCraftAsync(id);
            return StatusCode(result.StatusCode, result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCraftByIdAsync(int id)
        {
            var craft = await _craftsService.GetCraftByIdAsync(id);
            if (craft == null)
            {
                return NotFound("Craft not found");
            }
            return Ok(craft);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCraftsAsync()
        {
            var crafts = await _craftsService.GetAllCraftsAsync();
            return Ok(crafts);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCraftAsync(int id, [FromBody] CraftsModelDto craft)
        {
            var result = await _craftsService.UpdateCraftAsync(id, craft);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
