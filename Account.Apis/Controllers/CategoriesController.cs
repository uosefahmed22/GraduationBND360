using Account.Core.Dtos.CategoriesDto;
using Account.Core.Dtos;
using Account.Core.Services.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Account.Core.IServices.Content;
using AutoMapper;
using Account.Reposatory.Services.Content;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoryRepository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesService categoryRepository, IImageService fileService, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _imageService = fileService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CategoriesModelDTO model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass valid data";
                return Ok(status);
            }

            if (model.Image != null)
            {
                var fileResult = await _imageService.SaveImageAsync(model.Image);
                if (fileResult.Item1 == 1)
                {
                    model.ImageFileName = fileResult.Item2;
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = fileResult.Item2;
                    return Ok(status);
                }
            }

            var categoryResult = await _categoryRepository.CreateCategoryAsync(model);
            if (categoryResult.StatusCode == 200)
            {
                status.StatusCode = 1;
                status.Message = "Category added successfully";
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Error adding category: " + categoryResult.Message;
            }

            return Ok(status);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryRepository.DeleteCategoryAsync(id);

            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromForm] CategoriesModelDTO categoryToUpdate)
        {
            var status = new Status();
            if (id != categoryToUpdate.Id)
            {
                status.StatusCode = 400;
                status.Message = "Id in URL and form body does not match.";
                return BadRequest(status);
            }

            var existingCategory = await _categoryRepository.FindByIdAsync(id);
            if (existingCategory == null)
            {
                status.StatusCode = 404;
                status.Message = $"Category with ID: {id} does not exist.";
                return NotFound(status);
            }

            if (categoryToUpdate.Image != null)
            {
                if (!string.IsNullOrEmpty(existingCategory.ImageFileName))
                {
                    await _imageService.DeleteImageAsync(existingCategory.ImageFileName);
                }

                var fileResult = await _imageService.SaveImageAsync(categoryToUpdate.Image);
                if (fileResult.Item1 == 1)
                {
                    categoryToUpdate.ImageFileName = fileResult.Item2;
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = fileResult.Item2;
                    return BadRequest(status);
                }
            }

            var result = await _categoryRepository.UpdateCategoryAsync(id, categoryToUpdate);
            return StatusCode(result.StatusCode, new Status
            {
                StatusCode = result.StatusCode,
                Message = result.Message
            });
        }

    }
}

