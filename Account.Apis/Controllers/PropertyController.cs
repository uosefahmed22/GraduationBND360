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

            if (model.image1 == null)
            {
                status.StatusCode = 0;
                status.Message = "Image1 is required.";
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

                if (model.image2 != null)
                {
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
                }

                if (model.image3 != null)
                {
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
                }

                if (model.image4 != null)
                {
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

                // Handle images
                string[] existingImageNames = { existingProperty.ImageName1, existingProperty.ImageName2, existingProperty.ImageName3, existingProperty.ImageName4 };
                IFormFile[] newImages = { propertyToUpdate.image1, propertyToUpdate.image2, propertyToUpdate.image3, propertyToUpdate.image4 };
                string[] newImageNames = { propertyToUpdate.ImageName1, propertyToUpdate.ImageName2, propertyToUpdate.ImageName3, propertyToUpdate.ImageName4 };

                for (int i = 0; i < newImages.Length; i++)
                {
                    if (newImages[i] != null)
                    {
                        var fileResult = _fileService.SaveImage(newImages[i]);
                        if (fileResult.Item1 == 1)
                        {
                            if (!string.IsNullOrEmpty(existingImageNames[i]))
                            {
                                await _fileService.DeleteImage(existingImageNames[i]);
                            }
                            newImageNames[i] = fileResult.Item2;
                        }
                    }
                    else
                    {
                        newImageNames[i] = existingImageNames[i];
                    }
                }

                propertyToUpdate.ImageName1 = newImageNames[0];
                propertyToUpdate.ImageName2 = newImageNames[1];
                propertyToUpdate.ImageName3 = newImageNames[2];
                propertyToUpdate.ImageName4 = newImageNames[3];

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