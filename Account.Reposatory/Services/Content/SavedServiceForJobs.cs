using Account.Apis.Errors;
using Account.Core.Dtos;
using Account.Core.Dtos.JobFolderDTO;
using Account.Core.IServices.Content;
using Account.Core.Models.Content.Jobs;
using Account.Core.Models.Content.Saved;
using Account.Reposatory.Data.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Services.Content
{
    public class SavedServiceForJobs : ISavedServiceForJobs
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public SavedServiceForJobs(AppDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApiResponse> AddAsync(SavedModelForJobsDto savedModel)
        {
            try
            {
                var entity = _mapper.Map<SavedModelForJobs>(savedModel);

                _context.JobsSaved.Add(entity);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Record added successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, $"Failed to add record: {ex.Message}");
            }
        }
        public async Task<IEnumerable<JobModelDto>> GetJobs(string userId)
        {
            //method =>1 
            //try
            //{
            //    var jobsEntities = await _context.Jobs
            //        .Include(k => k.RequirementsArabic)
            //        .Include(k => k.RequirementEnglish)
            //        .Include(k => k.PublisherDetails)
            //        .Join(_context.JobsSaved, j => j.Id, s => s.JobId, (j, s) => new { Job = j, Saved = s })
            //        .Where(x => x.Saved.UserId == userId)
            //        .Select(x => x.Job)
            //        .ToListAsync();

            //    return _mapper.Map<IEnumerable<JobModelDto>>(jobsEntities);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //method=>2
            try
            {
                var savedJobIds = await _context.JobsSaved
                    .Where(s => s.UserId == userId)
                    .Select(s => s.JobId)
                    .ToListAsync();

                var jobs = await _context.Jobs
                    .Include(k => k.RequirementsArabic)
                    .Include(k => k.RequirementEnglish)
                    .Include(k => k.PublisherDetails)
                    .Where(j => savedJobIds.Contains(j.Id))
                    .ToListAsync();

                return _mapper.Map<IEnumerable<JobModelDto>>(jobs);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<ApiResponse> RemoveAsync(int id)
        {
            try
            {
                var savedJob = await _context.JobsSaved.FindAsync(id);

                if (savedJob == null)
                    return new ApiResponse(404, "Record not found.");

                _context.JobsSaved.Remove(savedJob);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Record removed successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(400, $"Failed to remove record: {ex.Message}");
            }
        }
    }
}
