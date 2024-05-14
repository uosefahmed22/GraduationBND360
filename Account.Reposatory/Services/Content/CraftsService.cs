using Account.Apis.Errors;
using Account.Core.Dtos.CraftsFolder;
using Account.Core.IServices.Content;
using Account.Core.Models.Content.Crafts;
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
    public class CraftsService : ICraftsService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public CraftsService(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateCraftAsync(CraftsModelDto craft)
        {
            try
            {
                var entity = _mapper.Map<CraftsModel>(craft);

                _context.crafts.Add(entity);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Craft added successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, "Failed to add craft: " + ex.Message);
            }
        }
        public async Task<ApiResponse> DeleteCraftAsync(int id)
        {
            try
            {
                var craft = await _context.crafts.FindAsync(id);

                if (craft == null)
                {
                    return new ApiResponse(404, "Craft not found");
                }

                _context.crafts.Remove(craft);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Craft deleted successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, "Failed to delete craft: " + ex.Message);
            }
        }
        public async Task<CraftsModel?> FindCraftByIdAsync(int id)
        {
            var craft = await _context.crafts.FindAsync(id);
            return craft;
        }
        public async Task<IEnumerable<CraftsModelDto>> GetAllCraftsAsync()
        {
            try
            {
                var crafts = await _context.crafts.ToListAsync();
                return _mapper.Map<IEnumerable<CraftsModelDto>>(crafts);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<CraftsModelDto> GetCraftByIdAsync(int id)
        {
            try
            {
                var craft = await _context.crafts.FindAsync(id);
                if (craft == null)
                {
                    return null; 
                }

                return _mapper.Map<CraftsModelDto>(craft);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<ApiResponse> UpdateCraftAsync(int id, CraftsModelDto craft)
        {
            try
            {
                var existingCraft = await _context.crafts.FindAsync(id);
                if (existingCraft == null)
                {
                    return new ApiResponse(404, "Craft not found");
                }

                _mapper.Map(craft, existingCraft);

                _context.crafts.Update(existingCraft);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Craft updated successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, "Failed to update craft: " + ex.Message);
            }
        }
    }
}
