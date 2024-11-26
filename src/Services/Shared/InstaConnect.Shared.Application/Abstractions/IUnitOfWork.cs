using Microsoft.EntityFrameworkCore.Infrastructure;

namespace InstaConnect.Shared.Application.Abstractions;

public interface IUnitOfWork
{
    DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
