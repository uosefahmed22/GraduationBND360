using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Content.RatingReview
{
    public class RatingAndReviewModelForBusiness
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public float? Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int businessId { get; set; }
        public string userId { get; set;}
    }
}
