using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.RatingAndReviewDto
{
    public class RatingAndReviewModelForCraftsmenDto
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public float? Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int CraftsmanId { get; set; }
        public string userId { get; set; }
    }
}
