using Account.Apis.Errors;
using Account.Core.Dtos.CraftsFolder;
using Account.Core.Models.Content.Crafts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.IServices.Content
{
    public interface ICraftsService
    {
        Task<ApiResponse> CreateCraftAsync(CraftsModelDto craft);
        Task<CraftsModelDto> GetCraftByIdAsync(int id);
        Task<IEnumerable<CraftsModelDto>> GetAllCraftsAsync();
        Task<ApiResponse> UpdateCraftAsync(int id, CraftsModelDto craft);
        Task<ApiResponse> DeleteCraftAsync(int id);
        Task<CraftsModel?> FindCraftByIdAsync(int id);
    }
}
