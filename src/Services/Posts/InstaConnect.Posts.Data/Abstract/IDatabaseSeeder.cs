namespace InstaConnect.Posts.Data.Abstract;

public interface IDatabaseSeeder
{
    Task SeedAsync(CancellationToken cancellationToken);

    Task ApplyPendingMigrationsAsync(CancellationToken cancellationToken);
}
