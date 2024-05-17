using Account.Apis.Errors;
using Account.Core.Dtos;
using Account.Core.IServices.Content;
using Account.Reposatory.Services.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedJobsController : ControllerBase
    {
        private readonly ISavedServiceForJobs _savedServiceForJobs;

        public SavedJobsController(ISavedServiceForJobs savedServiceForJobs)
        {
            _savedServiceForJobs = savedServiceForJobs;
        }
        [HttpPost]
        public async Task<IActionResult> AddSavedModelForJobsDtoAsync(SavedModelForJobsDto savedModel)
        {
            var response = await _savedServiceForJobs.AddAsync(savedModel);
            return StatusCode(response.StatusCode, response.Message);
        }
        [HttpGet]
        public async Task<IActionResult> GetJobs(string userId)
        {
            try
            {
                var jobs = await _savedServiceForJobs.GetJobs(userId);
                return Ok(jobs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveJob(int id)
        {
            var result = await _savedServiceForJobs.RemoveAsync(id);
            return StatusCode(result.StatusCode, result.Message);
        }

    }
}
