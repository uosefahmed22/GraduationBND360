using Account.Apis.Errors;
using Account.Core.Dtos.BusinessDto;
using Account.Core.Dtos.CategoriesDto;
using Account.Core.Dtos.RatingAndReviewDto.Account.Core.Dtos.RatingAndReviewDto;
using Account.Core.IServices.Content;
using Account.Core.Models.Content.Business;
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
    public class BusinessService : IBusinessService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        public BusinessService(AppDBContext context, IMapper mapper,IImageService fileService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = fileService;
        }
        public async Task<ApiResponse> CreateAsync(BusinessModelDto model)
        {
            try
            {

                var imageTasks = new List<Task<Tuple<int, string>>>();

                if (model.ProfileImage != null)
                    imageTasks.Add(_imageService.UploadImageAsync(model.ProfileImage));
                if (model.BusinessImage1 != null)
                    imageTasks.Add(_imageService.UploadImageAsync(model.BusinessImage1));
                if (model.BusinessImage2 != null)
                    imageTasks.Add(_imageService.UploadImageAsync(model.BusinessImage2));
                if (model.BusinessImage3 != null)
                    imageTasks.Add(_imageService.UploadImageAsync(model.BusinessImage3));
                if (model.BusinessImage4 != null)
                    imageTasks.Add(_imageService.UploadImageAsync(model.BusinessImage4));

                var imageResults = await Task.WhenAll(imageTasks);

                if (model.ProfileImage != null)
                    model.ProfileImageName = imageResults[0].Item2;
                if (model.BusinessImage1 != null)
                    model.BusinessImageName1 = imageResults[1].Item2;
                if (model.BusinessImage2 != null)
                    model.BusinessImageName2 = imageResults[2].Item2;
                if (model.BusinessImage3 != null)
                    model.BusinessImageName3 = imageResults[3].Item2;
                if (model.BusinessImage4 != null)
                    model.BusinessImageName4 = imageResults[4].Item2;

                var businessEntity = _mapper.Map<BusinessModel>(model);
                _context.Businesses.Add(businessEntity);
                await _context.SaveChangesAsync();
                return new ApiResponse(200, "Business added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to add business: {ex.Message}");
            }
        }
        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var existingBusiness = await _context.Businesses.FindAsync(id);

                if (existingBusiness == null)
                {
                    return new ApiResponse(404, "Business not found.");
                }

                if (!string.IsNullOrEmpty(existingBusiness.ProfileImageName))
                {
                    await _imageService.DeleteImageAsync(existingBusiness.ProfileImageName);
                }
                if (!string.IsNullOrEmpty(existingBusiness.BusinessImageName1))
                {
                    await _imageService.DeleteImageAsync(existingBusiness.BusinessImageName1);
                }
                if (!string.IsNullOrEmpty(existingBusiness.BusinessImageName2))
                {
                    await _imageService.DeleteImageAsync(existingBusiness.BusinessImageName2);
                }
                if (!string.IsNullOrEmpty(existingBusiness.BusinessImageName3))
                {
                    await _imageService.DeleteImageAsync(existingBusiness.BusinessImageName3);
                }
                if (!string.IsNullOrEmpty(existingBusiness.BusinessImageName4))
                {
                    await _imageService.DeleteImageAsync(existingBusiness.BusinessImageName4);
                }
                _context.Businesses.Remove(existingBusiness);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Business deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to delete business: {ex.Message}");
            }
        }
        public async Task<ApiResponse> UpdateAsync(int id, BusinessModelDto model)
        {
            try
            {
                var existingBusiness = await _context.Businesses.FirstOrDefaultAsync(b => b.Id == id);

                if (existingBusiness == null)
                {
                    return new ApiResponse(404, "Business not found.");
                }

                if (!string.IsNullOrEmpty(existingBusiness.ProfileImageName))
                {
                    await _imageService.DeleteImageAsync(existingBusiness.ProfileImageName);
                }
                if (!string.IsNullOrEmpty(existingBusiness.BusinessImageName1))
                {
                    await _imageService.DeleteImageAsync(existingBusiness.BusinessImageName1);
                }
                if (!string.IsNullOrEmpty(existingBusiness.BusinessImageName2))
                {
                    await _imageService.DeleteImageAsync(existingBusiness.BusinessImageName2);
                }
                if (!string.IsNullOrEmpty(existingBusiness.BusinessImageName3))
                {
                    await _imageService.DeleteImageAsync(existingBusiness.BusinessImageName3);
                }
                if (!string.IsNullOrEmpty(existingBusiness.BusinessImageName4))
                {
                    await _imageService.DeleteImageAsync(existingBusiness.BusinessImageName4);
                }

                var imageTasks = new List<Task<Tuple<int, string>>>();

                if (model.ProfileImage != null)
                    imageTasks.Add(_imageService.UploadImageAsync(model.ProfileImage));
                if (model.BusinessImage1 != null)
                    imageTasks.Add(_imageService.UploadImageAsync(model.BusinessImage1));
                if (model.BusinessImage2 != null)
                    imageTasks.Add(_imageService.UploadImageAsync(model.BusinessImage2));
                if (model.BusinessImage3 != null)
                    imageTasks.Add(_imageService.UploadImageAsync(model.BusinessImage3));
                if (model.BusinessImage4 != null)
                    imageTasks.Add(_imageService.UploadImageAsync(model.BusinessImage4));

                var imageResults = await Task.WhenAll(imageTasks);

                if (model.ProfileImage != null)
                    model.ProfileImageName = imageResults[0].Item2;
                if (model.BusinessImage1 != null)
                    model.BusinessImageName1 = imageResults[1].Item2;
                if (model.BusinessImage2 != null)
                    model.BusinessImageName2 = imageResults[2].Item2;
                if (model.BusinessImage3 != null)
                    model.BusinessImageName3 = imageResults[3].Item2;
                if (model.BusinessImage4 != null)
                    model.BusinessImageName4 = imageResults[4].Item2;

                _mapper.Map(model, existingBusiness);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Business updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to update business: {ex.Message}");
            }
        }
        public async Task<BusinessModel> FindByIdAsync(int id)
        {
            return await _context.Businesses.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<BusinessModelDto> GetByIdAsync(int id)
        {
            try
            {
                var businessEntity = await _context.Businesses
                    .Include(b => b.CategoriesModel)
                    .FirstOrDefaultAsync(b => b.Id == id);


                if (businessEntity == null)
                {
                    return null;
                }

                return _mapper.Map<BusinessModelDto>(businessEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<BusinessModelDto> GetBusinessForBusinessOwnerAsync(string userId)
        {
            try
            {
                var businessEntity = await _context.Businesses
                    .Include(b => b.CategoriesModel)
                    .FirstOrDefaultAsync(b => b.UserId == userId);

                if (businessEntity == null)
                {
                    return null;
                }

                return _mapper.Map<BusinessModelDto>(businessEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve business for the business owner.", ex);
            }
        }
        public async Task<List<BusinessResponseInCategory>> GetAllBusinessesWithDetailsAsync(int categoryId)
        {
            try
            {
                var businessEntities = await _context.Businesses
                    .Include(b => b.CategoriesModel)
                    .Where(b => b.CategoriesModelId == categoryId)
                    .ToListAsync();

                var businessDtos = new List<BusinessResponseInCategory>();

                foreach (var business in businessEntities)
                {
                    var businessDto = _mapper.Map<BusinessResponseInCategory>(business);

                    if (business.CategoriesModel != null)
                    {
                        var categoryDto = _mapper.Map<CategoriesModelDTO>(business.CategoriesModel);
                        businessDto.Category = categoryDto;
                    }

                    var reviewAndRatingSummary = await GetReviewsAndRatingsForBusinessAsync(business.Id);

                    businessDto.TotalReviews = reviewAndRatingSummary.TotalReviews;
                    businessDto.AverageRating = reviewAndRatingSummary.AverageRating;

                    businessDtos.Add(businessDto);
                }

                return businessDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve businesses with details.", ex);
            }
        }
        public async Task<ReviewAndRatingSummaryResponse> GetReviewsAndRatingsForBusinessAsync(int businessId)
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
