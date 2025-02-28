namespace InstaConnect.Common.Application.Abstractions;

public interface IDatabaseSeeder
{
    Task SeedAsync(CancellationToken cancellationToken);

    Task ApplyPendingMigrationsAsync(CancellationToken cancellationToken);
}
