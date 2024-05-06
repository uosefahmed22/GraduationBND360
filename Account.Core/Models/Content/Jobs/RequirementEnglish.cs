using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Content.Jobs
{
    public class RequirementEnglish
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int JobModelId { get; set; }

        public JobModel JobModel { get; set; }
    }
}
