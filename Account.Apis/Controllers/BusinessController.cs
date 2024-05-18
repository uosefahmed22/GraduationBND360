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

        public BusinessController(IBusinessService businessService, IFileService fileService, IMapper mapper)
        {
            _businessService = businessService;
            _fileService = fileService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddBusiness([FromForm] BusinessModelDto model)
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
                if (model.ProfileImage == null)
                {
                    status.StatusCode = 0;
                    status.Message = "Profile image is required.";
                    return Ok(status);
                }
                else
                {
                    var fileResult = _fileService.SaveImage(model.ProfileImage);

                    if (fileResult.Item1 == 1)
                    {
                        model.ProfileImageName = fileResult.Item2;
                    }
                    else
                    {
                        status.StatusCode = 0;
                        status.Message = "Error saving profile image.";
                        return Ok(status);
                    }
                }

                if (model.BusinessImage1 != null)
                {
                    var fileResult1 = _fileService.SaveImage(model.BusinessImage1);
                    if (fileResult1.Item1 == 1)
                    {
                        model.BusinessImageName1 = fileResult1.Item2;
                    }
                    else
                    {
                        status.StatusCode = 0;
                        status.Message = "Error saving image 1.";
                        return Ok(status);
                    }
                }

                if (model.BusinessImage2 != null)
                {
                    var fileResult2 = _fileService.SaveImage(model.BusinessImage2);
                    if (fileResult2.Item1 == 1)
                    {
                        model.BusinessImageName2 = fileResult2.Item2;
                    }
                    else
                    {
                        status.StatusCode = 0;
                        status.Message = "Error saving image 2.";
                        return Ok(status);
                    }
                }

                if (model.BusinessImage3 != null)
                {
                    var fileResult3 = _fileService.SaveImage(model.BusinessImage3);
                    if (fileResult3.Item1 == 1)
                    {
                        model.BusinessImageName3 = fileResult3.Item2;
                    }
                    else
                    {
                        status.StatusCode = 0;
                        status.Message = "Error saving image 3.";
                        return Ok(status);
                    }
                }

                if (model.BusinessImage4 != null)
                {
                    var fileResult4 = _fileService.SaveImage(model.BusinessImage4);
                    if (fileResult4.Item1 == 1)
                    {
                        model.BusinessImageName4 = fileResult4.Item2;
                    }
                    else
                    {
                        status.StatusCode = 0;
                        status.Message = "Error saving image 4.";
                        return Ok(status);
                    }
                }

                var businessResult = await _businessService.CreateAsync(model);
                if (businessResult.StatusCode == 200)
                {
                    status.StatusCode = 1;
                    status.Message = "Business added successfully.";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error adding business: " + businessResult.Message;
                }
            }
            catch (Exception ex)
            {
                status.StatusCode = 0;
                status.Message = $"Error adding business: {ex.Message}";
            }

            return Ok(status);
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(int id)
        {
            var result = await _businessService.DeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusiness(int id)
        {
            var business = await _businessService.GetByIdAsync(id);
            if (business == null)
            {
                return NotFound();
            }
            return Ok(business);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBusiness(int id, [FromForm] BusinessModelDto businessToUpdate)
        {
            try
            {
                var existingBusiness = await _businessService.FindByIdAsync(id);
                if (existingBusiness == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        new Status
                        {
                            StatusCode = 404,
                            Message = $"Business with id: {id} does not exist."
                        });
                }

                if (businessToUpdate.ProfileImage != null)
                {
                    var profileImageResult = _fileService.SaveImage(businessToUpdate.ProfileImage);
                    if (profileImageResult.Item1 == 1)
                    {
                        if (!string.IsNullOrEmpty(existingBusiness.ProfileImageName))
                        {
                            await _fileService.DeleteImage(existingBusiness.ProfileImageName);
                        }
                        businessToUpdate.ProfileImageName = profileImageResult.Item2;
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new Status
                        {
                            StatusCode = 500,
                            Message = "Error saving profile image."
                        });
                    }
                }
                else
                {
                    businessToUpdate.ProfileImageName = existingBusiness.ProfileImageName;
                }

                string[] existingImageNames = { existingBusiness.BusinessImageName1, existingBusiness.BusinessImageName2, existingBusiness.BusinessImageName3, existingBusiness.BusinessImageName4 };
                IFormFile[] newImages = { businessToUpdate.BusinessImage1, businessToUpdate.BusinessImage2, businessToUpdate.BusinessImage3, businessToUpdate.BusinessImage4 };
                string[] newImageNames = { businessToUpdate.BusinessImageName1, businessToUpdate.BusinessImageName2, businessToUpdate.BusinessImageName3, businessToUpdate.BusinessImageName4 };

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
                        else
                        {
                            return StatusCode(StatusCodes.Status500InternalServerError, new Status
                            {
                                StatusCode = 500,
                                Message = $"Error saving business image {i + 1}."
                            });
                        }
                    }
                    else
                    {
                        newImageNames[i] = existingImageNames[i];
                    }
                }

                businessToUpdate.BusinessImageName1 = newImageNames[0];
                businessToUpdate.BusinessImageName2 = newImageNames[1];
                businessToUpdate.BusinessImageName3 = newImageNames[2];
                businessToUpdate.BusinessImageName4 = newImageNames[3];

                _mapper.Map(businessToUpdate, existingBusiness);

                await _businessService.UpdateAsync(id, businessToUpdate);

                return Ok(new Status
                {
                    StatusCode = 200,
                    Message = "Business updated successfully."
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

        [HttpGet("business-owner/{userId}")]
        public async Task<IActionResult> GetBusinessForBusinessOwnerAsync(string userId)
        {
            try
            {
                var business = await _businessService.GetBusinessForBusinessOwnerAsync(userId);
                if (business == null)
                {
                    return NotFound(new ApiResponse(404, "Business not found."));
                }
                return Ok(business);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, $"An error occurred: {ex.Message}"));
            }
        }

        [HttpGet("all-businessesWithReviewsAndCategories")]
        public async Task<IActionResult> GetAllBusinessesWithDetails()
        {
            try
            {
                var businessResponses = await _businessService.GetAllBusinessesWithDetailsAsync();
                if (businessResponses == null || businessResponses.Count == 0)
                {
                    return NotFound(new ApiResponse(404, "No businesses found."));
                }
                return Ok(businessResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, $"An error occurred: {ex.Message}"));
            }
        }

        [HttpGet("BusinessByCategory/{CategoeryId}")]
        public async Task<IActionResult> GetBusinessByCategoryAsync(int CategoeryId)
        {
            try
            {
                var business = await _businessService.GetBusinessByCategoryAsync(CategoeryId);
                if (business == null)
                {
                    return NotFound(new ApiResponse(404, "Category not found."));
                }
                return Ok(business);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, $"An error occurred: {ex.Message}"));
            }
        }
    }
}
