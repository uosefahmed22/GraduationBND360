using Account.Core.Models.Content.Crafts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.CraftsMenDtoFolder
{
    public class CraftsmanResponseDto
    {
        public int Id { get; set; }
        public string CraftsmanNameArabic { get; set; }
        public string? CraftsmanNameEnglish { get; set; }
        public string ProfileImageName { get; set; }
        public int TotalReviews { get; set; }
        public double AverageRating { get; set; }
        public CraftsModel CraftsModel { get; set; }
    }
}
