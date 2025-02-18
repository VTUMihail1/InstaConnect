namespace InstaConnect.Follows.Infrastructure.Helpers;

internal class DatabaseSeeder : IDatabaseSeeder
{
    private readonly FollowsContext _followsContext;

    public DatabaseSeeder(FollowsContext followsContext)
    {
        _followsContext = followsContext;
    }

    public Task SeedAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public async Task ApplyPendingMigrationsAsync(CancellationToken cancellationToken)
    {
        var pendingMigrations = await _followsContext.Database.GetPendingMigrationsAsync(cancellationToken);

        if (pendingMigrations.Any())
        {
            await _followsContext.Database.MigrateAsync(cancellationToken);
        }
    }
}
