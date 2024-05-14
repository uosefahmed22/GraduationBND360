using Account.Core.Dtos;
using Account.Core.IServices.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Account.Core.Services.Content;
using Account.Core.Dtos.PropertyFolderDto;
using AutoMapper;
using Account.Core.Models.Content.Properties;
using Account.Core.Models.Content;
using Account.Core.Dtos.JobFolderDTO;

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

            try
            {
                var fileResult1 = _fileService.SaveImage(model.image1);
                if (fileResult1.Item1 == 1)
                {
                    model.ImageName1 = fileResult1.Item2;
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error saving image 1.";
                    return Ok(status);
                }

                var fileResult2 = _fileService.SaveImage(model.image2);
                if (fileResult2.Item1 == 1)
                {
                    model.ImageName2 = fileResult2.Item2;
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error saving image 2.";
                    return Ok(status);
                }

                var fileResult3 = _fileService.SaveImage(model.image3);
                if (fileResult3.Item1 == 1)
                {
                    model.ImageName3 = fileResult3.Item2;
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error saving image 3.";
                    return Ok(status);
                }

                var fileResult4 = _fileService.SaveImage(model.image4);
                if (fileResult4.Item1 == 1)
                {
                    model.ImageName4 = fileResult4.Item2;
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error saving image 4.";
                    return Ok(status);
                }

                var propertyResult = await _propertyService.CreatePropertyAsync(model);
                if (propertyResult.StatusCode == 200)
                {
                    status.StatusCode = 1;
                    status.Message = "Property added successfully.";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = $"Error adding property: {propertyResult.Message}";
                }
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var result = await _propertyService.DeletePropertyAsync(id);
            return StatusCode(result.StatusCode, result);
        }
        [HttpGet("{id}")]
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
                if (id != propertyToUpdate.Id)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        new Status
                        {
                            StatusCode = 400,
                            Message = "Id in URL and form body does not match."
                        });
                }

                var existingProperty = await _propertyService.FindByIdAsync(id);
                if (existingProperty == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        new Status
                        {
                            StatusCode = 404,
                            Message = $"Property with id: {id} does not exist."
                        });
                }

                if (propertyToUpdate.image1 != null)
                {
                    var fileResult = _fileService.SaveImage(propertyToUpdate.image1);
                    if (fileResult.Item1 == 1)
                    {
                        propertyToUpdate.ImageName1 = fileResult.Item2;
                    }
                }
                if (propertyToUpdate.image2 != null)
                {
                    var fileResult = _fileService.SaveImage(propertyToUpdate.image2);
                    if (fileResult.Item1 == 1)
                    {
                        propertyToUpdate.ImageName2 = fileResult.Item2;
                    }
                }
                if (propertyToUpdate.image3 != null)
                {
                    var fileResult = _fileService.SaveImage(propertyToUpdate.image3);
                    if (fileResult.Item1 == 1)
                    {
                        propertyToUpdate.ImageName3 = fileResult.Item2;
                    }
                }
                if (propertyToUpdate.image4 != null)
                {
                    var fileResult = _fileService.SaveImage(propertyToUpdate.image4);
                    if (fileResult.Item1 == 1)
                    {
                        propertyToUpdate.ImageName4 = fileResult.Item2;
                    }
                }

                if (existingProperty.ImageName1 != null && existingProperty.ImageName1 != propertyToUpdate.ImageName1)
                {
                    await _fileService.DeleteImage(existingProperty.ImageName1);
                }
                if (existingProperty.ImageName2 != null && existingProperty.ImageName2 != propertyToUpdate.ImageName2)
                {
                    await _fileService.DeleteImage(existingProperty.ImageName2);
                }
                if (existingProperty.ImageName3 != null && existingProperty.ImageName3 != propertyToUpdate.ImageName3)
                {
                    await _fileService.DeleteImage(existingProperty.ImageName3);
                }
                if (existingProperty.ImageName4 != null && existingProperty.ImageName4 != propertyToUpdate.ImageName4)
                {
                    await _fileService.DeleteImage(existingProperty.ImageName4);
                }

                _mapper.Map(propertyToUpdate, existingProperty);

                if (propertyToUpdate.PublisherDetails != null)
                {
                    _mapper.Map(propertyToUpdate.PublisherDetails, existingProperty.PublisherDetails);
                }

                await _propertyService.UpdatePropertyAsync(id, propertyToUpdate);

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