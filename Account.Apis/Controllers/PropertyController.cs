using Account.Core.Dtos;
using Account.Core.IServices.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Account.Core.Services.Content;
using Account.Core.Dtos.PropertyFolderDto;
using AutoMapper;
using Account.Core.Models.Content.Properties;
using Account.Core.Models.Content;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public PropertyController(IPropertyService propertyService, IFileService fileService,IMapper mapper)
        {
            _propertyService = propertyService;
            _fileService = fileService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddProperty([FromForm] PropertyModelDTO model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass valid data.";
                return Ok(status);
            }

            if (model.images != null && model.images.Any())
            {
                var fileResult = _fileService.SaveImages(model.images);
                if (fileResult.Item1 == 1)
                {
                    model.ImageNames = fileResult.Item2.Select(fileName => new ImageNamesModelDto { ImageNames = fileName }).ToList();
                }

                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error saving image.";
                    return Ok(status);
                }
            }

            try
            {
                var propertyResult = await _propertyService.CreatePropertyAsync(model);
                status.StatusCode = 1;
                status.Message = "Property added successfully.";
            }
            catch (Exception ex)
            {
                status.StatusCode = 0;
                status.Message = $"Error adding property: {ex.Message}";
            }

            return Ok(status);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProperties()
        {
            try
            {
                var properties = await _propertyService.GetAllPropertiesAsync();
                return Ok(properties);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("properties/{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var result = await _propertyService.DeletePropertyAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("properties/{id}")]
        public async Task<IActionResult> GetProperty(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] PropertyModelDTO propertyToUpdate)
        {
            try
            {
                var existingProperty = await _propertyService.FindByIdAsync(id);
                if (existingProperty == null)
                    return StatusCode(StatusCodes.Status404NotFound,
                        new Status
                        {
                            StatusCode = 404,
                            Message = $"Property with id: {id} does not exist."
                        });

                if (propertyToUpdate.images != null)
                {
                    var fileResult = _fileService.SaveImages(propertyToUpdate.images);
                    if (fileResult.Item1 == 1)
                    {
                        propertyToUpdate.ImageNames = fileResult.Item2
                            .Select(imageName => new ImageNamesModelDto { ImageNames = imageName })
                            .ToList();
                    }
                }

                string[] oldImageNames = existingProperty.ImageNames?.Select(image => image.ImageNames).ToArray();

                _mapper.Map(propertyToUpdate, existingProperty);
                await _propertyService.UpdatePropertyAsync(id, propertyToUpdate);

                // Delete old images
                if (oldImageNames != null)
                {
                    foreach (var oldImageName in oldImageNames)
                    {
                        await _fileService.DeleteImage(oldImageName);
                    }
                }

                return Ok(new Status
                {
                    StatusCode = 200,
                    Message = "Property updated successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Status
                {
                    StatusCode = 500,
                    Message = ex.Message
                });
            }
        }

    }
}