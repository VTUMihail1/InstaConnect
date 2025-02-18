namespace InstaConnect.Posts.Infrastructure.Helpers;

internal class DatabaseSeeder : IDatabaseSeeder
{
    private readonly PostsContext _postsContext;

    public DatabaseSeeder(PostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public Task SeedAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public async Task ApplyPendingMigrationsAsync(CancellationToken cancellationToken)
    {
        var pendingMigrations = await _postsContext.Database.GetPendingMigrationsAsync(cancellationToken);

        if (pendingMigrations.Any())
        {
            await _postsContext.Database.MigrateAsync(cancellationToken);
        }
    }
}
