using Account.Core.Dtos.CraftsFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Content.Crafts
{
    public class CraftsModel
    {
        public int Id { get; set; }
        public string CraftsNameArabic { get; set; }
        public string? CraftsNameEnglish { get; set; }
    }
}
