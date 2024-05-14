using Account.Core.Dtos.CategoriesDto;
using Account.Core.Dtos;
using Account.Core.Services.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Account.Core.IServices.Content;
using AutoMapper;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoryRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesService categoryRepository, IFileService fileService, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Add([FromForm] CategoriesModelDTO model)
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
                var fileResult = _fileService.SaveImage(model.Image);

                if (fileResult.Item1 == 1)
                {
                    model.ImageFileName = fileResult.Item2;
                }
            }

            var categoryResult = _categoryRepository.CreateCategoryAsync(model).Result;
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
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryRepository.DeleteCategoryAsync(id);
            return StatusCode(result.StatusCode, result);
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
            try
            {
                if (id != categoryToUpdate.Id)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        new Status
                        {
                            StatusCode = 400,
                            Message = "Id in URL and form body does not match."
                        });
                }

                var existingCategory = await _categoryRepository.FindByIdAsync(id);
                if (existingCategory == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        new Status
                        {
                            StatusCode = 404,
                            Message = $"Category with ID: {id} does not exist."
                        });
                }

                if (categoryToUpdate.Image != null)
                {
                    var fileResult = _fileService.SaveImage(categoryToUpdate.Image);
                    if (fileResult.Item1 == 1)
                    {
                        categoryToUpdate.ImageFileName = fileResult.Item2;
                    }
                }

                _mapper.Map(categoryToUpdate, existingCategory);

                var result = await _categoryRepository.UpdateCategoryAsync(id, categoryToUpdate);

                if (categoryToUpdate.Image != null)
                {
                    await _fileService.DeleteImage(existingCategory.ImageFileName);
                }

                return StatusCode(result.StatusCode,
                    new Status
                    {
                        StatusCode = result.StatusCode,
                        Message = result.Message
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Status
                    {
                        StatusCode = 500,
                        Message = ex.Message
                    });
            }
        }

    }
}

