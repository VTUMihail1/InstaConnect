using System.Text.Json.Serialization;
using System.Threading.RateLimiting;

using Asp.Versioning;

using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Domain.Utilities;
using InstaConnect.Common.Events.Models;
using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Presentation.Binders.FromClaim;
using InstaConnect.Common.Presentation.Binders.FromCookie;
using InstaConnect.Common.Presentation.Conventions;
using InstaConnect.Common.Presentation.ExceptionHandlers;
using InstaConnect.Common.Presentation.Helpers;
using InstaConnect.Common.Presentation.Models.Options;
using InstaConnect.Common.Presentation.Utilities;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

namespace InstaConnect.Common.Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        public IServiceCollection AddAuthorizationPolicies()
        {
            serviceCollection.AddAuthorizationBuilder()
                .SetDefaultPolicy(new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .RequireClaim(DefaultClaims.Id)
                    .Build())
                .AddPolicy(AuthorizationPolicies.Admin, policy => policy.RequireClaim(ApplicationClaims.Admin.GetName()));

            return serviceCollection;
        }

        public IServiceCollection AddApiControllers()
        {
            serviceCollection.AddHttpContextAccessor()
                             .AddScoped<ICookieStore, CookieStore>();

            serviceCollection.AddControllers(options =>
            {
                options.ValueProviderFactories.Add(new FromClaimValueProviderFactory());
                options.ValueProviderFactories.Add(new FromCookieValueProviderFactory());
                options.Conventions.Add(new CamelCaseQueryConvention());
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            serviceCollection.Configure<ApiBehaviorOptions>(options =>
                options.SuppressInferBindingSourcesForParameters = true);

            serviceCollection.AddApiVersioning(options =>
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

        public IServiceCollection AddExceptionHandler()
        {
            serviceCollection.AddSingleton<IApplicationProblemDetailsFactory, ApplicationProblemDetailsFactory>()
                             .AddSingleton<IApplicationProblemDetailsService, ApplicationProblemDetailsService>()
                             .AddImplementationsOf<IBaseExceptionStatus>(CommonPresentationReference.Assembly);

            serviceCollection.AddProblemDetails();

            serviceCollection.AddExceptionHandler<InvalidValidationExceptionHandler>()
                             .AddExceptionHandler<BaseExceptionHandler>()
                             .AddExceptionHandler<ExceptionHandler>();

            return serviceCollection;
        }

        public IServiceCollection AddCorsPolicies(IConfiguration configuration)
        {
            serviceCollection.AddValidatedOptions<CorsOptions>(CorsOptions.SectionName);
            var options = configuration.GetOptions<CorsOptions>(CorsOptions.SectionName);

            serviceCollection.AddCors(o =>
            {
                o.AddDefaultPolicy(builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod());

                o.AddPolicy(CorsPolicies.SpecificOrigins, builder =>
                    builder.WithOrigins(options.AllowedOrigins.Split(", "))
                           .AllowAnyHeader()
                           .AllowAnyMethod());
            });

            return serviceCollection;
        }

        public IServiceCollection AddRateLimiterPolicies()
        {
            serviceCollection.AddRateLimiter(options =>
            {
                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                options.AddPolicy(RateLimiterPolicies.Default,
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
    }
}
