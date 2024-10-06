namespace InstaConnect.Shared.Data.Abstractions;

public interface IDatabaseSeeder
{
    Task SeedAsync(CancellationToken cancellationToken);

    Task ApplyPendingMigrationsAsync(CancellationToken cancellationToken);
}
