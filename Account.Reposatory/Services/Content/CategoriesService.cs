using Account.Apis.Errors;
using Account.Core.Dtos;
using Account.Core.Dtos.CategoriesDto;
using Account.Core.IServices.Content;
using Account.Core.Models.Content.Categories;
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
    public class CategoriesService : ICategoriesService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public CategoriesService(AppDBContext context , IMapper mapper,IImageService fileService)
        {
            _context = context;
            _mapper = mapper;
            _imageService = fileService;
        }
        public async Task<ApiResponse> CreateCategoryAsync(CategoriesModelDTO category)
        {
            try
            {

                if (category.Image != null)
                {
                    var imageUrl = await _imageService.UploadImageAsync(category.Image);
                    if (imageUrl.Item1 == 1)
                    {
                        category.ImageFileName = imageUrl.Item2;
                    }
                    else
                    {
                        return new ApiResponse(500, imageUrl.Item2);
                    }
                }

                var categoryEntity = _mapper.Map<CategoriesModel>(category);
                _context.Categories.Add(categoryEntity);
                await _context.SaveChangesAsync();
                return new ApiResponse(200, "Category added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to add category: {ex.Message}");
            }
        }
        public async Task<IEnumerable<CategoriesModelDTO>> GetAllCategoriesAsync()
        {
            try
            {
                var categoryEntities = await _context.Categories.ToListAsync();                return _mapper.Map<IEnumerable<CategoriesModelDTO>>(categoryEntities);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all categories", ex);
            }
        }
        public async Task<ApiResponse> DeleteCategoryAsync(int id)
        {
            try
            {
                var existingCategory = await _context.Categories.FindAsync(id);

                if (existingCategory == null)
                {
                    return new ApiResponse(404, "Category not found.");
                }

                string imageFileName = existingCategory.ImageFileName;

                _context.Categories.Remove(existingCategory);
                await _context.SaveChangesAsync();

                if (!string.IsNullOrEmpty(imageFileName))
                {
                    await _imageService.DeleteImageAsync(imageFileName);
                }

                return new ApiResponse(200, "Category deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to delete category: {ex.Message}");
            }
        }
        public async Task<CategoriesModelDTO> GetCategoryByIdAsync(int id)
        {
            try
            {
                var categoryEntity = await _context.Categories.FindAsync(id);

                if (categoryEntity == null)
                {
                    return null;
                }

                return _mapper.Map<CategoriesModelDTO>(categoryEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ApiResponse> UpdateCategoryAsync(int id, CategoriesModelDTO category)
        {
            try
            {
                var existingCategory = await _context.Categories.FindAsync(id);

                if (existingCategory == null)
                {
                    return new ApiResponse(404, "Category not found.");
                }

                if (category.Image != null)
                {
                    if (!string.IsNullOrEmpty(existingCategory.ImageFileName))
                    {
                        await _imageService.DeleteImageAsync(existingCategory.ImageFileName);
                    }

                    var imageUrl = await _imageService.UploadImageAsync(category.Image);
                    if (imageUrl.Item1 == 1)
                    {
                        existingCategory.ImageFileName = imageUrl.Item2;
                    }
                    else
                    {
                        return new ApiResponse(500, imageUrl.Item2);
                    }
                }

                _mapper.Map(category, existingCategory);

                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Category updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to update category: {ex.Message}");
            }
        }
        public async Task<CategoriesModel?> FindByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;
        }
    }
}
