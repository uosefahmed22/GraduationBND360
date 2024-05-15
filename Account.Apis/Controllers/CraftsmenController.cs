using Account.Core.Dtos.CraftsMenDtoFolder;
using Account.Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Account.Core.IServices.Content;
using AutoMapper;
using Account.Core.Services.Content;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CraftsmenController : ControllerBase
    {
        private readonly ICraftsMenService _craftsmanService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public CraftsmenController(ICraftsMenService craftsMenService , IMapper mapper,IFileService fileService)
        {
            _craftsmanService = craftsMenService;
            _mapper = mapper;
            _fileService = fileService;
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
                if (model.ProfileImage != null)
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

                // Save other images
                var fileResult1 = _fileService.SaveImage(model.CraftsMenImage1);
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

                var fileResult2 = _fileService.SaveImage(model.CraftsMenImage2);
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

                var fileResult3 = _fileService.SaveImage(model.CraftsMenImage3);
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

                var fileResult4 = _fileService.SaveImage(model.CraftsMenImage4);
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

                // Create the craftsman
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

        [HttpGet]
        public async Task<IActionResult> GetAllCraftsmen()
        {
            try
            {
                var craftsmen = await _craftsmanService.GetAllCraftsMenAsync();
                return Ok(craftsmen);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCraftsman(int id)
        {
            var result = await _craftsmanService.DeleteCraftsMenAsync(id);
            return StatusCode(result.StatusCode, result);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCraftsman(int id, [FromForm] CraftsMenModelDto craftsmanToUpdate)
        {
            try
            {
                var existingCraftsman = await _craftsmanService.FindByIdAsync(id);
                if (existingCraftsman == null)
                    return StatusCode(StatusCodes.Status404NotFound,
                        new Status
                        {
                            StatusCode = 404,
                            Message = $"Craftsman with id: {id} does not exist."
                        });

                if (craftsmanToUpdate.ProfileImage != null)
                {
                    var profileImageResult = _fileService.SaveImage(craftsmanToUpdate.ProfileImage);
                    if (profileImageResult.Item1 == 1)
                    {
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

                List<IFormFile> craftsmanImages = new List<IFormFile>
                {
                craftsmanToUpdate.CraftsMenImage1,
                craftsmanToUpdate.CraftsMenImage2,
                craftsmanToUpdate.CraftsMenImage3,
                craftsmanToUpdate.CraftsMenImage4
                };

                for (int i = 0; i < craftsmanImages.Count; i++)
                {
                    if (craftsmanImages[i] != null)
                    {
                        var fileResult = _fileService.SaveImage(craftsmanImages[i]);
                        if (fileResult.Item1 == 1)
                        {
                            switch (i)
                            {
                                case 0:
                                    craftsmanToUpdate.CraftsMenImageName1 = fileResult.Item2;
                                    break;
                                case 1:
                                    craftsmanToUpdate.CraftsMenImageName2 = fileResult.Item2;
                                    break;
                                case 2:
                                    craftsmanToUpdate.CraftsMenImageName3 = fileResult.Item2;
                                    break;
                                case 3:
                                    craftsmanToUpdate.CraftsMenImageName4 = fileResult.Item2;
                                    break;
                            }
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
                }

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
    }
}