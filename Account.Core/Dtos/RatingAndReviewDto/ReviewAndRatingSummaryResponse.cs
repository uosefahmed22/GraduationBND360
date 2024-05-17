﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.RatingAndReviewDto
{
    namespace Account.Core.Dtos.RatingAndReviewDto
    {
        public class ReviewAndRatingSummaryResponse
        {
            public int TotalReviews { get; set; }
            public double AverageRating { get; set; }
            public int FiveStars { get; set; }
            public int FourStars { get; set; }
            public int ThreeStars { get; set; }
            public int TwoStars { get; set; }
            public int OneStars { get; set; }
        }
    }

}
