using InstaConnect.Shared.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace InstaConnect.Shared.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly BaseDbContext _baseDbContext;

    public UnitOfWork(BaseDbContext baseDbContext)
    {
        _baseDbContext = baseDbContext;
    }

    public DatabaseFacade Database => _baseDbContext.Database;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _baseDbContext.SaveChangesAsync(cancellationToken);
    }
}
