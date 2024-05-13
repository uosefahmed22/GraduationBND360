using Account.Core.Models.Content.Jobs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Models.Content.Business;

namespace Account.Reposatory.Data.Config
{
    public class BusinessConfigurations : IEntityTypeConfiguration<BusinessModel>
    {
        public void Configure(EntityTypeBuilder<BusinessModel> builder)
        {
            builder.HasMany(p => p.ImageNames)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
