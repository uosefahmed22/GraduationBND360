using Account.Core.Enums.Content;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Models.Content.Jobs;

namespace Account.Core.Dtos.Content.JobFolderDTO
{
    public class JobModelDto
    {
        public string JobTitleArabic { get; set; }
        public string JobTitleEnglish { get; set; }
        public string JobDescriptionArabic { get; set; }
        public string JobDescriptionEnglish { get; set; }
        public string Whatsapp { get; set; }
        public List<RequirementDTO> RequirementsArabic { get; set; }
        public List<RequirementDTO> RequirementEnglish { get; set; }
        public PublisherDetailsDTO PublisherDetails { get; set; }
        public string Type { get; set; }
        public int WorkHours { get; set; }
        public decimal Salary { get; set; }
        public List<ContactDTO> Contacts { get; set; }

        public JobModelDto()
        {
            RequirementsArabic = new List<RequirementDTO>();
            RequirementEnglish = new List<RequirementDTO>();
            Contacts = new List<ContactDTO>();
        }
    }
}
