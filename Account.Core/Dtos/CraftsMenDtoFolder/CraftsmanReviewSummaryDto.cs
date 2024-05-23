using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.CraftsMenDtoFolder
{
    public class CraftsmanReviewSummaryDto
    {
        public int CraftsmanId { get; set; }
        public int TotalReviews { get; set; }
        public double AverageRating { get; set; }
    }
}
