using Account.Apis.Errors;
using Account.Core.Dtos.CraftsMenDtoFolder;
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
    public class FavoriteForCraftsmenService : IFavoriteForCraftsmenService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public FavoriteForCraftsmenService(AppDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<IEnumerable<CraftsMenModelDto>> GetCraftsmanFavorites(string userId)
        {
            try
            {
                var favoriteBusinessIds = await _context.ServiceProvidersFavorites
                    .Where(f => f.UserId == userId)
                    .Select(f => f.BusinessId)
                    .ToListAsync();

                var craftsmen = await _context.CraftsMen
                    .Include(c => c.CraftsModel)
                    .Where(c => favoriteBusinessIds.Contains(c.Id))
                    .ToListAsync();

                return _mapper.Map<IEnumerable<CraftsMenModelDto>>(craftsmen);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ApiResponse> RemoveAsync(int CraftsmanId)
        {
            try
            {
                var favorite = await _context.ServiceProvidersFavorites
                    .FirstOrDefaultAsync(f => f.Id == CraftsmanId);

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
