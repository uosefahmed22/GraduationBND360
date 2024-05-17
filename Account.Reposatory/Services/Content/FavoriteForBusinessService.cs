using Account.Apis.Errors;
using Account.Core.Dtos.BusinessDto;
using Account.Core.Dtos.FavoirteDto;
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

        public async Task<IEnumerable<BusinessModelDto>> GetBusinesses(string userId)
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

                return _mapper.Map<IEnumerable<BusinessModelDto>>(businesses);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApiResponse> RemoveAsync(int businessId)
        {
            try
            {
                var favorite = await _context.BusinessFavorites
                    .FirstOrDefaultAsync(f => f.Id == businessId);

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
