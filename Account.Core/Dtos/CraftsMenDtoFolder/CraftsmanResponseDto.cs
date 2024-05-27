using Account.Core.Dtos.CraftsFolder;
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
        public string CraftsMenNameArabic { get; set; }
        public string? CraftsMenNameEnglish { get; set; }
        public string ProfileImageName { get; set; }
        public int TotalReviews { get; set; }
        public double AverageRating { get; set; }
        public CraftsModelDto CraftsModel { get; set; }
    }
}
