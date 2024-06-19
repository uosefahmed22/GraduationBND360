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
using Account.Reposatory.Services.Content;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public PropertyController(IPropertyService propertyService, IImageService fileService,IMapper mapper)
        {
            _propertyService = propertyService;
            _imageService = fileService;
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

            var imageTasks = new List<Task<Tuple<int, string>>>();

            if (model.image1 != null)
                imageTasks.Add(_imageService.UploadImageAsync(model.image1));
            if (model.image2 != null)
                imageTasks.Add(_imageService.UploadImageAsync(model.image2));
            if (model.image3 != null)
                imageTasks.Add(_imageService.UploadImageAsync(model.image3));
            if (model.image4 != null)
                imageTasks.Add(_imageService.UploadImageAsync(model.image4));

            var imageResults = await Task.WhenAll(imageTasks);

            if (model.image1 != null && imageResults[0].Item1 == 1)
                model.ImageName1 = imageResults[0].Item2;
            else if (model.image1 != null)
            {
                status.StatusCode = 0;
                status.Message = imageResults[0].Item2;
                return Ok(status);
            }

            if (model.image2 != null && imageResults[1].Item1 == 1)
                model.ImageName2 = imageResults[1].Item2;
            else if (model.image2 != null)
            {
                status.StatusCode = 0;
                status.Message = imageResults[1].Item2;
                return Ok(status);
            }

            if (model.image3 != null && imageResults[2].Item1 == 1)
                model.ImageName3 = imageResults[2].Item2;
            else if (model.image3 != null)
            {
                status.StatusCode = 0;
                status.Message = imageResults[2].Item2;
                return Ok(status);
            }

            if (model.image4 != null && imageResults[3].Item1 == 1)
                model.ImageName4 = imageResults[3].Item2;
            else if (model.image4 != null)
            {
                status.StatusCode = 0;
                status.Message = imageResults[3].Item2;
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
        public async Task<IActionResult> UpdateProperty(int id, [FromForm] PropertyModelDTO propertyToUpdate)
        {
            try
            {
                if (id != propertyToUpdate.Id)
                {
                    return BadRequest(new Status
                    {
                        StatusCode = 400,
                        Message = "Id in URL and form body does not match."
                    });
                }

                var existingProperty = await _propertyService.FindByIdAsync(id);
                if (existingProperty == null)
                {
                    return NotFound(new Status
                    {
                        StatusCode = 404,
                        Message = $"Property with ID: {id} does not exist."
                    });
                }

                string[] existingImageNames = { existingProperty.ImageName1, existingProperty.ImageName2, existingProperty.ImageName3, existingProperty.ImageName4 };
                IFormFile[] newImages = { propertyToUpdate.image1, propertyToUpdate.image2, propertyToUpdate.image3, propertyToUpdate.image4 };
                string[] newImageNames = { propertyToUpdate.ImageName1, propertyToUpdate.ImageName2, propertyToUpdate.ImageName3, propertyToUpdate.ImageName4 };

                for (int i = 0; i < newImages.Length; i++)
                {
                    if (newImages[i] != null)
                    {
                        var fileResult = await _imageService.UploadImageAsync(newImages[i]);
                        if (fileResult.Item1 == 1)
                        {
                            if (!string.IsNullOrEmpty(existingImageNames[i]))
                            {
                                await _imageService.DeleteImageAsync(existingImageNames[i]);
                            }
                            newImageNames[i] = fileResult.Item2;
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, new Status
                            {
                                StatusCode = 500,
                                Message = $"Error saving property image {i + 1}."
                            });
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

                var result = await _propertyService.UpdatePropertyAsync(id, propertyToUpdate);
                return StatusCode(result.StatusCode, new Status
                {
                    StatusCode = result.StatusCode,
                    Message = result.Message
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