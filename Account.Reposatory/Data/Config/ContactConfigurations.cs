using Account.Core.Models.Content.Jobs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Models.Content;

namespace Account.Reposatory.Data.Config
{
    public class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(b => b.Url).IsRequired(false);
            builder.Property(b => b.Email).IsRequired(false);
            builder.Property(b => b.PhoneNumber).IsRequired(false);
        }
    }
}
