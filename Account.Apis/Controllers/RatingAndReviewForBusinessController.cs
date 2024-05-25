﻿using Account.Core.Dtos.RatingAndReviewDto;
using Account.Core.IServices.Content;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingAndReviewForBusinessController : ControllerBase
    {
        private readonly IServiceForRatingAndReviewsForBusiness _serviceForRatingAndReviewsForBusiness;

        public RatingAndReviewForBusinessController(IServiceForRatingAndReviewsForBusiness serviceForRatingAndReviewsForBusiness)
        {
            _serviceForRatingAndReviewsForBusiness = serviceForRatingAndReviewsForBusiness;
        }
        [HttpPost]
        public async Task<IActionResult> AddRatingAndReview([FromBody] RatingAndReviewModelForBusinessDto model)
        {
            var response = await _serviceForRatingAndReviewsForBusiness.AddAsync(model);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{businessId}")]   
        public async Task<IActionResult> GetReviewsAndRatings(int businessId)
        {
            var reviews = await _serviceForRatingAndReviewsForBusiness.GetReviewsAndRatings(businessId);
            return Ok(reviews);
        }

        [HttpDelete("{reviewAndRatingId}")]
        public async Task<IActionResult> RemoveRatingAndReview(int reviewAndRatingId)
        {
            var response = await _serviceForRatingAndReviewsForBusiness.RemoveAsync(reviewAndRatingId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("summary/{businessId}")]
        public async Task<IActionResult> GetReviewsAndRatingsSummary(int businessId)
        {
            var summary = await _serviceForRatingAndReviewsForBusiness.GetReviewsAndRatingsForBusinessWithDetailsAsync(businessId);
            return Ok(summary);
        }
    }
}
