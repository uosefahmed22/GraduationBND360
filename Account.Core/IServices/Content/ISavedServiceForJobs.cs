using Account.Apis.Errors;
using Account.Core.Dtos;
using Account.Core.Dtos.JobFolderDTO;
using Account.Core.Models.Content.Saved;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.IServices.Content
{
    public interface ISavedServiceForJobs
    {
        Task<IEnumerable<JobModelDto>> GetJobs(string userId);
        Task<ApiResponse> AddAsync(SavedModelForJobsDto savedModel);
        Task<ApiResponse> RemoveAsync(int id);
    }
}
