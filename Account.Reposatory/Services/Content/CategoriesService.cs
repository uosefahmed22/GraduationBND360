using Account.Apis.Errors;
using Account.Core.Dtos.CategoriesDto;
using Account.Core.IServices.Content;
using Account.Core.Models.Content.Categories;
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

        public CategoriesService(AppDBContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateCategoryAsync(CategoriesModelDTO category)
        {
            try
            {
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
                var categoryEntities = await _context.Categories.ToListAsync();
                return _mapper.Map<IEnumerable<CategoriesModelDTO>>(categoryEntities);
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

                _context.Categories.Remove(existingCategory);
                await _context.SaveChangesAsync();

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

                _mapper.Map(category, existingCategory);

                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Category updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to update category: {ex.Message}");
            }
        }
    }
}
