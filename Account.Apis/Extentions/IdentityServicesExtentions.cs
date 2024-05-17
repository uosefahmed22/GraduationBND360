using Account.Core.Models.Account;
using Account.Core.Services.Auth;
using Account.Reposatory.Data.Context;
using Account.Reposatory.Services.Authentications;
using Account.services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Account.Apis.Extentions
{
    public static class IdentityServicesExtentions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add identity services with specified user and role classes
            services.AddIdentity<AppUser, IdentityRole>(Options =>
            {
            })
            // Configure identity to use Entity Framework stores
            .AddEntityFrameworkStores<AppDBContext>()
            .AddDefaultTokenProviders().AddRoles<IdentityRole>();

            // Add authentication services
            services.AddAuthentication(Options =>
            {
                // Set default authentication scheme to JWT bearer authentication
                Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Configure JWT bearer authentication
            .AddJwtBearer(Options =>
            {
                Options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]))
                };
            });

            services.AddDbContext<AppDBContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("DefaultConnections"));
            });

            // Register custom token service
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<IProfileService, ProfileService>();




            // Add here any other injections.....
            return services;
        }

    }
}
