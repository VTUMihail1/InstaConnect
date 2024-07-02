﻿using InstaConnect.Shared.Data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Messages.Data.Write.Helpers;

internal class DatabaseSeeder : IDatabaseSeeder
{
    private readonly IUnitOfWork _unitOfWork;

    public DatabaseSeeder(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
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
