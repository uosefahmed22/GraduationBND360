using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.BusinessDto
{
    public class BusinessReviewSummaryDtoForFaviorates
    {
        public int BusinessId { get; set; }
        public int TotalReviews { get; set; }
        public double AverageRating { get; set; }
    }
}
