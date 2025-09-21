namespace InstaConnect.Messages.Infrastructure.Helpers;

internal class DatabaseSeeder : IDatabaseSeeder
{
    private readonly ChatsContext _messagesContext;

    public DatabaseSeeder(ChatsContext messagesContext)
    {
        _messagesContext = messagesContext;
    }

    public Task SeedAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public async Task ApplyPendingMigrationsAsync(CancellationToken cancellationToken)
    {
        var pendingMigrations = await _messagesContext.Database.GetPendingMigrationsAsync(cancellationToken);

        if (pendingMigrations.Any())
        {
            await _messagesContext.Database.MigrateAsync(cancellationToken);
        }
    }
}
