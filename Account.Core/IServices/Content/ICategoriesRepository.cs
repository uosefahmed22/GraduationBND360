using Account.Apis.Errors;
using Account.Core.Dtos.CategoriesDto;
using Account.Core.Models.Content.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.IServices.Content
{
    public interface ICategoriesService
    {
        Task<ApiResponse> CreateCategoryAsync(CategoriesModelDTO category);
        Task<CategoriesModelDTO> GetCategoryByIdAsync(int id);
        Task<IEnumerable<CategoriesModelDTO>> GetAllCategoriesAsync();
        Task<ApiResponse> UpdateCategoryAsync(int id, CategoriesModelDTO category);
        Task<ApiResponse> DeleteCategoryAsync(int id);
    }
}
