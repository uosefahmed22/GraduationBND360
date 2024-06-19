using Account.Core.Dtos.CraftsFolder;
using Account.Core.Enums.Content;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.CraftsMenDtoFolder
{
    public class CraftsManWithRatingsDto
    {
        public int Id { get; set; }
        public string CraftsMenNameArabic { get; set; }
        public string? CraftsMenNameEnglish { get; set; }
        public int CraftsModelId { get; set; }
        public string CraftsMenDescriptionArabic { get; set; }
        public string? CraftsMenDescriptionEnglish { get; set; }
        public string CraftsMenAddressArabic { get; set; }
        public string? CraftsMenAddressEnglish { get; set; }
        public DayOfWeekEnum? Holidays { get; set; }
        public string Phonenumbers { get; set; }
        public string? Emails { get; set; }
        public string? URIs { get; set; }
        public int Opening { get; set; }
        public int Closing { get; set; }
        public string UserId { get; set; }
        public CraftsModelDto? CraftsModel { get; set; }
        public string? ProfileImageName { get; set; }
        [NotMapped]
        public IFormFile ProfileImage { get; set; }
        public string? CraftsMenImageName1 { get; set; }
        [NotMapped]
        public IFormFile CraftsMenImage1 { get; set; }
        public string? CraftsMenImageName2 { get; set; }
        [NotMapped]
        public IFormFile? CraftsMenImage2 { get; set; }
        public string? CraftsMenImageName3 { get; set; }
        [NotMapped]
        public IFormFile? CraftsMenImage3 { get; set; }
        public string? CraftsMenImageName4 { get; set; }
        [NotMapped]
        public IFormFile? CraftsMenImage4 { get; set; }
        public int TotalReviews { get; set; }
        public double AverageRating { get; set; }
        public string UserName { get; set; }
        public string UserProfileImageName { get; set; }
    }
}
