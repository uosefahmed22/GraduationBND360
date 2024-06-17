using Account.Core.Dtos.CraftsMenDtoFolder;
using Account.Core.Models.Account;
using Account.Core.Models.Content;
using Account.Core.Models.Content.Business;
using Account.Core.Models.Content.Categories;
using Account.Core.Models.Content.Crafts;
using Account.Core.Models.Content.CraftsMen;
using Account.Core.Models.Content.Favorite;
using Account.Core.Models.Content.Jobs;
using Account.Core.Models.Content.Properties;
using Account.Core.Models.Content.RatingReview;
using Account.Core.Models.Content.Saved;
using Account.Reposatory.Services.Content;
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
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "BussinesOwner",
                    NormalizedName = "BUSSINESOWNER"
                },
                new IdentityRole
                {
                    Id = "4",
                    Name = "ServiceProvider",
                    NormalizedName = "SERVICEPROVIDER"
                }
            );
        }

        public DbSet<PropertyModel> Properties { get; set; }
        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<RequirementArb> RequirementsArabic { get; set; }
        public DbSet<RequirementEnglish> RequirementEnglish { get; set; }
        public DbSet<CategoriesModel> Categories { get; set; }
        public DbSet<BusinessModel> Businesses { get; set; }
        public DbSet<CraftsModel> crafts { get; set; }
        public DbSet<CraftsMenModel> CraftsMen { get; set; }
        public DbSet<SavedModelForProperty> PropertiesSaved { get; set; }
        public DbSet<SavedModelForJobs> JobsSaved { get; set; }
        public DbSet<FavoriteModelForBusiness> BusinessFavorites { get; set; }
        public DbSet<FavoriteModelForCraftsmen> ServiceProvidersFavorites { get; set; }
        public DbSet<RatingAndReviewModelForBusiness> ratingAndReviewModelForBusinesses { get; set; }
        public DbSet<RatingAndReviewModelForCraftsmen> ratingAndReviewModelForCraftsmens { get; set; }
    }
}