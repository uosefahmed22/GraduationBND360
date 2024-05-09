using Account.Core.Models.Content.Jobs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Data.Config
{
    public class ContactConfigurations : IEntityTypeConfiguration<JobContact>
    {
        public void Configure(EntityTypeBuilder<JobContact> builder)
        {
            builder.Property(b => b.Url).IsRequired(false);
            builder.Property(b => b.Email).IsRequired(false);
            builder.Property(b => b.PhoneNumber).IsRequired(false);
        }
    }
}
