﻿using InstaConnect.Messages.Data.Abstractions;

namespace InstaConnect.Messages.Web.Extensions;

public static class HostExtensions
{
    public static async Task SetUpDatabaseAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();

        var databaseInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseSeeder>();
        var cancellationToken = new CancellationToken();

        await databaseInitializer.ApplyPendingMigrationsAsync(cancellationToken);
        await databaseInitializer.SeedAsync(cancellationToken);

    }
}
