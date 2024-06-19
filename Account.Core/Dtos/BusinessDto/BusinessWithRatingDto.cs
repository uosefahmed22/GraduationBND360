﻿using Account.Core.Dtos.CategoriesDto;
using Account.Core.Enums.Content;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.BusinessDto
{
    public class BusinessWithRatingsDto
    {
        public int Id { get; set; }
        public string BusinessNameArabic { get; set; }
        public string? BusinessNameEnglish { get; set; }
        public int CategoriesModelId { get; set; }
        public string BusinessDescriptionArabic { get; set; }
        public string? BusinessDescriptionEnglish { get; set; }
        public string BusinessAddressArabic { get; set; }
        public DayOfWeekEnum? Holidays { get; set; }
        public string? BusinessAddressEnglish { get; set; }
        public string Phonenumbers { get; set; }
        public string? Emails { get; set; }
        public string? URls { get; set; }
        public int Opening { get; set; }
        public int Closing { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string UserId { get; set; }
        public CategoriesModelDTO? CategoriesModel { get; set; }
        public string? ProfileImageName { get; set; }
        [NotMapped]
        public IFormFile ProfileImage { get; set; }
        public string? BusinessImageName1 { get; set; }
        [NotMapped]
        public IFormFile BusinessImage1 { get; set; }
        public string? BusinessImageName2 { get; set; }
        [NotMapped]
        public IFormFile? BusinessImage2 { get; set; }
        public string? BusinessImageName3 { get; set; }
        [NotMapped]
        public IFormFile? BusinessImage3 { get; set; }
        public string? BusinessImageName4 { get; set; }
        [NotMapped]
        public IFormFile? BusinessImage4 { get; set; }
        public int TotalReviews { get; set; }
        public double AverageRating { get; set; }
        public string UserName { get; set; }
        public string UserProfileImageName { get; set; }
    }
}
