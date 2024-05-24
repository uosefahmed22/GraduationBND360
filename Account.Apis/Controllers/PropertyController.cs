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
            var status = new Status();
            if (id != propertyToUpdate.Id)
            {
                status.StatusCode = 400;
                status.Message = "Id in URL and form body does not match.";
                return BadRequest(status);
            }

            var existingProperty = await _propertyService.FindByIdAsync(id);
            if (existingProperty == null)
            {
                status.StatusCode = 404;
                status.Message = $"Property with ID: {id} does not exist.";
                return NotFound(status);
            }

            var imageTasks = new List<Task<Tuple<int, string>>>();
            if (propertyToUpdate.image1 != null)
                imageTasks.Add(_imageService.UploadImageAsync(propertyToUpdate.image1));
            if (propertyToUpdate.image2 != null)
                imageTasks.Add(_imageService.UploadImageAsync(propertyToUpdate.image2));
            if (propertyToUpdate.image3 != null)
                imageTasks.Add(_imageService.UploadImageAsync(propertyToUpdate.image3));
            if (propertyToUpdate.image4 != null)
                imageTasks.Add(_imageService.UploadImageAsync(propertyToUpdate.image4));

            var imageResults = await Task.WhenAll(imageTasks);

            if (propertyToUpdate.image1 != null && imageResults[0].Item1 == 1)
            {
                if (!string.IsNullOrEmpty(existingProperty.ImageName1))
                    await _imageService.DeleteImageAsync(existingProperty.ImageName1);
                propertyToUpdate.ImageName1 = imageResults[0].Item2;
            }

            if (propertyToUpdate.image2 != null && imageResults[1].Item1 == 1)
            {
                if (!string.IsNullOrEmpty(existingProperty.ImageName2))
                    await _imageService.DeleteImageAsync(existingProperty.ImageName2);
                propertyToUpdate.ImageName2 = imageResults[1].Item2;
            }

            if (propertyToUpdate.image3 != null && imageResults[2].Item1 == 1)
            {
                if (!string.IsNullOrEmpty(existingProperty.ImageName3))
                    await _imageService.DeleteImageAsync(existingProperty.ImageName3);
                propertyToUpdate.ImageName3 = imageResults[2].Item2;
            }

            if (propertyToUpdate.image4 != null && imageResults[3].Item1 == 1)
            {
                if (!string.IsNullOrEmpty(existingProperty.ImageName4))
                    await _imageService.DeleteImageAsync(existingProperty.ImageName4);
                propertyToUpdate.ImageName4 = imageResults[3].Item2;
            }

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
    }
}