using Account.Core.Models.Account;
using Account.Core.Models.Content.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Dtos.Saved
{
    public class SavedModelForJobsDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int JobId { get; set; }
    }
}
