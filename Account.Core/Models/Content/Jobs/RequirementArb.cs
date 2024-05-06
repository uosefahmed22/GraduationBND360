using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Content.Jobs
{
    public class RequirementArb
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int JobModelId { get; set; }

        public JobModel JobModel { get; set; }
    }
}
