using Account.Apis.Errors;
using Account.Core.Dtos.CategoriesDto;
using Account.Core.Dtos.RatingAndReviewDto.Account.Core.Dtos.RatingAndReviewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.BusinessDto
{
    public class BusinessResponseInCategory
    {
        public int id { get; set; }
        public string BusinessNameArabic { get; set; }
        public string? BusinessNameEnglish { get; set; }
        public string BusinessDescriptionArabic { get; set; }
        public string? BusinessDescriptionEnglish { get; set; }
        public string ProfileImageName { get; set; }
        public int TotalReviews { get; set; }
        public double AverageRating { get; set; }
        public CategoriesModelDTO Category { get; set; }

    }
}
