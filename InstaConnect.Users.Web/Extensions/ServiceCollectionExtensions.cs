using InstaConnect.Users.Data.Models.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using TokenOptions = InstaConnect.Users.Data.Models.Options.TokenOptions;

namespace InstaConnect.Users.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollections, IConfiguration configuration)
        {
            var tokenOptions = configuration.GetSection(nameof(TokenOptions));
            var adminOptions = configuration.GetSection(nameof(AdminOptions));

            serviceCollections.Configure<TokenOptions>(tokenOptions);
            serviceCollections.Configure<AdminOptions>(adminOptions);

            var tokenOptionsObj = tokenOptions.Get<TokenOptions>()!;

            serviceCollections
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            serviceCollections.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
            });

            serviceCollections
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(configuration =>
                {
                    configuration.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptionsObj.AccountTokenSecurityKey)),
                        ValidateAudience = true,
                        ValidAudience = tokenOptionsObj.Audience,
                        ValidateIssuer = true,
                        ValidIssuer = tokenOptionsObj.Issuer,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero
                    };
                }
            );

            serviceCollections
                .AddSwaggerGen(c =>
                {
                    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    }
                },
                Array.Empty<string>()
            }
                    });
                }
            );

            serviceCollections.AddEndpointsApiExplorer();
            serviceCollections.AddSwaggerGen();

            serviceCollections
                .Configure<CookieAuthenticationOptions>(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromSeconds(tokenOptionsObj.AccountTokenLifetimeSeconds);
                });

            serviceCollections.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);

            serviceCollections.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return serviceCollections;
        }
    }
}
