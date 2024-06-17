using Account.Apis.Errors;
using Account.Core.Dtos.BusinessDto;
using Account.Core.Dtos.CraftsMenDtoFolder;
using Account.Core.Models.Content.Business;
using Account.Core.Models.Content.Crafts;
using Account.Core.Models.Content.CraftsMen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.IServices.Content
{
    public interface ICraftsMenService
    {
        Task<ApiResponse> CreateCraftsMenAsync(CraftsMenModelDto model);
        Task<CraftsMenModelWitheUserandIdDto> GetCraftsMenByIdAsync(int id);
        Task<ApiResponse> UpdateCraftsMenAsync(int id, CraftsMenModelDto model);
        Task<ApiResponse> DeleteCraftsMenAsync(int id);
        Task<List<CraftsMenModelDto>> GetCraftsmenForUserAsync(string userId);
        Task<CraftsMenModel> FindByIdAsync(int id);
        Task<List<CraftsmanResponseDto>> GetAllCraftsmenWithDetailsAsync(int craftsId);
    }
}
