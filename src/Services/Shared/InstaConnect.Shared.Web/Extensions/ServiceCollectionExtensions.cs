using System.Reflection;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using Asp.Versioning;
using InstaConnect.Shared.Data.Models.Options;
using InstaConnect.Shared.Data.Utilities;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.ExceptionHandlers;
using InstaConnect.Shared.Web.Helpers;
using InstaConnect.Shared.Web.Models.Options;
using InstaConnect.Shared.Web.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace InstaConnect.Shared.Web.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJwtBearer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
        .AddOptions<TokenOptions>()
        .BindConfiguration(nameof(TokenOptions))
        .ValidateDataAnnotations()
        .ValidateOnStart();

        var tokenOptions = configuration
            .GetSection(nameof(TokenOptions))
            .Get<TokenOptions>()!;

        serviceCollection
            .AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(tokenOptions.AccessTokenSecurityKeyByteArray),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        return serviceCollection;
    }

    public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAuthorizationBuilder()
            .SetDefaultPolicy(new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim(ClaimTypes.NameIdentifier)
                .Build())
            .AddPolicy(AppPolicies.AdminPolicy, policy => policy.RequireClaim(AppClaims.Admin));

        return serviceCollection;
    }

    public static IServiceCollection AddApiControllers(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        return serviceCollection;
    }

    public static IServiceCollection ConfigureApiBehaviorOptions(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);

        return serviceCollection;
    }

    public static IServiceCollection AddExceptionHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddProblemDetails();
        serviceCollection.AddExceptionHandler<AppExceptionHandler>();

        return serviceCollection;
    }

    public static IServiceCollection AddCorsPolicies(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddOptions<CorsOptions>()
            .BindConfiguration(nameof(CorsOptions))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var corsOptions = configuration
            .GetSection(nameof(CorsOptions))
            .Get<CorsOptions>()!;

        serviceCollection.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod());

            options.AddPolicy(AppPolicies.CorsPolicy, builder =>
                builder.WithOrigins(corsOptions.AllowedOrigins.Split(", "))
                       .AllowAnyHeader()
                       .AllowAnyMethod());
        });

        return serviceCollection;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddEndpointsApiExplorer();

        serviceCollection.AddSwaggerGen(c =>
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

                    //var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlfile);
                    //c.IncludeXmlComments(xmlPath);
                });

        return serviceCollection;
    }

    public static IServiceCollection AddRateLimiterPolicies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.AddPolicy(AppPolicies.RateLimiterPolicy,
                httpContext => RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: httpContext.Connection.RemoteIpAddress?.ToString(),
                    factory: _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 100,
                        Window = TimeSpan.FromSeconds(10),
                    }));
        });

        return serviceCollection;
    }

    public static IServiceCollection AddVersioning(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;

            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        return serviceCollection;
    }

    public static IServiceCollection AddCurrentUserContext(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddHttpContextAccessor()
            .AddScoped<ICurrentUserContext, CurrentUserContext>();

        return serviceCollection;
    }
}
