using Account.Apis.Errors;
using Account.Core.Dtos.BusinessDto;
using Account.Core.Dtos.FavoirteDto;
using Account.Core.Dtos.JobFolderDTO;
using Account.Core.Dtos.Saved;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.IServices.Content
{
    public interface IFavoriteForBusinessService
    {
        Task<IEnumerable<BusinessWithRatingsDto>> GetBusinesses(string userId);
        Task<ApiResponse> AddAsync(FavoriteModelForBusinessDto savedModel);
        Task<ApiResponse> RemoveAsync(int id);
    }
}
