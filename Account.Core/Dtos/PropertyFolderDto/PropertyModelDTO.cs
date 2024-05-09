﻿using Account.Core.Enums.Content.Property;
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
        public string ArabicDescription { get; set; }
        public string? EnglishDescription { get; set; }
        public string ArabicAddress { get; set; }
        public string? EnglishAddress { get; set; }
        public string WhatsappNumber { get; set; }
        public PublisherDetailsDTO? PublisherDetails { get; set; }
        public PropertyContactDto? Contacts { get; set; }
        public PropertyType Type { get; set; }
        public int Area { get; set; }
        public decimal Price { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public List<ImageNamesModelDto>? ImageNames { get; set; }
        public List<IFormFile> images { get; set; }
    }
}
