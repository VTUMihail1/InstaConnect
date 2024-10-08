﻿using Microsoft.EntityFrameworkCore.Infrastructure;

namespace InstaConnect.Shared.Data.Abstractions;

public interface IUnitOfWork
{
    DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
