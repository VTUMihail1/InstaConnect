using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Common.Tests.Extensions;

public static class WebHostBuilderExtensions
{
    public static void UpdateDatabaseConnectionString(this IWebHostBuilder webHostBuilder, string connectionString)
    {
        const string DatabaseConnectionStringKey = "DatabaseOptions:ConnectionString";

        webHostBuilder.UseSetting(
            DatabaseConnectionStringKey,
            connectionString);
    }

    public static void UpdateCacheConnectionString(this IWebHostBuilder webHostBuilder, string connectionString)
    {
        const string CacheConnectionStringKey = "CacheOptions:ConnectionString";

        webHostBuilder.UseSetting(
            CacheConnectionStringKey,
            connectionString);
    }
}
