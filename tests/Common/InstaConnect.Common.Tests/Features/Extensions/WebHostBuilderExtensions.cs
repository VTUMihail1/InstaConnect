using InstaConnect.Common.Infrastructure.Features.Caching.Models;
using InstaConnect.Common.Infrastructure.Features.Data.Models;
using InstaConnect.Common.Infrastructure.Features.Events.Models;
using InstaConnect.Common.Infrastructure.Features.Images.Models;
using InstaConnect.Common.Infrastructure.Features.Observability.Models;
using InstaConnect.Common.Infrastructure.Features.Tokens.Models;
using InstaConnect.Common.Presentation.Features.Controllers.Models;
using InstaConnect.Common.Tests.Features.Utilities;

using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Common.Tests.Features.Extensions;

public static class WebHostBuilderExtensions
{
    extension(IWebHostBuilder webHostBuilder)
    {
        public void UpdateMongoConfiguration(string connectionString)
        {
            webHostBuilder.UseSetting(
                MongoOptions.SectionName.FormatCurrentCultureSectionKey(nameof(MongoOptions.ConnectionString)),
                connectionString);

            webHostBuilder.UseSetting(MongoOptions.SectionName.FormatCurrentCultureSectionKey(nameof(MongoOptions.Name)),
                MockValues.MongoName);
        }

        public void UpdateRedisConfiguration(string connectionString)
        {
            webHostBuilder.UseSetting(
                RedisOptions.SectionName.FormatCurrentCultureSectionKey(nameof(RedisOptions.ConnectionString)),
                connectionString);
        }

        public void UpdateRabbitMqConfiguration(string connectionString)
        {
            webHostBuilder.UseSetting(
                RabbitMqOptions.SectionName.FormatCurrentCultureSectionKey(nameof(RabbitMqOptions.ConnectionString)),
                connectionString);
        }

        public void UpdateCloudinaryConfiguration()
        {
            webHostBuilder.UseSetting(
                CloudinaryOptions.SectionName.FormatCurrentCultureSectionKey(nameof(CloudinaryOptions.CloudName)),
                MockValues.CloudinaryCloudName);

            webHostBuilder.UseSetting(
                CloudinaryOptions.SectionName.FormatCurrentCultureSectionKey(nameof(CloudinaryOptions.ApiKey)),
                MockValues.CloudinaryApiKey);

            webHostBuilder.UseSetting(
                CloudinaryOptions.SectionName.FormatCurrentCultureSectionKey(nameof(CloudinaryOptions.ApiSecret)),
                MockValues.CloudinaryApiSecret);
        }

        public void UpdateAccessTokenConfiguration()
        {
            webHostBuilder.UseSetting(
                AccessTokenOptions.SectionName.FormatCurrentCultureSectionKey(nameof(AccessTokenOptions.SecurityKey)),
                MockValues.AccessTokenSecurityKey);

            webHostBuilder.UseSetting(
                AccessTokenOptions.SectionName.FormatCurrentCultureSectionKey(nameof(AccessTokenOptions.Issuer)),
                MockValues.AccessTokenIssuer);

            webHostBuilder.UseSetting(
                AccessTokenOptions.SectionName.FormatCurrentCultureSectionKey(nameof(AccessTokenOptions.Audience)),
                MockValues.AccessTokenAudience);
        }

        public void UpdateOpenTelemetryConfiguration()
        {
            webHostBuilder.UseSetting(
                OpenTelemetryOptions.SectionName.FormatCurrentCultureSectionKey(nameof(OpenTelemetryOptions.Endpoint)),
                MockValues.OpenTelemetryEndpoint);
        }

        public void UpdateCorsConfiguration()
        {
            webHostBuilder.UseSetting(
                CorsOptions.SectionName.FormatCurrentCultureSectionKey(nameof(CorsOptions.AllowedOrigins)),
                MockValues.CorsAllowedOrigins);
        }
    }
}
