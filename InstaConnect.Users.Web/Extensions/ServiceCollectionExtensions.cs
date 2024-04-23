using InstaConnect.Users.Data.Models.Options;
using InstaConnect.Users.Web.Profiles;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using TokenOptions = InstaConnect.Users.Data.Models.Options.TokenOptions;

namespace InstaConnect.Users.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var tokenOptions = configuration.GetSection(nameof(TokenOptions));
            var adminOptions = configuration.GetSection(nameof(AdminOptions));

            serviceCollection.Configure<TokenOptions>(tokenOptions);
            serviceCollection.Configure<AdminOptions>(adminOptions);

            var tokenOptionsObj = tokenOptions.Get<TokenOptions>()!;

            serviceCollection
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            serviceCollection.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
            });

            serviceCollection
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

            serviceCollection
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

            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen();

            serviceCollection
                .Configure<CookieAuthenticationOptions>(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromSeconds(tokenOptionsObj.AccountTokenLifetimeSeconds);
                });

            serviceCollection.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);

            serviceCollection.AddAutoMapper(typeof(UsersWebProfile));

            return serviceCollection;
        }
    }
}
