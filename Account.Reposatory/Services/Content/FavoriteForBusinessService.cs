using Account.Apis.Errors;
using Account.Core.Dtos.BusinessDto;
using Account.Core.Dtos.FavoirteDto;
using Account.Core.Dtos.RatingAndReviewDto.Account.Core.Dtos.RatingAndReviewDto;
using Account.Core.IServices.Content;
using Account.Core.Models.Content.Favorite;
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
    public class FavoriteForBusinessService : IFavoriteForBusinessService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public FavoriteForBusinessService(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(FavoriteModelForBusinessDto savedModel)
        {
            try
            {
                var entity = _mapper.Map<FavoriteModelForBusiness>(savedModel);

                _context.BusinessFavorites.Add(entity);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Record added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, $"Failed to add record: {ex.Message}");
            }
        }
        public async Task<IEnumerable<BusinessWithRatingsDto>> GetBusinesses(string userId)
        {
            try
            {
                var favoriteBusinessIds = await _context.BusinessFavorites
                    .Where(f => f.UserId == userId)
                    .Select(f => f.BusinessId)
                    .ToListAsync();

                var businesses = await _context.Businesses
                    .Include(b => b.CategoriesModel)
                    .Where(b => favoriteBusinessIds.Contains(b.Id))
                    .ToListAsync();

                var businessDtos = new List<BusinessWithRatingsDto>();

                foreach (var business in businesses)
                {
                    var businessDto = _mapper.Map<BusinessWithRatingsDto>(business);

                    var reviewAndRatingSummary = await GetBusinessReviewSummary(business.Id);

                    businessDto.TotalReviews = reviewAndRatingSummary.TotalReviews;
                    businessDto.AverageRating = reviewAndRatingSummary.AverageRating;

                    businessDtos.Add(businessDto);
                }

                return businessDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<BusinessReviewSummaryDtoForFaviorates> GetBusinessReviewSummary(int businessId)
        {
            try
            {
                var reviews = await _context.ratingAndReviewModelForBusinesses
                                            .Where(r => r.businessId == businessId)
                                            .ToListAsync();

                if (reviews == null || reviews.Count == 0)
                {
                    return new BusinessReviewSummaryDtoForFaviorates
                    {
                        BusinessId = businessId,
                        TotalReviews = 0,
                        AverageRating = 0
                    };
                }

                double totalRating = reviews.Sum(r => r.Rating ?? 0);
                double averageRating = totalRating / reviews.Count;
                averageRating = Math.Min(averageRating, 5);

                return new BusinessReviewSummaryDtoForFaviorates
                {
                    BusinessId = businessId,
                    TotalReviews = reviews.Count,
                    AverageRating = averageRating
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve reviews and ratings.", ex);
            }
        }
        public async Task<ApiResponse> RemoveAsync(int businessId, string userId)
        {
            try
            {
                var favorite = await _context.BusinessFavorites
                    .FirstOrDefaultAsync(f => f.BusinessId == businessId && f.UserId == userId);

                if (favorite == null)
                    return new ApiResponse(404, "Record not found.");

                _context.BusinessFavorites.Remove(favorite);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Record removed successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, $"Failed to remove record: {ex.Message}");
            }
        }
    }
}
