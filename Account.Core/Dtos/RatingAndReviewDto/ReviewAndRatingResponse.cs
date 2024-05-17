using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.RatingAndReviewDto
{
    public class ReviewAndRatingResponse
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public float? Rating { get; set; }
    }

}
