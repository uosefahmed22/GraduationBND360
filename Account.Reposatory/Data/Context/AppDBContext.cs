using Account.Core.Models.Account;
using Account.Core.Models.Content;
using Account.Core.Models.Content.Jobs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Account.Reposatory.Data.Context
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData
            (
                new IdentityRole { Name = "User", ConcurrencyStamp = "0", NormalizedName = "User" },
                new IdentityRole { Name = "BussinesOwner", ConcurrencyStamp = "1", NormalizedName = "BussinesOwner" },
                new IdentityRole { Name = "ServiceProvider", ConcurrencyStamp = "2", NormalizedName = "ServiceProvider" }
            );
        }
        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<RequirementArb> RequirementsArabic { get; set; }
        public DbSet<RequirementEnglish> RequirementEnglish { get; set; }


    }
}