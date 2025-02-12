namespace InstaConnect.Shared.Application.Abstractions;

public interface IDatabaseSeeder
{
    Task SeedAsync(CancellationToken cancellationToken);

    Task ApplyPendingMigrationsAsync(CancellationToken cancellationToken);
}
