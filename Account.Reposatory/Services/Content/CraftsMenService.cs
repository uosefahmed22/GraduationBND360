using Account.Apis.Errors;
using Account.Core.Dtos.CraftsFolder;
using Account.Core.Dtos.CraftsMenDtoFolder;
using Account.Core.IServices.Content;
using Account.Core.Models.Content.Crafts;
using Account.Core.Models.Content.CraftsMen;
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
    public class CraftsMenService : ICraftsMenService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public CraftsMenService(AppDBContext context,IMapper mapper,IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task<ApiResponse> CreateCraftsMenAsync(CraftsMenModelDto model)
        {
            try
            {
                var craftsMenEntity = _mapper.Map<CraftsMenModel>(model);
                _context.CraftsMen.Add(craftsMenEntity);
                await _context.SaveChangesAsync();
                return new ApiResponse(200, "Craftsman added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to add craftsman: {ex.Message}");
            }
        }
        public async Task<IEnumerable<CraftsMenModelDto>> GetAllCraftsMenAsync()
        {
            try
            {
                var craftsMenEntities = await _context.CraftsMen
                    .Include(c => c.CraftsModel) 
                    .ToListAsync();

                var craftsMenDtoList = _mapper.Map<List<CraftsMenModelDto>>(craftsMenEntities);

                foreach (var craftsMenDto in craftsMenDtoList)
                {
                    craftsMenDto.CraftsModel = _mapper.Map<CraftsModelDto>(craftsMenDto.CraftsModel);
                }

                return craftsMenDtoList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ApiResponse> DeleteCraftsMenAsync(int id)
        {
            try
            {
                var existingCraftsman = await _context.CraftsMen.FindAsync(id);

                if (existingCraftsman == null)
                {
                    return new ApiResponse(404, "Craftsman not found.");
                }

                if (!string.IsNullOrEmpty(existingCraftsman.ProfileImageName))
                {
                    await _fileService.DeleteImage(existingCraftsman.ProfileImageName);
                }
                if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName1))
                {
                    await _fileService.DeleteImage(existingCraftsman.CraftsMenImageName1);
                }
                if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName2))
                {
                    await _fileService.DeleteImage(existingCraftsman.CraftsMenImageName2);
                }
                if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName3))
                {
                    await _fileService.DeleteImage(existingCraftsman.CraftsMenImageName3);
                }
                if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName4))
                {
                    await _fileService.DeleteImage(existingCraftsman.CraftsMenImageName4);
                }

                _context.CraftsMen.Remove(existingCraftsman);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Craftsman deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to delete craftsman: {ex.Message}");
            }
        }
        public async Task<CraftsMenModel> FindByIdAsync(int id)
        {
            return await _context.CraftsMen.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<CraftsMenModelDto> GetCraftsMenByIdAsync(int id)
        {
            try
            {
                var craftsMenEntity = await _context.CraftsMen.FirstOrDefaultAsync(b => b.Id == id);

                if (craftsMenEntity == null)
                {
                    return null;
                }

                return _mapper.Map<CraftsMenModelDto>(craftsMenEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ApiResponse> UpdateCraftsMenAsync(int id, CraftsMenModelDto model)
        {
            try
            {
                var existingCraftsman = await _context.CraftsMen.FirstOrDefaultAsync(b => b.Id == id);

                if (existingCraftsman == null)
                {
                    return new ApiResponse(404, "Craftsman not found.");
                }
                if (!string.IsNullOrEmpty(existingCraftsman.ProfileImageName))
                {
                    await _fileService.DeleteImage(existingCraftsman.ProfileImageName);
                }
                if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName1))
                {
                    await _fileService.DeleteImage(existingCraftsman.CraftsMenImageName1);
                }
                if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName2))
                {
                    await _fileService.DeleteImage(existingCraftsman.CraftsMenImageName2);
                }
                if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName3))
                {
                    await _fileService.DeleteImage(existingCraftsman.CraftsMenImageName3);
                }
                if (!string.IsNullOrEmpty(existingCraftsman.CraftsMenImageName4))
                {
                    await _fileService.DeleteImage(existingCraftsman.CraftsMenImageName4);
                }
                _mapper.Map(model, existingCraftsman);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Craftsman updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to update craftsman: {ex.Message}");
            }
        }
    }
}
