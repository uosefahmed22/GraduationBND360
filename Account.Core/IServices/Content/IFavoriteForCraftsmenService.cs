using Account.Apis.Errors;
using Account.Core.Dtos.BusinessDto;
using Account.Core.Dtos.CraftsMenDtoFolder;
using Account.Core.Dtos.FavoirteDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.IServices.Content
{
    public interface IFavoriteForCraftsmenService
    {
        Task<IEnumerable<CraftsMenModelDto>> GetCraftsmanFavorites(string userId);
        Task<ApiResponse> AddAsync(FavoriteModelForCraftsmenDto savedModel);
        Task<ApiResponse> RemoveAsync(int CraftsmanId);
    }
}
