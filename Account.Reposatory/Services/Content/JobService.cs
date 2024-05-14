using Account.Apis.Errors;
using Account.Core.Dtos.JobFolderDTO;
using Account.Core.IServices.Content;
using Account.Core.Models.Content.Jobs;
using Account.Reposatory.Data.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Services.Content
{
    public class JobService : IJobService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public JobService(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ApiResponse> AddAsync(JobModelDto model)
        {

            var jobEntity = _mapper.Map<JobModel>(model);
            _context.Jobs.Add(jobEntity);
            await _context.SaveChangesAsync();

            return new ApiResponse(200, "Job added successfully.");
        }
        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var existingJob = await _context.Jobs.FindAsync(id);

                if (existingJob == null)
                {
                    return new ApiResponse(404, "Job not found.");
                }

                _context.Jobs.Remove(existingJob);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Job deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, $"Failed to delete job: {ex.Message}");
            }
        }
        public async Task<JobModelDto> FindByIdAsync(int id)
        {
            try
            {
                var jobEntity = await _context.Jobs
                    .Include(k => k.RequirementsArabic)
                    .Include(k => k.RequirementEnglish)
                    .Include(k => k.PublisherDetails)
                    .FirstOrDefaultAsync(j => j.Id == id);

                if (jobEntity == null)
                {
                    return null;
                }

                if (jobEntity.PublisherDetails == null)
                {
                    return null;
                }

                return _mapper.Map<JobModelDto>(jobEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<JobModelDto>> GetJobs()
        {
            try
            {
                var jobsEntities = await _context.Jobs
                    .Include(k => k.RequirementsArabic)
                    .Include(k => k.RequirementEnglish)
                    .Include(k => k.PublisherDetails)

                    .ToListAsync();

                return _mapper.Map<IEnumerable<JobModelDto>>(jobsEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ApiResponse> UpdateAsync(int id, JobModelDto job)
        {
            var existingJob = await _context.Jobs
                                            .Include(j => j.RequirementsArabic)
                                            .Include(j => j.RequirementEnglish)
                                            .Include(j => j.PublisherDetails)
                                            .FirstOrDefaultAsync(j => j.Id == id);

            if (existingJob == null)
            {
                return new ApiResponse(404, "Job not found.");
            }
            _mapper.Map(job, existingJob);
            _mapper.Map(job.PublisherDetails, existingJob.PublisherDetails);

            existingJob.RequirementsArabic.Clear();
            existingJob.RequirementEnglish.Clear();
            foreach (var req in job.RequirementsArabic)
            {
                existingJob.RequirementsArabic.Add(_mapper.Map<RequirementArb>(req));
            }
            foreach (var req in job.RequirementEnglish)
            {
                existingJob.RequirementEnglish.Add(_mapper.Map<RequirementEnglish>(req));
            }


            await _context.SaveChangesAsync();

            return new ApiResponse(200, "Job updated successfully.");
        }
    }
}