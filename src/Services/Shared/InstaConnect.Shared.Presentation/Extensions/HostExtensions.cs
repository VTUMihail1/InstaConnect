using InstaConnect.Shared.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InstaConnect.Shared.Presentation.Extensions;

public static class HostExtensions
{
    public static async Task SetUpDatabaseAsync(this IHost host, CancellationToken cancellationToken)
    {
        using var scope = host.Services.CreateScope();

        var databaseInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();

        await databaseInitializer.ApplyPendingMigrationsAsync(cancellationToken);
        await databaseInitializer.SeedAsync(cancellationToken);
    }
}
