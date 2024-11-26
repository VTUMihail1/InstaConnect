using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using Asp.Versioning;
using InstaConnect.Shared.Common.Utilities;
using InstaConnect.Shared.Presentation.Abstractions;
using InstaConnect.Shared.Presentation.ExceptionHandlers;
using InstaConnect.Shared.Presentation.Helpers;
using InstaConnect.Shared.Presentation.Models.Options;
using InstaConnect.Shared.Presentation.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace InstaConnect.Shared.Presentation.Extensions;
public static class ServiceCollectionExtensions
{
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
