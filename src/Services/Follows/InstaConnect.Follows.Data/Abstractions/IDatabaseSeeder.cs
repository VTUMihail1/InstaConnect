namespace InstaConnect.Follows.Data.Abstractions;

public interface IDatabaseSeeder
{
    Task SeedAsync(CancellationToken cancellationToken);

    Task ApplyPendingMigrationsAsync(CancellationToken cancellationToken);
}
