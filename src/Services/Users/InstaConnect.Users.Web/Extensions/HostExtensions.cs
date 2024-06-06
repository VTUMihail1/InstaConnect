using InstaConnect.Users.Data.Abstraction.Helpers;

namespace InstaConnect.Users.Web.Extensions;

public static class HostExtensions
{
    public static async Task SetUpDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();

        var databaseInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();

        await databaseInitializer.ApplyPendingMigrationsAsync();
        await databaseInitializer.SeedAsync();

    }
}
