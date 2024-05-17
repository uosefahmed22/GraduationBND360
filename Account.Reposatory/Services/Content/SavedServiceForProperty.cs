using Account.Apis.Errors;
using Account.Core.Dtos.PropertyFolderDto;
using Account.Core.Dtos;
using Account.Core.IServices.Content;
using Account.Core.Models.Content.Saved;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Reposatory.Data.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Account.Reposatory.Services.Content
{
    public class SavedServiceForProperty : ISavedServiceForProperty
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public SavedServiceForProperty(AppDBContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(SavedModelForPropertyDto savedModel)
        {
            try
            {
                var entity = _mapper.Map<SavedModelForProperty>(savedModel);

                _context.PropertiesSaved.Add(entity);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Record added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, $"Failed to add record: {ex.Message}");
            }
        }
        public async Task<IEnumerable<PropertyModelDTO>> GetProperty(string userId)
        {
            try
            {
                var savedPropertyIds = await _context.PropertiesSaved
                    .Where(s => s.UserId == userId)
                    .Select(s => s.PropertyId)
                    .ToListAsync();

                var properties = await _context.Properties
                    .Include(p => p.PublisherDetails)
                    .Where(p => savedPropertyIds.Contains(p.Id))
                    .ToListAsync();

                return _mapper.Map<IEnumerable<PropertyModelDTO>>(properties);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ApiResponse> RemoveAsync(int id)
        {
            try
            {
                var savedProperty = await _context.PropertiesSaved.FindAsync(id);

                if (savedProperty == null)
                    return new ApiResponse(404, "Record not found.");

                _context.PropertiesSaved.Remove(savedProperty);
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
