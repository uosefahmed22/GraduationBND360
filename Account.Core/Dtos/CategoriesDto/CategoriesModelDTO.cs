using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.CategoriesDto
{
    public class CategoriesModelDTO
    {
        public string CategoryNameArabic { get; set; }
        public string? CategoryNameEnglish { get; set; }
        public string? ImageFileName { get; set; }

        public IFormFile image { get; set; }
    }
}
