using Account.Apis.Errors;
using Account.Core.Dtos.PropertyFolderDto;
using Account.Core.IServices.Content;
using Account.Core.Models.Content.Properties;
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
    public class PropertyService : IPropertyService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public PropertyService(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreatePropertyAsync(PropertyModelDTO propertyDto)
        {
            try
            {
                var propertyEntity = _mapper.Map<PropertyModel>(propertyDto);
                _context.Properties.Add(propertyEntity);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Property added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to add property: {ex.Message}");
            }
        }
        public async Task<ApiResponse> DeletePropertyAsync(int id)
        {
            try
            {
                var existingProperty = await _context.Properties.FindAsync(id);

                if (existingProperty == null)
                {
                    return new ApiResponse(404, "Property not found.");
                }

                _context.Properties.Remove(existingProperty);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Property deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to delete property: {ex.Message}");
            }
        }
        public async Task<List<PropertyModelDTO>> GetAllPropertiesAsync()
        {
            try
            {
                var propertyEntities = await _context.Properties
                    .Include(p => p.ImageNames)
                    .Include(p=>p.PublisherDetails)
                    .Include(p => p.Contacts)
                    .ToListAsync();

                return _mapper.Map<List<PropertyModelDTO>>(propertyEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PropertyModelDTO> GetPropertyByIdAsync(int id)
        {
            try
            {
                var propertyEntity = await _context.Properties
                    .Include(p => p.ImageNames)
                    .Include(p => p.PublisherDetails)
                    .Include(p => p.Contacts)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (propertyEntity == null)
                {
                    return null;
                }

                return _mapper.Map<PropertyModelDTO>(propertyEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ApiResponse> UpdatePropertyAsync(int id, PropertyModelDTO propertyDto)
        {
            try
            {
                var existingProperty = await _context.Properties
                                                    .Include(p => p.PublisherDetails)
                                                    .FirstOrDefaultAsync(p => p.Id == id);
                if (existingProperty == null)
                {
                    return new ApiResponse(404, "Property not found.");
                }

                _mapper.Map(propertyDto, existingProperty);

                if (propertyDto.PublisherDetails != null)
                {
                    _mapper.Map(propertyDto.PublisherDetails, existingProperty.PublisherDetails);
                }

                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Property updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to update property: {ex.Message}");
            }
        }
        public async Task<PropertyModel> FindByIdAsync(int id)
        {
            return await _context.Properties.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
