using Account.Apis.Errors;
using Account.Core.Dtos.BusinessDto;
using Account.Core.Dtos.CraftsFolder;
using Account.Core.Dtos.CraftsMenDtoFolder;
using Account.Core.Dtos.RatingAndReviewDto.Account.Core.Dtos.RatingAndReviewDto;
using Account.Core.IServices.Content;
using Account.Core.Models.Content.Crafts;
using Account.Core.Models.Content.CraftsMen;
using Account.Core.Services.Content;
using Account.Reposatory.Data.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Services.Content
{
    public class CraftsMenService : ICraftsMenService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public CraftsMenService(AppDBContext context,IMapper mapper,IImageService fileService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = fileService;
        }
        public async Task<ApiResponse> CreateCraftsMenAsync(CraftsMenModelDto model)
        {
            try
            {
                if (model.ProfileImage != null)
                {
                    var fileResult = await _imageService.SaveImageAsync(model.ProfileImage);
                    if (fileResult.Item1 == 1)
                    {
                        model.ProfileImageName = fileResult.Item2;
                    }
                    else
                    {
                        return new ApiResponse(400, fileResult.Item2);
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
                        return new ApiResponse(400, fileResult1.Item2);
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
                        return new ApiResponse(400, fileResult2.Item2);
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
                        return new ApiResponse(400, fileResult3.Item2);
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
                        return new ApiResponse(400, fileResult4.Item2);
                    }
                }

                var craftsMenEntity = _mapper.Map<CraftsMenModel>(model);
                _context.CraftsMen.Add(craftsMenEntity);
                await _context.SaveChangesAsync();
                return new ApiResponse(200, "Craftsman added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to add craftsman: {ex.Message}");
            }
        }
        public async Task<ApiResponse> DeleteCraftsMenAsync(int id)
        {
            try
            {
                var existingCraftsman = await _context.CraftsMen.FindAsync(id);

                if (existingCraftsman == null)
                {
                    return new ApiResponse(404, "Craftsman not found.");
                }

                if (!string.IsNullOrEmpty(existingCraftsman.ProfileImageName))
                {
                    await _imageService.DeleteImageAsync(existingCraftsman.ProfileImageName);
                }
                if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName1))
                {
                    await _imageService.DeleteImageAsync(existingCraftsman.CraftsMenImageName1);
                }
                if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName2))
                {
                    await _imageService.DeleteImageAsync(existingCraftsman.CraftsMenImageName2);
                }
                if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName3))
                {
                    await _imageService.DeleteImageAsync(existingCraftsman.CraftsMenImageName3);
                }
                if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName4))
                {
                    await _imageService.DeleteImageAsync(existingCraftsman.CraftsMenImageName4);
                }

                _context.CraftsMen.Remove(existingCraftsman);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Craftsman deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to delete craftsman: {ex.Message}");
            }
        }
        public async Task<ApiResponse> UpdateCraftsMenAsync(int id, CraftsMenModelDto model)
        {
            try
            {
                var existingCraftsman = await _context.CraftsMen.FirstOrDefaultAsync(b => b.Id == id);

                if (existingCraftsman == null)
                {
                    return new ApiResponse(404, "Craftsman not found.");
                }

                if (model.ProfileImage != null)
                {
                    var fileResult = await _imageService.SaveImageAsync(model.ProfileImage);
                    if (fileResult.Item1 == 1)
                    {
                        if (!string.IsNullOrEmpty(existingCraftsman.ProfileImageName))
                        {
                            await _imageService.DeleteImageAsync(existingCraftsman.ProfileImageName);
                        }
                        model.ProfileImageName = fileResult.Item2;
                    }
                    else
                    {
                        return new ApiResponse(400, fileResult.Item2);
                    }
                }

                if (model.CraftsMenImage1 != null)
                {
                    var fileResult1 = await _imageService.SaveImageAsync(model.CraftsMenImage1);
                    if (fileResult1.Item1 == 1)
                    {
                        if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName1))
                        {
                            await _imageService.DeleteImageAsync(existingCraftsman.CraftsMenImageName1);
                        }
                        model.CraftsMenImageName1 = fileResult1.Item2;
                    }
                    else
                    {
                        return new ApiResponse(400, fileResult1.Item2);
                    }
                }

                if (model.CraftsMenImage2 != null)
                {
                    var fileResult2 = await _imageService.SaveImageAsync(model.CraftsMenImage2);
                    if (fileResult2.Item1 == 1)
                    {
                        if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName2))
                        {
                            await _imageService.DeleteImageAsync(existingCraftsman.CraftsMenImageName2);
                        }
                        model.CraftsMenImageName2 = fileResult2.Item2;
                    }
                    else
                    {
                        return new ApiResponse(400, fileResult2.Item2);
                    }
                }

                if (model.CraftsMenImage3 != null)
                {
                    var fileResult3 = await _imageService.SaveImageAsync(model.CraftsMenImage3);
                    if (fileResult3.Item1 == 1)
                    {
                        if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName3))
                        {
                            await _imageService.DeleteImageAsync(existingCraftsman.CraftsMenImageName3);
                        }
                        model.CraftsMenImageName3 = fileResult3.Item2;
                    }
                    else
                    {
                        return new ApiResponse(400, fileResult3.Item2);
                    }
                }

                if (model.CraftsMenImage4 != null)
                {
                    var fileResult4 = await _imageService.SaveImageAsync(model.CraftsMenImage4);
                    if (fileResult4.Item1 == 1)
                    {
                        if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName4))
                        {
                            await _imageService.DeleteImageAsync(existingCraftsman.CraftsMenImageName4);
                        }
                        model.CraftsMenImageName4 = fileResult4.Item2;
                    }
                    else
                    {
                        return new ApiResponse(400, fileResult4.Item2);
                    }
                }

                _mapper.Map(model, existingCraftsman);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Craftsman updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to update craftsman: {ex.Message}");
            }
        }
        public async Task<CraftsMenModel> FindByIdAsync(int id)
        {
            return await _context.CraftsMen.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<CraftsMenModelDto> GetCraftsMenByIdAsync(int id)
        {
            try
            {
                var craftsMenEntity = await _context.CraftsMen
                    .Include(c => c.CraftsModel)
                    .FirstOrDefaultAsync(b => b.Id == id);

                if (craftsMenEntity == null)
                {
                    return null;
                }

                return _mapper.Map<CraftsMenModelDto>(craftsMenEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<CraftsMenModelDto> GetcraftsForCraftsmanAsync(string userId)
        {
            try
            {
                var craftsMenEntity = await _context.CraftsMen
                    .Include(c => c.CraftsModel)
                    .FirstOrDefaultAsync(c => c.UserId == userId);

                if (craftsMenEntity == null)
                {
                    return null;
                }

                return _mapper.Map<CraftsMenModelDto>(craftsMenEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve crafts for the craftsman.", ex);
            }
        }
        public async Task<List<CraftsmanResponseDto>> GetAllCraftsmenWithDetailsAsync(int craftsId)
        {
            try
            {
                var craftsmenEntities = await _context.CraftsMen
                    .Include(c => c.CraftsModel)
                    .Where(c => c.CraftsModelId == craftsId)
                    .ToListAsync();

                var craftsmenDtos = new List<CraftsmanResponseDto>();

                foreach (var craftsman in craftsmenEntities)
                {
                    var craftsmanDto = _mapper.Map<CraftsmanResponseDto>(craftsman);

                    if (craftsman.CraftsModel != null)
                    {
                        var craftsModelDto = _mapper.Map<CraftsModelDto>(craftsman.CraftsModel);
                        craftsmanDto.CraftsModel = craftsModelDto;
                    }

                    var reviewAndRatingSummary = await GetReviewsAndRatingsForCraftsmanAsync(craftsman.Id);

                    craftsmanDto.TotalReviews = reviewAndRatingSummary.TotalReviews;
                    craftsmanDto.AverageRating = reviewAndRatingSummary.AverageRating;

                    craftsmenDtos.Add(craftsmanDto);
                }

                return craftsmenDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve craftsmen with details.", ex);
            }
        }
        public async Task<ReviewAndRatingSummaryResponse> GetReviewsAndRatingsForCraftsmanAsync(int businessId)
        {
            try
            {
                var reviews = await _context.ratingAndReviewModelForBusinesses
                                             .Where(r => r.businessId == businessId)
                                             .ToListAsync();

                if (reviews == null || reviews.Count == 0)
                {
                    return new ReviewAndRatingSummaryResponse
                    {
                        TotalReviews = 0,
                        AverageRating = 0
                    };
                }

                double totalRating = reviews.Sum(r => r.Rating ?? 0);
                double averageRating = totalRating / reviews.Count;
                averageRating = Math.Min(averageRating, 5);

                return new ReviewAndRatingSummaryResponse
                {
                    TotalReviews = reviews.Count,
                    AverageRating = averageRating
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve reviews and ratings.", ex);
            }
        }
    }
}
