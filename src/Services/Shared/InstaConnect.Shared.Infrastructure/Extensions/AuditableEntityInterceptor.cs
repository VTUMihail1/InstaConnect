using InstaConnect.Shared.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InstaConnect.Shared.Infrastructure.Extensions;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context != null)
        {
            var changeTracker = eventData.Context.ChangeTracker;

            UpdateAddedEntriesTimestramp(changeTracker);
            UpdateModifiedEntriesTimestramp(changeTracker);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateAddedEntriesTimestramp(ChangeTracker changeTracker)
    {
        var entries = changeTracker
            .Entries<IAuditableInfo>()
            .Where(e => e.State == EntityState.Added);

        foreach (var entry in entries)
        {
            var entity = entry.Entity;
            var currentTime = DateTime.UtcNow;
            entity.CreatedAt = currentTime;
            entity.UpdatedAt = currentTime;
        }
    }

    private void UpdateModifiedEntriesTimestramp(ChangeTracker changeTracker)
    {
        var entries = changeTracker
            .Entries<IAuditableInfo>()
            .Where(e => e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            var entity = entry.Entity;
            var currentTime = DateTime.UtcNow;
            entity.UpdatedAt = currentTime;
        }
    }
}
