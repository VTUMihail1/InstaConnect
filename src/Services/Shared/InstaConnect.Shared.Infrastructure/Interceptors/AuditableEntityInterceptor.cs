using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Domain.Abstractions;

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace InstaConnect.Shared.Infrastructure.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public AuditableEntityInterceptor(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

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
            var currentTime = _dateTimeProvider.GetCurrentUtc();
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
            var currentTime = _dateTimeProvider.GetCurrentUtc();
            entity.UpdatedAt = currentTime;
        }
    }
}
