using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Content.Categories
{
    public class CategoriesModel
    {
        public int Id { get; set; }
        public string CategoryNameArabic { get; set; }
        public string? CategoryNameEnglish { get; set; }
        public string? ImageFileName { get; set; }

        [NotMapped]
        public IFormFile image {  get; set; }
    }
}
