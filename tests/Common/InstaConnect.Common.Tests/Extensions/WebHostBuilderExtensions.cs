using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Infrastructure.Models.Options;

using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Common.Tests.Extensions;

public static class WebHostBuilderExtensions
{
    extension(IWebHostBuilder webHostBuilder)
    {
        public void UpdateDatabaseConnectionString(string connectionString)
        {
            const string Format = "{0}:{1}";

            webHostBuilder.UseSetting(
                Format.FormatCurrentCulture(MongoDatabaseOptions.SectionName, nameof(MongoDatabaseOptions.ConnectionString)),
                connectionString);
        }

        public void UpdateCacheConnectionString(string connectionString)
        {
            const string Format = "{0}:{1}";

            webHostBuilder.UseSetting(
                Format.FormatCurrentCulture(CacheOptions.SectionName, nameof(CacheOptions.ConnectionString)),
                connectionString);
        }
    }
}
