using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Content.RatingReview
{
    public class RatingAndReviewModelForCraftsmen
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public float? Rating { get; set; }

        private readonly TimeZoneInfo timeZone;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CraftsmanId { get; set; }
        public string userId { get; set; }
        public RatingAndReviewModelForCraftsmen()
        {
            timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            CreatedAt = TimeZoneInfo.ConvertTime(DateTime.Now, timeZone);
        }
    }
}
