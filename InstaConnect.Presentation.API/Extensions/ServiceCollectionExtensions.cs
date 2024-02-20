using InstaConnect.Business.Models.Options;
using InstaConnect.Data.Models.Options;
using InstaConnect.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Text;
using TokenOptions = InstaConnect.Data.Models.Options.TokenOptions;

namespace InstaConnect.Presentation.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var corsOptions = configuration.GetSection(nameof(CorsOptions));
            var adminOptions = configuration.GetSection(nameof(AdminOptions));
            var tokenOptions = configuration.GetSection(nameof(TokenOptions));
            var emailOptions = configuration.GetSection(nameof(EmailOptions));

            services
                .Configure<AdminOptions>(adminOptions)
                .Configure<TokenOptions>(tokenOptions)
                .Configure<EmailOptions>(emailOptions);

            var corsOptionsObj = corsOptions.Get<CorsOptions>();
            var tokenOptionsObj = tokenOptions.Get<TokenOptions>()!;

            services.AddCors(options =>
            {
                options.AddPolicy("AllowedOrigins",
                         p => p.WithOrigins(corsOptionsObj!.Hosts)
                               .AllowAnyMethod()
                               .AllowAnyHeader());
            });

            services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
            });

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(configuration =>
                {
                    configuration.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptionsObj.AccessTokenSecurityKey)),
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

            services
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

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddSignalR();

            services
                .Configure<CookieAuthenticationOptions>(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromHours(int.Parse(tokenOptions["UserTokenLifetimeSeconds"]));
                });

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("x-version"),
                    new MediaTypeApiVersionReader("ver")
                );
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
