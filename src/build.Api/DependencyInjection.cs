using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using build.Services.Mapper;
using build.Domain.Entities.Auth;
using build.Data.Configuration;
using build.Data.Context;

namespace build.Api
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddTransient<UserManager<ApplicationUser>>();

            services.AddIdentity<ApplicationUser, ApplicationRole>(o => o.SignIn.RequireConfirmedAccount = true)
             .AddRoles<ApplicationRole>()
             .AddRoleManager<RoleManager<ApplicationRole>>()
             .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtConfig:Secret"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                ValidIssuer = configuration["JwtConfig:Issuer"],
                ValidAudience = configuration["JwtConfig:Audience"],
                ClockSkew = TimeSpan.Zero,
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddSingleton(tokenValidationParameters);

            var connectionString = Environment.GetEnvironmentVariable("DockerCommandsConnectionString");
            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

            services.AddHttpsRedirection(options => options.HttpsPort = 9002);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://192.168.0.182:9002", "https://192.168.0.182:9002")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }
    }
}