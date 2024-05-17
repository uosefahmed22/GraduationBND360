using Account.Apis.Errors;
using Account.Core.Dtos.JobFolderDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Dtos.PropertyFolderDto;
using Account.Core.Dtos.Saved;

namespace Account.Core.IServices.Content
{
    public interface ISavedServiceForProperty
    {
        Task<IEnumerable<PropertyModelDTO>> GetProperty(string userId);
        Task<ApiResponse> AddAsync(SavedModelForPropertyDto savedModel);
        Task<ApiResponse> RemoveAsync(int id);
    }
}
