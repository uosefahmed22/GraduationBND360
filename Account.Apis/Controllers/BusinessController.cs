using Account.Apis.Errors;
using Account.Core.Dtos;
using Account.Core.Dtos.BusinessDto;
using Account.Core.Dtos.JobFolderDTO;
using Account.Core.IServices.Content;
using Account.Core.Models.Content;
using Account.Core.Services.Content;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _businessService;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public BusinessController(IBusinessService businessService,IFileService fileService,IMapper mapper)
        {
            _businessService = businessService;
            _fileService = fileService;
            _mapper = mapper;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddBusiness([FromForm] BusinessModelDto model)
        //{
        //    var status = new Status();
        //    if (!ModelState.IsValid)
        //    {
        //        status.StatusCode = 0;
        //        status.Message = "Please pass valid data.";
        //        return Ok(status);
        //    }

        //    if (model.ProfileImage != null)
        //    {
        //        var fileResult = _fileService.SaveImage(model.ProfileImage);

        //        if (fileResult.Item1 == 1)
        //        {
        //            model.ImageName = fileResult.Item2;
        //        }
        //        else
        //        {
        //            status.StatusCode = 0;
        //            status.Message = "Error saving profile image.";
        //            return Ok(status);
        //        }
        //    }
            
        //    if (model.BusinessImages != null && model.BusinessImages.Any())
        //    {
        //        var fileResult = _fileService.SaveImage(model.BusinessImages);
        //        if (fileResult.Item1 == 1)
        //        {
        //            model.ImageNames = fileResult.Item2.Select(fileName => new ImageNamesModel { ImageNames = fileName }).ToList();
        //        }
        //        else
        //        {
        //            status.StatusCode = 0;
        //            status.Message = "Error saving business images.";
        //            return Ok(status);
        //        }
        //    }

        //    try
        //    {
        //        var businessResult = await _businessService.CreateAsync(model);
        //        if (businessResult.StatusCode == 200)
        //        {
        //            status.StatusCode = 1;
        //            status.Message = "Business added successfully.";
        //        }
        //        else
        //        {
        //            status.StatusCode = 0;
        //            status.Message = "Error adding business: " + businessResult.Message;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        status.StatusCode = 0;
        //        status.Message = $"Error adding business: {ex.Message}";
        //    }

        //    return Ok(status);
        //}
        [HttpGet]
        public async Task<IActionResult> GetAllBusinesses()
        {
            try
            {
                var businesses = await _businessService.GetAllAsync();
                return Ok(businesses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("businesses/{id}")]
        public async Task<IActionResult> DeleteBusiness(int id)
        {
            var result = await _businessService.DeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("businesses/{id}")]
        public async Task<IActionResult> GetBusiness(int id)
        {
            var business = await _businessService.GetByIdAsync(id);
            if (business == null)
            {
                return NotFound();
            }
            return Ok(business);
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromForm] BusinessModelDto businessToUpdate)
        //{
        //    try
        //    {
        //        var existingBusiness = await _businessService.FindByIdAsync(id);
        //        if (existingBusiness == null)
        //            return StatusCode(StatusCodes.Status404NotFound,
        //                new Status
        //                {
        //                    StatusCode = 404,
        //                    Message = $"Business with id: {id} does not exist."
        //                });

        //        // Handle profile image
        //        if (businessToUpdate.ProfileImage != null)
        //        {
        //            var profileImageResult = _fileService.SaveImage(businessToUpdate.ProfileImage);
        //            if (profileImageResult.Item1 == 1)
        //            {
        //                businessToUpdate.ImageName = profileImageResult.Item2;
        //            }
        //            else
        //            {
        //                return StatusCode(StatusCodes.Status500InternalServerError, new Status
        //                {
        //                    StatusCode = 500,
        //                    Message = "Error saving profile image."
        //                });
        //            }
        //        }

        //        // Handle business images
        //        if (businessToUpdate.BusinessImages != null)
        //        {
        //            var fileResult = _fileService.SaveImages(businessToUpdate.BusinessImages);
        //            if (fileResult.Item1 == 1)
        //            {
        //                businessToUpdate.ImageNames = fileResult.Item2
        //                    .Select(imageName => new ImageNamesModel { ImageNames = imageName })
        //                    .ToList();
        //            }
        //        }

               

        //        // Clear the ImageNames collection
        //        existingBusiness.ImageNames = null;

        //        _mapper.Map(businessToUpdate, existingBusiness);
        //        await _businessService.UpdateAsync(id, businessToUpdate);

        //        return Ok(new Status
        //        {
        //            StatusCode = 200,
        //            Message = "Business updated successfully."
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Status
        //        {
        //            StatusCode = 500,
        //            Message = ex.Message
        //        });
        //    }
        //}

    }
}
