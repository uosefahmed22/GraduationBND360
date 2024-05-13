using Account.Apis.Errors;
using Account.Core.Dtos.BusinessDto;
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
        private readonly IFileService _fileService;
        public BusinessService(AppDBContext context, IMapper mapper,IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task<ApiResponse> CreateAsync(BusinessModelDto model)
        {
            try
            {
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
        public async Task<List<BusinessModelDto>> GetAllAsync()
        {
            try
            {
                var businessEntities = await _context.Businesses
                    .Include(b => b.ImageNames)
                    .ToListAsync();

                return _mapper.Map<List<BusinessModelDto>>(businessEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ApiResponse> UpdateAsync(int id, BusinessModelDto model)
        {
            try
            {
                var existingBusiness = await _context.Businesses
                    .Include(b => b.ImageNames) // Include related images
                    .FirstOrDefaultAsync(b => b.Id == id);

                if (existingBusiness == null)
                {
                    return new ApiResponse(404, "Business not found.");
                }

                // Delete old images
                foreach (var image in existingBusiness.ImageNames)
                {
                    await _fileService.DeleteImage(image.ImageNames);
                    _context.Remove(image);
                }

                // Map and update business
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
        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var existingBusiness = await _context.Businesses.FindAsync(id);

                if (existingBusiness == null)
                {
                    return new ApiResponse(404, "Business not found.");
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
        public async Task<BusinessModelDto> GetByIdAsync(int id)
        {
            try
            {
                var businessEntity = await _context.Businesses
                    .Include(b => b.ImageNames)
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
    }
}
