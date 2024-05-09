using Account.Core.Models.Content.Jobs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Core.Models.Content.Properties;

namespace Account.Reposatory.Data.Config
{
    public class PropertyConfiguration : IEntityTypeConfiguration<PropertyModel>
    {
        public void Configure(EntityTypeBuilder<PropertyModel> builder)
        {
            builder.Property(b => b.Longitude)
                .HasColumnType("decimal(18, 2)");

            builder.Property(b => b.Latitude)
                .HasColumnType("decimal(18, 2)");

            builder.Property(b => b.Price)
                .HasColumnType("decimal(18, 2)");

            builder.HasMany(p => p.ImageNames)
           .WithOne()
           .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.PublisherDetails)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Navigation(p => p.Contacts)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.Ignore(p => p.images);
        }
    }

}
