using InstaConnect.Shared.Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Data.Helpers;

internal class DatabaseSeeder : IDatabaseSeeder
{
    private readonly IUnitOfWork _unitOfWork;

    public DatabaseSeeder(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task SeedAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public async Task ApplyPendingMigrationsAsync(CancellationToken cancellationToken)
    {
        var pendingMigrations = await _unitOfWork.Database.GetPendingMigrationsAsync(cancellationToken);

        if (pendingMigrations.Any())
        {
            await _unitOfWork.Database.MigrateAsync(cancellationToken);
        }
    }
}
