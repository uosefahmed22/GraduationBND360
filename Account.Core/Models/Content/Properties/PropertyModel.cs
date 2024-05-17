using Account.Core.Enums.Content.Property;
using Account.Core.Models.Content.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Account.Core.Models.Content.Properties
{
    public class PropertyModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ArabicDescription { get; set; }
        public string? EnglishDescription { get; set; }
        public string ArabicAddress { get; set; }
        public string? EnglishAddress { get; set; }
        public string WhatsappNumber { get; set; }
        public string Phonenumbers { get; set; }
        public string? Emails { get; set; }
        public string? URls { get; set; }
        public PublisherDetails? PublisherDetails { get; set; }
        public PropertyType Type { get; set; }
        public int Area { get; set; }
        public decimal Price { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string UserId { get; set; }
        public DateTime? TimeAddedProperty { get; set; } = DateTime.Now;
        public string? ImageName1 { get; set; }
        [NotMapped]
        public IFormFile image1 { get; set; }
        public string? ImageName2 { get; set; }
        [NotMapped]
        public IFormFile? image2 { get; set; }
        public string? ImageName3 { get; set; }
        [NotMapped]
        public IFormFile? image3 { get; set; }
        public string? ImageName4 { get; set; }
        [NotMapped]
        public IFormFile? image4 { get; set; }
    }
}