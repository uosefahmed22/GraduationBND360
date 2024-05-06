using Account.Core.Models.Content.Jobs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Account.Reposatory.Data.Config
{
    public class JobModelConfiguration : IEntityTypeConfiguration<JobModel>
    {
        public void Configure(EntityTypeBuilder<JobModel> builder)
        {
            builder.Property(b => b.Salary)
                .HasColumnType("decimal(18, 2)");

            builder.HasMany(j => j.RequirementsArabic)
                .WithOne(r => r.JobModel)
                .HasForeignKey(r => r.JobModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(j => j.RequirementEnglish)
                .WithOne(r => r.JobModel)
                .HasForeignKey(r => r.JobModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(j => j.Contacts)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }



}