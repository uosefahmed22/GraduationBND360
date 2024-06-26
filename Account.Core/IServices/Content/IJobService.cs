﻿using Account.Apis.Errors;
using Account.Core.Dtos.JobFolderDTO;
using Account.Core.Models.Content.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.IServices.Content
{
    public interface IJobService
    {
        Task<ApiResponse> AddAsync(JobModelDto model);
        Task<JobModelDto> FindByIdAsync(int id);
        Task<ApiResponse> UpdateAsync(int id, JobModelDto job);
        Task<ApiResponse> DeleteAsync(int id);
        Task<IEnumerable<JobModelDto>> GetJobs();
    }

}
