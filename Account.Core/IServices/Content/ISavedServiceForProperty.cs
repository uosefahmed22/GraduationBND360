using Account.Apis.Errors;
using Account.Core.Dtos.JobFolderDTO;
using Account.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Dtos.PropertyFolderDto;

namespace Account.Core.IServices.Content
{
    public interface ISavedServiceForProperty
    {
        Task<IEnumerable<PropertyModelDTO>> GetProperty(string userId);
        Task<ApiResponse> AddAsync(SavedModelForPropertyDto savedModel);
        Task<ApiResponse> RemoveAsync(int id);
    }
}
