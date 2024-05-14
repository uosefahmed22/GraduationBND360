using Account.Core.Dtos.JobFolderDTO;
using Account.Core.Enums.Content.Property;
using Account.Core.Models.Content;
using Account.Core.Models.Content.Properties;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.PropertyFolderDto
{
    public class PropertyModelDTO
    {
        public int Id { get; set; }
        public string ArabicDescription { get; set; }
        public string? EnglishDescription { get; set; }
        public string ArabicAddress { get; set; }
        public string? EnglishAddress { get; set; }
        public string WhatsappNumber { get; set; }
        public string Phonenumbers { get; set; }
        public string? Emails { get; set; }
        public string? URls { get; set; }
        public PublisherDetailsDTO? PublisherDetails { get; set; }
        public PropertyType Type { get; set; }
        public int Area { get; set; }
        public decimal Price { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public DateTime? TimeAddedProperty { get; set; } = DateTime.Now;
        public string? ImageName1 { get; set; }
        public IFormFile image1 { get; set; }
        public string? ImageName2 { get; set; }
        public IFormFile image2 { get; set; }
        public string? ImageName3 { get; set; }
        public IFormFile image3 { get; set; }
        public string? ImageName4 { get; set; }
        public IFormFile image4 { get; set; }
    }
}
