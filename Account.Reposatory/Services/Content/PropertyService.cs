using Account.Apis.Errors;
using Account.Core.Dtos.PropertyFolderDto;
using Account.Core.IServices.Content;
using Account.Core.Models.Content.Properties;
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
    public class PropertyService : IPropertyService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public PropertyService(AppDBContext context, IMapper mapper,IImageService fileService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = fileService;
        }

        public async Task<ApiResponse> CreatePropertyAsync(PropertyModelDTO propertyDto)
        {
            try
            {
                var imageTasks = new List<Task<Tuple<int, string>>>();

                if (propertyDto.image1 != null)
                    imageTasks.Add(_imageService.UploadImageAsync(propertyDto.image1));
                if (propertyDto.image2 != null)
                    imageTasks.Add(_imageService.UploadImageAsync(propertyDto.image2));
                if (propertyDto.image3 != null)
                    imageTasks.Add(_imageService.UploadImageAsync(propertyDto.image3));
                if (propertyDto.image4 != null)
                    imageTasks.Add(_imageService.UploadImageAsync(propertyDto.image4));

                var imageResults = await Task.WhenAll(imageTasks);

                if (propertyDto.image1 != null)
                    propertyDto.ImageName1 = imageResults[0].Item2;
                if (propertyDto.image2 != null)
                    propertyDto.ImageName2 = imageResults[1].Item2;
                if (propertyDto.image3 != null)
                    propertyDto.ImageName3 = imageResults[2].Item2;
                if (propertyDto.image4 != null)
                    propertyDto.ImageName4 = imageResults[3].Item2;

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

                var imageUrls = new List<string>
        {
            existingProperty.ImageName1,
            existingProperty.ImageName2,
            existingProperty.ImageName3,
            existingProperty.ImageName4
        };

                foreach (var imageUrl in imageUrls)
                {
                    if (!string.IsNullOrEmpty(imageUrl))
                    {
                        await _imageService.DeleteImageAsync(imageUrl);
                    }
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
                    .Include(p => p.PublisherDetails)
                    .ToListAsync();

                return _mapper.Map<List<PropertyModelDTO>>(propertyEntities);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all properties", ex);
            }
        }
        public async Task<PropertyModelDTO> GetPropertyByIdAsync(int id)
        {
            try
            {
                var propertyEntity = await _context.Properties
                    .Include(p => p.PublisherDetails)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (propertyEntity == null)
                {
                    return null;
                }

                return _mapper.Map<PropertyModelDTO>(propertyEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get property by ID", ex);
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

                propertyDto.ImageName1 = propertyDto.image1 != null ? propertyDto.ImageName1 : existingProperty.ImageName1;
                propertyDto.ImageName2 = propertyDto.image2 != null ? propertyDto.ImageName2 : existingProperty.ImageName2;
                propertyDto.ImageName3 = propertyDto.image3 != null ? propertyDto.ImageName3 : existingProperty.ImageName3;
                propertyDto.ImageName4 = propertyDto.image4 != null ? propertyDto.ImageName4 : existingProperty.ImageName4;

                _mapper.Map(propertyDto, existingProperty);
                _mapper.Map(propertyDto.PublisherDetails, existingProperty.PublisherDetails);

                if (propertyDto.image1 != null)
                {
                    if (!string.IsNullOrEmpty(existingProperty.ImageName1))
                    {
                        await _imageService.DeleteImageAsync(existingProperty.ImageName1);
                    }
                    var imageResult = await _imageService.UploadImageAsync(propertyDto.image1);
                    if (imageResult.Item1 == 1)
                    {
                        existingProperty.ImageName1 = imageResult.Item2;
                    }
                    else
                    {
                        return new ApiResponse(500, imageResult.Item2);
                    }
                }

                if (propertyDto.image2 != null)
                {
                    if (!string.IsNullOrEmpty(existingProperty.ImageName2))
                    {
                        await _imageService.DeleteImageAsync(existingProperty.ImageName2);
                    }
                    var imageResult = await _imageService.UploadImageAsync(propertyDto.image2);
                    if (imageResult.Item1 == 1)
                    {
                        existingProperty.ImageName2 = imageResult.Item2;
                    }
                    else
                    {
                        return new ApiResponse(500, imageResult.Item2);
                    }
                }

                if (propertyDto.image3 != null)
                {
                    if (!string.IsNullOrEmpty(existingProperty.ImageName3))
                    {
                        await _imageService.DeleteImageAsync(existingProperty.ImageName3);
                    }
                    var imageResult = await _imageService.UploadImageAsync(propertyDto.image3);
                    if (imageResult.Item1 == 1)
                    {
                        existingProperty.ImageName3 = imageResult.Item2;
                    }
                    else
                    {
                        return new ApiResponse(500, imageResult.Item2);
                    }
                }

                if (propertyDto.image4 != null)
                {
                    if (!string.IsNullOrEmpty(existingProperty.ImageName4))
                    {
                        await _imageService.DeleteImageAsync(existingProperty.ImageName4);
                    }
                    var imageResult = await _imageService.UploadImageAsync(propertyDto.image4);
                    if (imageResult.Item1 == 1)
                    {
                        existingProperty.ImageName4 = imageResult.Item2;
                    }
                    else
                    {
                        return new ApiResponse(500, imageResult.Item2);
                    }
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
