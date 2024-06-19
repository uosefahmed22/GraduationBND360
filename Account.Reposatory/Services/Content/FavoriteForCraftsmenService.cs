using Account.Apis.Errors;
using Account.Core.Dtos.CraftsMenDtoFolder;
using Account.Core.Dtos.FavoirteDto;
using Account.Core.IServices.Content;
using Account.Core.Models.Account;
using Account.Core.Models.Content.Favorite;
using Account.Reposatory.Data.Context;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Services.Content
{
    public class FavoriteForCraftsmenService : IFavoriteForCraftsmenService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public FavoriteForCraftsmenService(AppDBContext context,IMapper mapper,UserManager<AppUser>userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<ApiResponse> AddAsync(FavoriteModelForCraftsmenDto savedModel)
        {
            try
            {
                var entity = _mapper.Map<FavoriteModelForCraftsmen>(savedModel);

                _context.ServiceProvidersFavorites.Add(entity);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Record added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, $"Failed to add record: {ex.Message}");
            }
        }
        public async Task<IEnumerable<CraftsManWithRatingsDto>> GetCraftsmanFavorites(string userId)
        {
            try
            {
                var favoriteCraftsmanIds = await _context.ServiceProvidersFavorites
                    .Where(f => f.UserId == userId)
                    .Select(f => f.CraftsmanId)
                    .ToListAsync();

                if (!favoriteCraftsmanIds.Any())
                {
                    return new List<CraftsManWithRatingsDto>();
                }

                var user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    return new List<CraftsManWithRatingsDto>();
                }

                var craftsmen = await _context.CraftsMen
                    .Include(c => c.CraftsModel)
                    .Where(c => favoriteCraftsmanIds.Contains(c.Id))
                    .ToListAsync();

                var craftsmanDtos = new List<CraftsManWithRatingsDto>();

                foreach (var craftsman in craftsmen)
                {
                    var craftsmanDto = _mapper.Map<CraftsManWithRatingsDto>(craftsman);

                    var reviewAndRatingSummary = await GetCraftsmanReviewSummary(craftsman.Id);

                    craftsmanDto.TotalReviews = reviewAndRatingSummary.TotalReviews;
                    craftsmanDto.AverageRating = reviewAndRatingSummary.AverageRating;

                    craftsmanDto.UserName = user.DisplayName;
                    craftsmanDto.UserProfileImageName = user.profileImageName;

                    craftsmanDtos.Add(craftsmanDto);
                }

                return craftsmanDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving favorite craftsmen", ex);
            }
        }
        public async Task<CraftsmanReviewSummaryDto> GetCraftsmanReviewSummary(int craftsmanId)
        {
            try
            {
                var reviews = await _context.ratingAndReviewModelForCraftsmens
                                            .Where(r => r.CraftsmanId == craftsmanId)
                                            .ToListAsync();

                if (reviews == null || reviews.Count == 0)
                {
                    return new CraftsmanReviewSummaryDto
                    {
                        CraftsmanId = craftsmanId,
                        TotalReviews = 0,
                        AverageRating = 0
                    };
                }

                double totalRating = reviews.Sum(r => r.Rating ?? 0);
                double averageRating = totalRating / reviews.Count;
                averageRating = Math.Min(averageRating, 5);

                return new CraftsmanReviewSummaryDto
                {
                    CraftsmanId = craftsmanId,
                    TotalReviews = reviews.Count,
                    AverageRating = averageRating
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve reviews and ratings.", ex);
            }
        }
        public async Task<ApiResponse> RemoveAsync(int CraftsmanId, string userId)
        {
            try
            {
                var favorite = await _context.ServiceProvidersFavorites
                    .FirstOrDefaultAsync(f => f.CraftsmanId == CraftsmanId && f.UserId == userId);

                if (favorite == null)
                    return new ApiResponse(404, "Record not found.");

                _context.ServiceProvidersFavorites.Remove(favorite);
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
