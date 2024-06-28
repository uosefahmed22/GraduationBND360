using Account.Core.Models.Content.Business;
using Account.Core.Models.Content.Jobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Reposatory.Data.Config
{
    public class BusinessConfigurations : IEntityTypeConfiguration<BusinessModel>
    {
        public void Configure(EntityTypeBuilder<BusinessModel> builder)
        {
            builder.Property(b => b.Longitude)
                .HasColumnType("decimal(18, 14)");

            builder.Property(b => b.Latitude)
                .HasColumnType("decimal(18, 14)");
        }
    }
}
