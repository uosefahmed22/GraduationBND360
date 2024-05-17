using Account.Core.Enums.Content;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Models.Content;
using Account.Core.Models.Content.Business;
using Account.Core.Dtos.JobFolderDTO;
using Account.Core.Models.Content.Categories;
using Account.Core.Dtos.CategoriesDto;

namespace Account.Core.Dtos.BusinessDto
{
    public class BusinessModelDto
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
    }
}
