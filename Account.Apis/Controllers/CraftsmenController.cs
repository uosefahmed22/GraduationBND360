using Account.Core.Dtos.CraftsMenDtoFolder;
using Account.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Account.Core.IServices.Content;
using AutoMapper;
using Account.Core.Services.Content;
using Account.Apis.Errors;
using Account.Reposatory.Services.Content;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CraftsmenController : ControllerBase
    {
        private readonly ICraftsMenService _craftsmanService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public CraftsmenController(ICraftsMenService craftsMenService , IMapper mapper,IImageService fileService)
        {
            _craftsmanService = craftsMenService;
            _mapper = mapper;
            _imageService = fileService;
        }
        [HttpPost]
        public async Task<IActionResult> AddCraftsman([FromForm] CraftsMenModelDto model)
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
                    var fileResult = await _imageService.SaveImageAsync(model.ProfileImage);

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

                if (model.CraftsMenImage1 != null)
                {
                    var fileResult1 = await _imageService.SaveImageAsync(model.CraftsMenImage1);
                    if (fileResult1.Item1 == 1)
                    {
                        model.CraftsMenImageName1 = fileResult1.Item2;
                    }
                    else
                    {
                        status.StatusCode = 0;
                        status.Message = "Error saving image 1.";
                        return Ok(status);
                    }
                }

                if (model.CraftsMenImage2 != null)
                {
                    var fileResult2 = await _imageService.SaveImageAsync(model.CraftsMenImage2);
                    if (fileResult2.Item1 == 1)
                    {
                        model.CraftsMenImageName2 = fileResult2.Item2;
                    }
                    else
                    {
                        status.StatusCode = 0;
                        status.Message = "Error saving image 2.";
                        return Ok(status);
                    }
                }

                if (model.CraftsMenImage3 != null)
                {
                    var fileResult3 = await _imageService.SaveImageAsync(model.CraftsMenImage3);
                    if (fileResult3.Item1 == 1)
                    {
                        model.CraftsMenImageName3 = fileResult3.Item2;
                    }
                    else
                    {
                        status.StatusCode = 0;
                        status.Message = "Error saving image 3.";
                        return Ok(status);
                    }
                }

                if (model.CraftsMenImage4 != null)
                {
                    var fileResult4 = await _imageService.SaveImageAsync(model.CraftsMenImage4);
                    if (fileResult4.Item1 == 1)
                    {
                        model.CraftsMenImageName4 = fileResult4.Item2;
                    }
                    else
                    {
                        status.StatusCode = 0;
                        status.Message = "Error saving image 4.";
                        return Ok(status);
                    }
                }

                var craftsmanResult = await _craftsmanService.CreateCraftsMenAsync(model);
                if (craftsmanResult.StatusCode == 200)
                {
                    status.StatusCode = 1;
                    status.Message = "Craftsman added successfully.";
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Error adding craftsman: " + craftsmanResult.Message;
                }
            }
            catch (Exception ex)
            {
                status.StatusCode = 0;
                status.Message = $"Error adding craftsman: {ex.Message}";
            }

            return Ok(status);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCraftsman(int id)
        {
            var result = await _craftsmanService.DeleteCraftsMenAsync(id);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCraftsman(int id, [FromForm] CraftsMenModelDto craftsmanToUpdate)
        {
            try
            {
                var existingCraftsman = await _craftsmanService.FindByIdAsync(id);
                if (existingCraftsman == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        new Status
                        {
                            StatusCode = 404,
                            Message = $"Craftsman with id: {id} does not exist."
                        });
                }

                if (craftsmanToUpdate.ProfileImage != null)
                {
                    var profileImageResult = await _imageService.SaveImageAsync(craftsmanToUpdate.ProfileImage);
                    if (profileImageResult.Item1 == 1)
                    {
                        if (!string.IsNullOrEmpty(existingCraftsman.ProfileImageName))
                        {
                            await _imageService.DeleteImageAsync(existingCraftsman.ProfileImageName);
                        }
                        craftsmanToUpdate.ProfileImageName = profileImageResult.Item2;
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
                    craftsmanToUpdate.ProfileImageName = existingCraftsman.ProfileImageName;
                }

                string[] existingImageNames = { existingCraftsman.CraftsMenImageName1, existingCraftsman.CraftsMenImageName2, existingCraftsman.CraftsMenImageName3, existingCraftsman.CraftsMenImageName4 };
                IFormFile[] newImages = { craftsmanToUpdate.CraftsMenImage1, craftsmanToUpdate.CraftsMenImage2, craftsmanToUpdate.CraftsMenImage3, craftsmanToUpdate.CraftsMenImage4 };
                string[] newImageNames = { craftsmanToUpdate.CraftsMenImageName1, craftsmanToUpdate.CraftsMenImageName2, craftsmanToUpdate.CraftsMenImageName3, craftsmanToUpdate.CraftsMenImageName4 };

                for (int i = 0; i < newImages.Length; i++)
                {
                    if (newImages[i] != null)
                    {
                        var fileResult = await _imageService.SaveImageAsync(newImages[i]);
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
                                Message = $"Error saving craftsman image {i + 1}."
                            });
                        }
                    }
                    else
                    {
                        newImageNames[i] = existingImageNames[i];
                    }
                }

                craftsmanToUpdate.CraftsMenImageName1 = newImageNames[0];
                craftsmanToUpdate.CraftsMenImageName2 = newImageNames[1];
                craftsmanToUpdate.CraftsMenImageName3 = newImageNames[2];
                craftsmanToUpdate.CraftsMenImageName4 = newImageNames[3];

                _mapper.Map(craftsmanToUpdate, existingCraftsman);

                await _craftsmanService.UpdateCraftsMenAsync(id, craftsmanToUpdate);

                return Ok(new Status
                {
                    StatusCode = 200,
                    Message = "Craftsman updated successfully."
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCraftsman(int id)
        {
            var craftsman = await _craftsmanService.GetCraftsMenByIdAsync(id);
            if (craftsman == null)
            {
                return NotFound();
            }
            return Ok(craftsman);
        }

        [HttpGet("craftsman/{userId}")]
        public async Task<IActionResult> GetCraftsmenForUserAsync(string userId)
        {
            try
            {
                var craftsMen = await _craftsmanService.GetCraftsmenForUserAsync(userId);
                if (craftsMen == null)
                {
                    return NotFound(new ApiResponse(404, "Craftsman not found."));
                }
                return Ok(craftsMen);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse(500, $"An error occurred: {ex.Message}"));
            }
        }

        [HttpGet("GetAllCraftsmenWithDetails/{craftsId}")]
        public async Task<IActionResult> GetAllCraftsmenWithDetails(int craftsId)
        {
            try
            {
                var craftsmen = await _craftsmanService.GetAllCraftsmenWithDetailsAsync(craftsId);
                if (craftsmen == null || craftsmen.Count == 0)
                {
                    return NotFound(new ApiResponse(404, "No craftsmen found for the specified craft."));
                }
                return Ok(craftsmen);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}