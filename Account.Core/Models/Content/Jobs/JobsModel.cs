using Account.Core.Enums.Content;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Content.Jobs
{
    public class JobModel
    {
        public int Id { get; set; }
        public string JobTitleArabic { get; set; }
        public string? JobTitleEnglish { get; set; }
        public string JobDescriptionArabic { get; set; }
        public string? JobDescriptionEnglish { get; set; }
        public string Whatsapp { get; set; }
        public JobType Type { get; set; }
        public int WorkHours { get; set; }
        public decimal Salary { get; set; }
        public PublisherDetails PublisherDetails { get; set; }
        public ICollection<RequirementArb> RequirementsArabic { get; set; }
        public ICollection<RequirementEnglish> RequirementEnglish { get; set; }

        public List<Contact> Contacts { get; set; }

        public JobModel()
        {
            RequirementsArabic = new List<RequirementArb>();
            RequirementEnglish = new List<RequirementEnglish>();
            Contacts = new List<Contact>();
        }
    }
}
