﻿using Account.Core.Dtos.JobFolderDTO;
using Account.Core.IServices.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers
{
    public class JobController : ApiBaseController
    {
        private readonly IJobService _jobRepository;

        public JobController(IJobService jobRepository)
        {
            _jobRepository = jobRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddJob(JobModelDto model)
        {
            var result = await _jobRepository.AddAsync(model);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var result = await _jobRepository.DeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var job = await _jobRepository.FindByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _jobRepository.GetJobs();
            return Ok(jobs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, JobModelDto job)
        {
            var result = await _jobRepository.UpdateAsync(id, job);
            return StatusCode(result.StatusCode, result);
        }
    }
}