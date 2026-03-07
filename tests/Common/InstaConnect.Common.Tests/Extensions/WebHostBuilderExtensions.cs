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
            webHostBuilder.UseSetting(
                MongoDatabaseOptions.SectionName.FormatCurrentCultureSectionKey(nameof(MongoDatabaseOptions.ConnectionString)),
                connectionString);
        }

        public void UpdateCacheConnectionString(string connectionString)
        {
            webHostBuilder.UseSetting(
                CacheOptions.SectionName.FormatCurrentCultureSectionKey(nameof(CacheOptions.ConnectionString)),
                connectionString);
        }
    }
}
